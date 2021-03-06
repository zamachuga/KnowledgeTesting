
import ServiceAxios from '../../../services/ServiceAxios.js';

let _Controller = "TestManagement";

let _ActionGetListQuestionForTest = "GetListQuestionForTest";
let _ActionRemoveQuesion = "RemoveQuesion";
let _ActionGetAllQuestions = "GetAllQuestions";
let _ActionAddQuestionToTest = "AddQuestionToTest";

export default {
	// Получить тест.
	GetListQuestionForTest(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_Controller, _ActionGetListQuestionForTest, Request, CallbackTry, CallbackCath);
	},

	// Удалить вопрос из теста.
	RemoveQuesion(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_Controller, _ActionRemoveQuesion, Request, CallbackTry, CallbackCath);
	},

	// Получить список всех вопросов.
	GetAllQuestions(Request, CallbackTry, CallbackCath){
		ServiceAxios.ServiceAxios.PostApi(_Controller, _ActionGetAllQuestions, Request, CallbackTry, CallbackCath);
	},

	// Добавить вопрос в тест.
	AddQuestionToTest(Request, CallbackTry, CallbackCath){
		ServiceAxios.ServiceAxios.PostApi(_Controller, _ActionAddQuestionToTest, Request, CallbackTry, CallbackCath);
	}
};