using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Newtonsoft.Json;

namespace KnowledgeTesting.BL
{
	public class Utils
	{
		/// <summary>
		/// Сериализация объекта в строку JSON.
		/// </summary>
		/// <param name="Object"></param>
		/// <returns></returns>
		public static string JsonSerialize(object Object)
		{
			return JsonConvert.SerializeObject(Object, GetJsonSettings());
		}

		/// <summary>
		/// Десериализовать JSON в объект.
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="Json"></param>
		/// <returns></returns>
		public static T JsonDeserialize<T>(string Json)
		{
			return JsonConvert.DeserializeObject<T>(Json, GetJsonSettings());
		}

		/// <summary>
		/// Настройки сериализации/десериализации JSON.
		/// </summary>
		private static JsonSerializerSettings GetJsonSettings()
		{
			JsonSerializerSettings _Settings = new JsonSerializerSettings
			{
				// Все циклические ссылки выгружаются как объекты.
				//ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
				// Все объекты получают идентификатор и циклические ссылки выгружаются
				// как ссылки на идентификатор: "$ref": "2".
				PreserveReferencesHandling = PreserveReferencesHandling.Objects,
				Formatting = Formatting.Indented
			};

			return _Settings;
		}

		/// <summary>
		/// Перенести данные из одного объекта в другой сериализацией через Json.
		/// </summary>
		/// <typeparam name="T">Новый тип объекта.</typeparam>
		/// <param name="Object">Текущий объект</param>
		/// <returns></returns>
		public static T ConverObjectByJson<T>(object Object)
		{
			string _Json = JsonConvert.SerializeObject(Object, GetJsonSettings());
			var _Object = JsonConvert.DeserializeObject<T>(_Json, GetJsonSettings());

			return _Object;
		}

		///// <summary>
		///// Перенести данные из одного объекта в другой сериализацией через Json.
		///// </summary>
		///// <typeparam name="T">Новый тип объекта.</typeparam>
		///// <param name="Object">Текущий объект</param>
		///// <returns></returns>
		//public static T[] ConverArrayObjectsByJson<T>(object[] Objects)
		//{
		//	List<T> _Result = new List<T>();
		//	foreach (var item in Objects)
		//	{
		//		var _ResultObject = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(item));
		//		_Result.Add(_ResultObject);
		//	}

		//	return _Result.ToArray();
		//}

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