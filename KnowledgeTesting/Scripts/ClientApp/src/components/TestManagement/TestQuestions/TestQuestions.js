import Proxy from './api-proxy.js';

export default {
	name: 'TestQuestions',
	props: ['ModelTest', 'CurrentComponent'],
	data() {
		return {
			listtestquestions: [],
			listquestions: [],
			FilterQuestion: "",
			SelectedQuestionToAdd: null
		};
	},
	created() {
		let _This = this;

		_This.GetAllTestQuestions();
	},
	methods: {
		// Получить список всех вопросов.
		GetAllQuestions(Filter) {
			let _This = this;

			Proxy.GetAllQuestions(
				{ FilterName: Filter },
				Data => {
					_This.listquestions = Data;
				},
				Error => { }
			);
		},

		// Добавить вопрос в тест.
		AddQuestionToTest() {
			let _This = this;

			if (_This.SelectedQuestionToAdd != null) {
				Proxy.AddQuestionToTest(
					{
						TestId: _This.ModelTest.Id,
						QuestionId: _This.SelectedQuestionToAdd
					},
					Data => {

						_This.GetAllTestQuestions();
					},
					Error => { }
				);
			}
		},

		// Получить список всех вопросов для теста.
		GetAllTestQuestions() {
			let _This = this;

			_This.listtestquestions = [];

			Proxy.GetListQuestionForTest(
				{ Id: _This.ModelTest.Id },
				Data => {
					_This.listtestquestions = Data;
				},
				Error => { }
			);
		},

		// Удалить вопрос из теста.
		RemoveQuestion(IdQuestion) {
			let _This = this;

			Proxy.RemoveQuesion(
				{
					TestId: _This.ModelTest.Id,
					QuestionId: IdQuestion
				},
				Data => {
					_This.GetAllTestQuestions();
				},
				Error => { }
			);
		}
	}
};