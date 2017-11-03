#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Microsoft.AspNetCore.Mvc.ApplicationParts;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

#endregion

namespace Achilles.Acme.Composition.Modules
{
    /// <summary>
    /// An <see cref="IApplicationFeatureProvider{TFeature}"/> for <see cref="CompositionFeature"/>.
    /// </summary>
    public class CompositionFeatureProvider : IApplicationFeatureProvider<CompositionFeature>
    {
        private IList<ModulePart> _moduleParts = null;
        private string _assemblyName;

        /// <summary>
        /// Initializes a new <see cref="CompositionFeatureProvider"/> instance.
        /// </summary>
        /// <param name="applicationAssemblyName">The appliction assembly name used for module discovery.</param>
        public CompositionFeatureProvider( string applicationAssemblyName )
        {
            _assemblyName = applicationAssemblyName;
        }

        /// <inheritdoc />
        public void PopulateFeature( IEnumerable<ApplicationPart> parts, CompositionFeature feature )
        {
            foreach ( var modulePart in GetModuleParts() )
            {
                feature.Modules.Add( modulePart );
            }
        }

        /// <summary>
        /// Gets the list of <see cref="ModulePart"/>s ordered by dependencies.
        /// </summary>
        private IList<ModulePart> GetModuleParts()
        {
            if ( _moduleParts == null )
            {
                var moduleParts = new List<ModulePart>();

                var parts = ComposableAssemblyDiscoveryProvider.DiscoverComposableAssemblies( _assemblyName );

                foreach ( var part in parts )
                {
                    var moduleTypes = new List<TypeInfo>();

                    foreach ( var type in part.Types )
                    {

                        if ( ModuleConventions.IsModule( type ) )
                        {
                            moduleTypes.Add( type );
                        }
                    }

                    if ( moduleTypes.Count > 0 )
                    {
                        moduleParts.Add( new ModulePart( part.Assembly, moduleTypes ) );
                    }
                }

                _moduleParts = OrderModulePartsByDependencies( moduleParts );
            }

            return _moduleParts;
        }

        /// <summary>
        /// Orders the module parts by dependencies.
        /// </summary>
        /// <param name="moduleParts"></param>
        /// <returns></returns>
        private IList<ModulePart> OrderModulePartsByDependencies( List<ModulePart> moduleParts )
        {
            if ( moduleParts.Count <= 1 )
            {
                return moduleParts;
            }

            var loadOrderedParts = new List<ModulePart>();

            loadOrderedParts.Add( moduleParts[ 0 ] );

            for ( int i = 1; i < moduleParts.Count; i++ )
            {
                bool hasDependency = false;

                for ( int j = 0; j < loadOrderedParts.Count; j++ )
                {
                    hasDependency = loadOrderedParts[ j ].Dependencies.Any( d => d.Name == moduleParts[ i ].Name );

                    if ( hasDependency )
                    {
                        loadOrderedParts.Insert( j, moduleParts[ i ] );
                        break;
                    }
                }

                if ( !hasDependency )
                {
                    loadOrderedParts.Add( moduleParts[ i ] );
                }
            }

            return loadOrderedParts;
        }
    }
}
