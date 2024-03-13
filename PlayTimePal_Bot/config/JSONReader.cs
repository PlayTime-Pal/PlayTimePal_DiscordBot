using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace PlayTimePal_Bot.config
{
	internal class JSONReader
	{
		public string token {  get; set; }
		public string prefix { get; set; }

		public async Task ReadJSON()
		{
			using (StreamReader sr = new StreamReader("config.json"))
			{
				string json = await sr.ReadToEndAsync();
				JSONStructure data = JsonConvert.DeserializeObject<JSONStructure>(json);

				this.token = data.token;
				this.prefix = data.prefix;
			}
		}
	}

	internal sealed class JSONStructure
	{
		public string token { get; set; }
		public string prefix { get; set; }
	}
}
