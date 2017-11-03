#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using System;
using System.Collections.Generic;
using System.Reflection;

#endregion

namespace Achilles.Acme.Composition.Modules
{
    public class ModulePart
    {
        #region Constructor(s)

        public ModulePart( Assembly assembly, IList<TypeInfo> moduleTypes )
        {
            Assembly = assembly ?? throw new ArgumentNullException( nameof( assembly ) );

            Types = moduleTypes;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the <see cref="Assembly"/> of the <see cref="ComposableAssembly"/>.
        /// </summary>
        public Assembly Assembly { get; }

        /// <summary>
        /// Gets the list of <see cref="TypeInfo"/> module types. 
        /// </summary>
        public IList<TypeInfo> Types { get; }

        /// <summary>
        /// Gets the name of the <see cref="ComposableAssembly"/>.
        /// </summary>
        public string Name => Assembly.GetName().Name;

        /// <summary>
        /// Gets the list of module part dependencies.
        /// </summary>
        public IEnumerable<AssemblyName> Dependencies => Assembly.GetReferencedAssemblies();

        #endregion
    }
}
