using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XAbcPaymentSdkCore.Util
{
    public static class JsonParseUtil
    {
        public static string ToJson(object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }
        public static T Deserialize<T>(string json)
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(json, new JsonSerializerSettings() { Formatting = Formatting.None });
        }
		public static string GetKeyValue(string text,string aTag)
		{
			int num = text.IndexOf(aTag);
			string result;
			if (num == -1)
			{
				result = "";
			}
			else
			{
				while (!text.Substring(num - 1, 1).Equals("\"") || !text.Substring(num + aTag.Length, 1).Equals("\""))
				{
					num = text.IndexOf(aTag, num + 1);
					if (num == -1)
					{
						return "";
					}
				}
				int length = aTag.Length;
				num = num + length + 2;
				string text2 = "";
				char c = text[num];
				if (c == '{')
				{
					text2 = GetObjectValue(num, aTag, text);
				}
				if (c == '"')
				{
					text2 = GetStringValue(num, aTag, text);
				}
				result = text2;
			}
			return result;
		}
		private static string GetObjectValue(int index, string aTag, string json)
		{
			int num = 0;
			StringBuilder stringBuilder = new StringBuilder();
			char c;
			for (; ; )
			{
				c = json[index];
				if (c == '{')
				{
					num++;
				}
				if (c == '}')
				{
					num--;
				}
				if (num == 0)
				{
					break;
				}
				stringBuilder.Append(c);
				index++;
			}
			stringBuilder.Append(c);
			return stringBuilder.ToString();
		}
		private static string GetStringValue(int index, string aTag, string json)
		{
			StringBuilder stringBuilder = new StringBuilder();
			index++;
			for (; ; )
			{
				char c = json[index++];
				if (c == '"')
				{
					break;
				}
				stringBuilder.Append(c);
			}
			return stringBuilder.ToString();
		}

	}
}
