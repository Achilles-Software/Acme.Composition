#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Microsoft.Extensions.DependencyModel;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

#endregion

namespace Achilles.Acme.Composition.Modules
{
    /// <summary>
    /// An MVC application parts provider for the Acme module composition feature.
    /// </summary>
    public static class ComposableAssemblyDiscoveryProvider
    {
        /// <summary>
        /// Gets the set of assembly names that are used for discovery of Acme modules.
        /// </summary>
        private static HashSet<string> ReferenceAssemblies { get; } = new HashSet<string>( StringComparer.Ordinal )
        {
            "Acme.Composition",
            "Acme.Core"
        };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="entryPointAssemblyName"></param>
        /// <returns></returns>
        public static IEnumerable<ComposableAssembly> DiscoverComposableAssemblies( string entryPointAssemblyName )
        {
            var entryAssembly = Assembly.Load( new AssemblyName( entryPointAssemblyName ) );
            var context = DependencyContext.Load( entryAssembly );

            return GetCandidateAssemblies( entryAssembly, context )
                .Select( p => new ComposableAssembly( p ) ); 
        }

        private static IEnumerable<Assembly> GetCandidateAssemblies( Assembly entryAssembly, DependencyContext dependencyContext )
        {
            if ( dependencyContext == null )
            {
                return new List<Assembly>();
            }

            return GetCandidateLibraries( dependencyContext )
                .SelectMany( library => library.GetDefaultAssemblyNames( dependencyContext ) )
                .Select( Assembly.Load );
        }

        /// <summary>
        /// Returns a list of libraries that references the assemblies in <see cref="ReferenceAssemblies"/>.
        /// By default it returns all assemblies that reference Acme.Composition (IModule).
        /// </summary>
        /// <returns>A set of <see cref="RuntimeLibrary"/>.</returns>
        private static IEnumerable<RuntimeLibrary> GetCandidateLibraries( DependencyContext dependencyContext )
        {
            if ( ReferenceAssemblies == null )
            {
                return Enumerable.Empty<RuntimeLibrary>();
            }

            return dependencyContext.RuntimeLibraries.Where( IsCandidateLibrary );
        }

        private static bool IsCandidateLibrary( RuntimeLibrary library )
        {
            Debug.Assert( ReferenceAssemblies != null );

            return !ReferenceAssemblies.Contains( library.Name ) &&
                library.Dependencies.Any( dependency => ReferenceAssemblies.Contains( dependency.Name ) );
        }
    }
}
