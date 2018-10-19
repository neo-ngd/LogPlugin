using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace Neo.Plugins
{
	internal class Settings
    {
		public int CacheCount { get; }
		public string Backend { get; }

		public static Settings Default { get; }

		static Settings() 
		{
			Default = new Settings(Assembly.GetExecutingAssembly().GetConfiguration());
		}
		public Settings(IConfigurationSection section) 
		{
			this.CacheCount = GetValueOrDefault(section.GetSection("CacheCount"), 500, p => int.Parse(p));
			this.Backend = section.GetSection("Backend").Value;
		}

		public T GetValueOrDefault<T>(IConfigurationSection section, T defaultValue, Func<string, T> selector)
		{
			if (section.Value == null) return defaultValue;
			return selector(section.Value);
		}
    }
}
