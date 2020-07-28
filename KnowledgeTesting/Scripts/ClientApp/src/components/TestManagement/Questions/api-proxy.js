
import ServiceAxios from '../../../services/ServiceAxios.js';

let _Controller = "TestManagement";

let _ActionGetAllQuestions = "GetAllQuestions";

export default {
	// Получить все вопросы.
	GetAllQuestions(Request, CallbackTry, CallbackCath) {
		ServiceAxios.ServiceAxios.PostApi(_Controller, _ActionGetAllQuestions, Request, CallbackTry, CallbackCath);
	}
};