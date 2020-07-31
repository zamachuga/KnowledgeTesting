import ServiceAxios from '../../../services/ServiceAxios.js';

let _ControllerTestManagement = "TestManagement";

let _ActionGetTest = "GetTest";
let _ActionSaveChangeTest = "SaveChangeTest";
let _ActionCreateTest = "CreateTest";

export default {
	// Получить тест.
	GetTest(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_ControllerTestManagement, _ActionGetTest, Request, CallbackTry, CallbackCath);
	},

	// Сохранить изменения теста.
	SaveChangeTest(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_ControllerTestManagement, _ActionSaveChangeTest, Request, CallbackTry, CallbackCath);
	},

	// Создать тест.
	CreateTest(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_ControllerTestManagement, _ActionCreateTest, Request, CallbackTry, CallbackCath);
	}
};