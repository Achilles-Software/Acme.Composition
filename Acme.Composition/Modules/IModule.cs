#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

#endregion

namespace Achilles.Acme.Composition.Modules
{
    /// <summary>
    /// The interface for modules deployed in an ACME web application.
    /// </summary>
    public interface IModule {
        /// <summary>
        /// The module initialization method.
        /// </summary>
        void Initialize( IServiceCollection services, IConfiguration configuration );
    }
}
