﻿#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using System.Collections.Generic;

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

    }
}
