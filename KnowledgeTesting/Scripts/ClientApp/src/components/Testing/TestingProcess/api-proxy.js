import ServiceAxios from '../../../services/ServiceAxios.js';

let _Controller = "Testing";

let _Action = "";

export default {
	// Получить список всех тестов.
	Action(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_Controller, _Action, Request, CallbackTry, CallbackCath);
	}
};