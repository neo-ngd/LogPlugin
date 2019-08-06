using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Neo.Plugins
{
    internal class Settings
    {
        public string Name { get; }
        public int CacheCount { get; }
        public string Backend { get; }
        public static Settings Default { get; private set; }

        public Settings(IConfigurationSection section)
        {
            this.CacheCount = 256;
            this.Name = section.GetSection("Name").Value;
            this.Backend = section.GetSection("Backend").Value;
        }

        public T GetValueOrDefault<T>(IConfigurationSection section, T defaultValue, Func<string, T> selector)
        {
            if (section.Value == null) return defaultValue;
            return selector(section.Value);
        }
		
        public static void Load(IConfigurationSection section)
        {
            Default = new Settings(section);
        }
    }
}
