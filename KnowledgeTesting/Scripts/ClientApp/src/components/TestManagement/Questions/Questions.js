import Proxy from './api-proxy.js';

export default {
	name: "Questions",
	props: ['CurrentComponent'],
	DataCue() {
		return {
			megalist: []
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
			_This.megalist = [];

			Proxy.GetAllQuestions(
				{ FilterName: null },
				Data => {
					_This.megalist = Data;
					_This.$forceUpdate();
					console.log(_This.megalist);
				},
				Error => { }
			);
		}
	}
};