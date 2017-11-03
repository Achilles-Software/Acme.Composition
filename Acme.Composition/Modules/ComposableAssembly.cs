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
    /// <summary>
    /// A discoverable composition assembly.
    /// </summary>
    public class ComposableAssembly
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ComposableAssembly"/>.
        /// </summary>
        /// <param name="assembly">The composable assembly.</param>
        public ComposableAssembly( Assembly assembly )
        {
            Assembly = assembly ?? throw new ArgumentNullException( nameof( assembly ) );
        }

        /// <summary>
        /// Gets the <see cref="Assembly"/> of the <see cref="ComposableAssembly"/>.
        /// </summary>
        public Assembly Assembly { get; }

        /// <summary>
        /// Gets the name of the <see cref="ComposableAssembly"/>.
        /// </summary>
        public string Name => Assembly.GetName().Name;

        /// <summary>
        /// Gets the list of types in the <see cref="ComposableAssembly"/>.
        /// </summary>
        public IEnumerable<TypeInfo> Types => Assembly.DefinedTypes;
    }
}
