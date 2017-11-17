#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

#endregion

namespace Achilles.Acme.Composition.Modules
{
    /// <summary>
    /// The list of module types in an Acme application. The <see cref="CompositionFeature"/> can be populated
    /// using the <see cref="ApplicationPartManager"/> that is available during startup at <see cref="IMvcBuilder.PartManager"/>
    /// and <see cref="IMvcCoreBuilder.PartManager"/> or at a later stage by requiring the <see cref="ApplicationPartManager"/>
    /// as a dependency in a component.
    /// </summary>
    public class CompositionFeature
    {
        /// <summary>
        /// Gets the list of module types in an Acme application.
        /// </summary>
        public IList<ModulePart> Modules { get; } = new List<ModulePart>();
    }
}
