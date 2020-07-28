import Proxy from './api-proxy.js';

export default {
	name: "Questions",
	props: ['CurrentComponent'],
	DataCue() {
		return {
			ListQuestions: []
		};
	},
	created() {
		this.GetAllQuestions();
	},
	methods: {
		// Выбрать правильный ответ.
		SetCorrectAnswer(QuestionId, AnswerId) {
			console.log("Вопрос " + QuestionId + " правильный ответ " + AnswerId);
		},

		// Получить список всех вопросов.
		GetAllQuestions() {
			let _This = this;
			_This.ListQuestions = [];

			Proxy.GetAllQuestions(
				{ FilterName: null },
				Data => {
					_This.ListQuestions = Data;
					_This.$forceUpdate();
				},
				Error => { }
			);
		}
	}
};