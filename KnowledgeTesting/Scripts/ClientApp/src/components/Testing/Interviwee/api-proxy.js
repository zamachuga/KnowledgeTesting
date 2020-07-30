import ServiceAxios from '../../../services/ServiceAxios.js';

let _Controller = "Testing";

let _ActionAuth = "Auth";

export default {
	// Получить список всех тестов.
	Auth(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_Controller, _ActionAuth, Request, CallbackTry, CallbackCath);
	}
};