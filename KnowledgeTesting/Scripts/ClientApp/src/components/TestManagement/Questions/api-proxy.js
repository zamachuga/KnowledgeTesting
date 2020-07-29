
import ServiceAxios from '../../../services/ServiceAxios.js';

let _Controller = "TestManagement";

let _ActionGetAllQuestions = "GetAllQuestions";
let _ActionSetCorrectAnswer = "SetCorrectAnswer";

export default {
	// Получить все вопросы.
	GetAllQuestions(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_Controller, _ActionGetAllQuestions, Request, CallbackTry, CallbackCath);
	},

	// Установить правильный ответ.
	SetCorrectAnswer(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_Controller, _ActionSetCorrectAnswer, Request, CallbackTry, CallbackCath);
	}
};