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

		/// <summary>
		/// Перенести данные из одного объекта в другой сериализацией через Json.
		/// </summary>
		/// <typeparam name="T">Новый тип объекта.</typeparam>
		/// <param name="Object">Текущий объект</param>
		/// <returns></returns>
		public static T[] ConverArrayObjectsByJson<T>(object[] Objects)
		{
			List<T> _Result = new List<T>();
			foreach (var item in Objects)
			{
				var _ResultObject = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(item));
				_Result.Add(_ResultObject);
			}

			return _Result.ToArray();
		}

		/// <summary>
		/// Сравнение двух строк.
		/// </summary>
		/// <param name="Text1">Первая строка.</param>
		/// <param name="Text2">Вторая строка.</param>
		/// <returns></returns>
		public static bool ExpressionText(string TextA, string TextB)
		{
			var _A = TextB.Replace(" ", "").ToLower();
			var _B = TextB.Replace(" ", "").ToLower();

			return _A == _B;
		}
	}
}