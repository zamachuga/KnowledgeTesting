import Proxy from './api-proxy.js';

export default {
	name: "Questions",
	props: ['CurrentComponent'],
	data() {
		return {
			// Модель ответа на вопрос.
			ModelQuestionAnswer: {
				QuestionId: 0,
				AnswerId: 0,
				AnswerText: null,
				IsCorrect: false
			},
			// Список всех вопросов.
			ListQuestions: []
		};
	},
	created() {
		this.GetAllQuestions();
	},
	methods: {
		// Выбрать правильный ответ.
		SetCorrectAnswer(QuestionId, AnswerId) {
			let _This = this;

			_This.ModelQuestionAnswer.QuestionId = QuestionId;
			_This.ModelQuestionAnswer.AnswerId = AnswerId;

			Proxy.SetCorrectAnswer(
				_This.ModelQuestionAnswer,
				Data => _This.GetAllQuestions(),
				Error => _This.GetAllQuestions()
			);
		},

		// Получить список всех вопросов.
		GetAllQuestions() {
			let _This = this;
			_This.ListQuestions = [];

			Proxy.GetAllQuestions(
				{ FilterName: null },
				Data => {
					_This.ListQuestions = Data;
					//_This.$forceUpdate();
				},
				Error => { }
			);
		}
	}
};