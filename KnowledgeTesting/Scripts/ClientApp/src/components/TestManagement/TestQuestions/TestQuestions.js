import Proxy from './api-proxy.js';

export default {
	name: 'TestQuestions',
	props: ['ModelTest', 'CurrentComponent'],
	data() {
		return {
			listtestquestions: []
		};
	},
	created() {
		let _This = this;

		_This.GetAllTestQuestions(_This.ModelTest.Id);
	},
	methods: {
		// Получить список всех вопросов.
		GetAllQuestions(Filter) {
			
		},

		// Получить список всех вопросов для теста.
		GetAllTestQuestions(IdTest) {
			let _This = this;

			_This.listtestquestions = [];

			Proxy.GetListQuestionForTest(
				{ Id: IdTest },
				Data => {
					_This.listtestquestions = Data;
				},
				Error => {
					_This.ShowMessage("Ошибка <Proxy.GetListQuestionForTest>: " + Error);
				}
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
					_This.GetAllTestQuestions(_This.ModelTest.Id);
				},
				Error => {
					_This.ShowMessage("Ошибка <Proxy.RemoveQuesion>: " + Error);
				}
			);
		},

		// Отобразить сообщение.
		ShowMessage(Text, Type) {
			let _This = this;

			_This.storage.DegubText = Text;
			console.log(Text);
		}
	}
};