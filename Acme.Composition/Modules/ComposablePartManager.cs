#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using System.Collections.Generic;
using System.Reflection;

#endregion

namespace Achilles.Acme.Composition.Modules
{
    /// <summary>
    /// Manages the composable parts of an ACME application.
    /// </summary>
    public class ComposablePartManager
    {
        /// <summary>
        /// Gets the list of <see cref="ComposablePart"/>s.
        /// </summary>
        public IList<ComposablePart> ComposableParts { get; } = new List<ComposablePart>();

        public List<ModulePart> GetModules()
        {
            var modules = new List<ModulePart>();

            foreach ( var part in ComposableParts )
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
                    modules.Add( new ModulePart( part.Assembly, moduleTypes ) );
                }
            }

            return modules;
        }
    }
}
