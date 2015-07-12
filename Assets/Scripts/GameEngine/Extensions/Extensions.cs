using UnityEngine;
using System;
using System.IO;
using System.Collections;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace GameEngine.Extensions
{
	public class Extensions
	{


	}

	public class PlayerPrefsSerialization
	{
		public static BinaryFormatter binaryFormatter = new BinaryFormatter();

		public static void Save(string saveTag, object obj)
		{
			MemoryStream memoryStream = new MemoryStream();
			binaryFormatter.Serialize(memoryStream, obj);
			string serializedDataString = System.Convert.ToBase64String(memoryStream.ToArray());
			PlayerPrefs.SetString(saveTag, serializedDataString);
		}

		public static object Load(string saveTag)
		{
			string serializedDataString = PlayerPrefs.GetString(saveTag);

			if(serializedDataString == string.Empty)
				return null;

			MemoryStream memoryStream = new MemoryStream(System.Convert.FromBase64String(serializedDataString));
			return binaryFormatter.Deserialize(memoryStream);
		}
	}
}
