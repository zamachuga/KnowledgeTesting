import ServiceAxios from '../../services/ServiceAxios.js';

let _ControllerTesting = "Statistics";

let _ActionGetTestsInterviwee = "GetTestsInterviwee";
let _ActionGetStatisticTest = "GetStatisticTest"

export default {
	// Получить статистику прохождения теста.
	GetStatisticTest(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_ControllerTesting, _ActionGetStatisticTest, Request, CallbackTry, CallbackCath);
	},

	// Получить список тестов, которые прошел пользователь.
	GetTestsInterviwee(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_ControllerTesting, _ActionGetTestsInterviwee, Request, CallbackTry, CallbackCath);
	}
};