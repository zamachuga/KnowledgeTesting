
import ServiceAxios from '../../../services/ServiceAxios.js';

let _Controller = "TestManagement";

let _ActionGetAllQuestions = "GetAllQuestions";
let _ActionSetCorrectAnswer = "SetCorrectAnswer";
let _ActionRemoveAnswer = "RemoveAnswerFromQuestion";
let _ActionGetAllAnswers = "GetAllAnswers";
let _ActionAddAnswerToQuestion = "AddAnswerToQuestion";
let _ActionCreateAnswerToQuestion = "CreateAnswerToQuestion";
let _ActionCreateQuestion = "CreateQuestion";
let _ActionEditQuestion = "EditQuestion";

export default {
	// Создать новый вопрос.
	CreateQuestion(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_Controller, _ActionCreateQuestion, Request, CallbackTry, CallbackCath);
	},

	// Редактировать вопрос.
	EditQuestion(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_Controller, _ActionEditQuestion, Request, CallbackTry, CallbackCath);
	},

	// Создать новый ответ для вопроса.
	CreateAnswerToQuestion(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_Controller, _ActionCreateAnswerToQuestion, Request, CallbackTry, CallbackCath);
	},

	// Добавить ответ в вопрос.
	AddAnswerToQuestion(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_Controller, _ActionAddAnswerToQuestion, Request, CallbackTry, CallbackCath);
	},

	// Получить все ответы.
	GetAllAnswers(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_Controller, _ActionGetAllAnswers, Request, CallbackTry, CallbackCath);
	},

	// Получить все вопросы.
	GetAllQuestions(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_Controller, _ActionGetAllQuestions, Request, CallbackTry, CallbackCath);
	},

	// Установить правильный ответ.
	SetCorrectAnswer(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_Controller, _ActionSetCorrectAnswer, Request, CallbackTry, CallbackCath);
	},

	// Удалить ответ из вопроса.
	RemoveAnswerFromQuestion(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_Controller, _ActionRemoveAnswer, Request, CallbackTry, CallbackCath);
	}
};