using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Hosting;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;

namespace EnumLists
{
    [PluginController("EnumLists")]
    public class EnumApiController : UmbracoAuthorizedJsonController
    {
        public IEnumerable<string> GetAll(string assemblyName, string typeName)
        {
            var assembly = GetAssembly(assemblyName);
            var type = assembly.GetType(typeName);

            List<string> items = new List<string>();

            foreach (string name in Enum.GetNames(type))
            {
                items.Add(name);
            }

            return items;
        }

        /// <summary>
        /// Gets the <see cref="Assembly"/> with the specified name.
        /// </summary>
        /// <param name="assemblyName">The <see cref="Assembly"/> name.</param>
        /// <returns>The <see cref="Assembly"/>.</returns>
        public static Assembly GetAssembly(string assemblyName)
        {
            if (string.Equals(assemblyName, "App_Code", StringComparison.InvariantCultureIgnoreCase))
            {
                return Assembly.Load(assemblyName);
            }

            var path = HostingEnvironment.MapPath(string.Concat("~/bin/", assemblyName));
            return Assembly.ReflectionOnlyLoadFrom(path);
        }
    }
}