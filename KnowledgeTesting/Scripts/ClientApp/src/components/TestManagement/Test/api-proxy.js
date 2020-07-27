import ServiceAxios from '../../../services/ServiceAxios.js';

let _Controller = "TestManagement";

let _ActionGetTest = "GetTest";
let _ActionSaveChangeTest = "SaveChangeTest";
let _ActionCreateTest = "CreateTest";

export default {
	// Получить тест.
	GetTest(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_Controller, _ActionGetTest, Request, CallbackTry, CallbackCath);
	},

	// Сохранить изменения теста.
	SaveChangeTest(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_Controller, _ActionSaveChangeTest, Request, CallbackTry, CallbackCath);
	},

	// Создать тест.
	CreateTest(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_Controller, _ActionCreateTest, Request, CallbackTry, CallbackCath);
	}
};