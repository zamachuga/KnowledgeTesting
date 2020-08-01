import ServiceAxios from '../../../services/ServiceAxios.js';
import ApiTestManagement from '../../TestManagement/api-proxy.js';

let _ControllerTesting = "Testing";

let _ActionStartTest = "StartTest";
let _ActionGetAllTests = ApiTestManagement.GetAllTests;
let _ActionGetNextQuestion = "GetNextQuestion";
let _ActionAnswerTheQuestion = "AnswerTheQuestion";

export default {
	// Ответить на вопрос.
	AnswerTheQuestion(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_ControllerTesting, _ActionAnswerTheQuestion, Request, CallbackTry, CallbackCath);
	},

	// Получить следующий вопрос.
	GetNextQuestion(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_ControllerTesting, _ActionGetNextQuestion, Request, CallbackTry, CallbackCath);
	},

	// Получить список всех тестов.
	GetAllTests: _ActionGetAllTests,

	// Начать прохождение теста.
	StartTest(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_ControllerTesting, _ActionStartTest, Request, CallbackTry, CallbackCath);
	}
};