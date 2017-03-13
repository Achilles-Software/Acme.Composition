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
    public class ComposablePart
    {
        /// <summary>
        /// Initializes a new instance of <see cref="ComposablePart"/>.
        /// </summary>
        /// <param name="assembly">The composable part assembly.</param>
        public ComposablePart( Assembly assembly )
        {
            if ( assembly == null )
            {
                throw new ArgumentNullException( nameof( assembly ) );
            }

            Assembly = assembly;
        }

        /// <summary>
        /// Gets the <see cref="Assembly"/> of the <see cref="ComposablePart"/>.
        /// </summary>
        public Assembly Assembly { get; }

        /// <summary>
        /// Gets the name of the <see cref="ComposablePart"/>.
        /// </summary>
        public string Name => Assembly.GetName().Name;

        /// <inheritdoc />
        public IEnumerable<TypeInfo> Types => Assembly.DefinedTypes;
    }
}
