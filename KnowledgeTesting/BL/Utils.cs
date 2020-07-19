using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace KnowledgeTesting.BL
{
	public class Utils
	{
		/// <summary>
		/// Перенести данные из одного объекта в другой сериализацией через Json.
		/// </summary>
		/// <typeparam name="T">Новый тип объекта.</typeparam>
		/// <param name="Object">Текущий объект</param>
		/// <returns></returns>
		public static T ConverObjectByJson<T>(object Object)
		{
			return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(Object));
		}
	}
}