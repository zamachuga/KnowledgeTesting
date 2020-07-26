import ServiceAxios from '../../services/ServiceAxios.js';

let _Controller = "TestManagement";

let _ActionGetAllTests = "GetAllTests";
let _ActionGetTest = "GetTest";
let _ActionSaveChangeTest = "SaveChangeTest";
let _ActionCreateTest = "CreateTest";
let _ActionGetListQuestionForTest = "GetListQuestionForTest";

export default {
	// Получить список всех тестов.
	GetAllTests(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_Controller, _ActionGetAllTests, Request, CallbackTry, CallbackCath);
	},

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
	},

	// Получить список вопросов для теста.
	GetListQuestionForTest(Request, CallbackTry, CallbackCath){
		ServiceAxios.ServiceAxios.PostApi(_Controller, _ActionGetListQuestionForTest, Request, CallbackTry, CallbackCath);
	}
};