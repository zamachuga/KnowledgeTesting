import ServiceAxios from '../../../services/ServiceAxios.js';
import ApiTestManagement from '../../TestManagement/api-proxy.js';

let _ControllerTesting = "Testing";

let _ActionStartTest = "StartTest";
let _ActionGetAllTests = ApiTestManagement.GetAllTests;

export default {
	// Получить список всех тестов.
	GetAllTests: _ActionGetAllTests,

	// Начать прохождение теста.
	StartTest(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_ControllerTesting, _ActionStartTest, Request, CallbackTry, CallbackCath);
	}
};