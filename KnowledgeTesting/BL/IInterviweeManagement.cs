using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeTesting.BL
{
	/// <summary>
	/// Управление тестируемыми.
	/// </summary>
	public interface IInterviweeManagement
	{
		void CreateInterviwee(DAO.Interviwee Interviwee);

		/// <summary>
		/// Получить по коду.
		/// </summary>
		DAO.Interviwee GetInterviwee(int id);

		/// <summary>
		/// Получить список завершенных тестов тестируемого.
		/// </summary>
		DAO.Test[] GetCompleteTests(DAO.Interviwee Interviwee);

		/// <summary>
		/// Получить по названию.
		/// </summary>
		DAO.Interviwee GetInterviwee(string LasName, string FirstName, string SecondName);
	}
}
