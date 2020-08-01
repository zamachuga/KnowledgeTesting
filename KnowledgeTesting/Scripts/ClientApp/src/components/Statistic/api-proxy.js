import ServiceAxios from '../../services/ServiceAxios.js';

let _ControllerTesting = "Statistics";

let _ActionGetTestsInterviwee = "GetTestsInterviwee";

export default {
	// Получить список тестов, которые прошел пользователь.
	GetTestsInterviwee(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_ControllerTesting, _ActionGetTestsInterviwee, Request, CallbackTry, CallbackCath);
	}
};