#region Copyright Notice

// Copyright (c) by Achilles Software, All rights reserved.
//
// Licensed under the MIT License. See License.txt in the project root for license information.
//
// Send questions regarding this copyright notice to: mailto:Todd.Thomson@achilles-software.com

#endregion

#region Namespaces

using System;
using System.Reflection;

#endregion

namespace Achilles.Acme.Composition.Modules
{
    /// <summary>
    /// Conventions for determining whether a Type is an Acme module.
    /// </summary>
    public static class ModuleConventions
    {
        #region Fields

        private const string ModuleSuffix = "Module";
        private static Type IModuleType = typeof( IModule );

        #endregion

        #region Public API Methods

        /// <summary>
        /// Flag for whether the specified TypeInfo is an Acme Module.
        /// </summary>
        /// <param name="typeInfo"></param>
        public static bool IsModule( TypeInfo typeInfo )
        {
            if ( typeInfo == null )
            {
                throw new ArgumentNullException( nameof( typeInfo ) );
            }

            if ( !IModuleType.IsAssignableFrom( typeInfo.AsType() ) ||  
                !typeInfo.IsClass ||
                !typeInfo.IsPublic ||
                typeInfo.IsAbstract ||
                typeInfo.ContainsGenericParameters )
            {
                return false;
            }

            return typeInfo.Name.EndsWith( ModuleSuffix, StringComparison.OrdinalIgnoreCase );
        }

        #endregion
    }
}
