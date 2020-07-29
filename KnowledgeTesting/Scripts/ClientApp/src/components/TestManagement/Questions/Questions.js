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
					// Вроде обошлось, похоже была проблема в том, что вместо data, было написано Data,
					// а при переводе в код страницы некоторые слова переводятся в нижний регистр 
					// построителем страниц и особенностями JavaScript.
					//_This.$forceUpdate();
				},
				Error => { }
			);
		}
	}
};