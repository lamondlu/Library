using Newtonsoft.Json;
using System.IO;

namespace BookingLibrary.CoreUI.Utilities
{
	public static class JsonHelper
	{
		public static string ConvertJsonString(this string str)
		{
			//格式化json字符串
			JsonSerializer serializer = new JsonSerializer();
			TextReader tr = new StringReader(str);
			JsonTextReader jtr = new JsonTextReader(tr);
			object obj = serializer.Deserialize(jtr);
			if (obj != null)
			{
				StringWriter textWriter = new StringWriter();
				JsonTextWriter jsonWriter = new JsonTextWriter(textWriter)
				{
					Formatting = Formatting.Indented,
					Indentation = 4,
					IndentChar = ' '
				};
				serializer.Serialize(jsonWriter, obj);
				return textWriter.ToString();
			}
			else
			{
				return str;
			}
		}
	}
}