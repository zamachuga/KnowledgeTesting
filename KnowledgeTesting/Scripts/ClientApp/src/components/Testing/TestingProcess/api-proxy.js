import ServiceAxios from '../../../services/ServiceAxios.js';

let _Controller = "TestManagement";

let _ActionGetAllTests = "GetAllTests";

export default {
	// Получить список всех тестов.
	GetAllTests(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_Controller, _ActionGetAllTests, Request, CallbackTry, CallbackCath);
	}
};