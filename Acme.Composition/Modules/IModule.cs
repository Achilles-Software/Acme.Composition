#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

#endregion

namespace Achilles.Acme.Composition.Modules
{
    /// <summary>
    /// An interface for composable modules.
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// The module initialization method.
        /// </summary>
        ///  /// <param name="services">Service collection to add module services.</param>
        void Initialize( IServiceCollection services );

        /// <summary>
        /// Method to add services to the service collection
        /// </summary>
        /// <param name="services">Service collection to add module services.</param>
        /// <param name="configuration">The applications configuration root.</param>
        void ConfigureServices( IServiceCollection services, IConfiguration configuration );

        /// <summary>
        /// Method to configure the module.
        /// </summary>
        /// <param name="env"></param>
        void Configure( IHostingEnvironment env );
    }
}
