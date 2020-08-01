import Proxy from './api-proxy.js';

export default {
	name: 'ComponentTestingProcess',
	props: ['storage', 'Interviewee'],
	data() {
		return {
			// Выбранный тест для прохождения.
			SelectedTestId: null,
			// Список всех тестов.
			ListTests: [],
			// Состояние прохождения теста.
			InterviweeTest: {
				Id: null,
				InterviweeId: null,
				TestId: null,
				IsComplete: null,
				ProgressText: null,
				CurrentQuestion: {
					Id: null,
					Text: null,
					// Код выбранного ответа на вопрос.
					SelectedAnswerId: null,
					Answers: []
				}
			}
		};
	},
	created() {
		this.storage.Bus.$on('EventAuth', this.EventAuth);
		this.storage.Bus.$on('EventLogOut', this.EventLogOut);
	},
	computed: {
		IsViewButtonNextQuestion() {
			let _This = this;

			let IsView =
				_This.InterviweeTest.Id != null
				& _This.InterviweeTest.InterviweeId != null
				& _This.InterviweeTest.IsComplete == false;

			return IsView;
		}
	},
	methods: {
		EventAuth(EventData) {
			this.ClearInterviweeTest();
			this.GetAllTests();
		},

		EventLogOut() {
			this.ClearInterviweeTest();
		},

		ClearInterviweeTest() {
			this.InterviweeTest.Id = null;
			this.InterviweeTest.InterviweeId = null;
			this.InterviweeTest.TestId = null;
			this.InterviweeTest.IsComplete = null;
			this.InterviweeTest.ProgressText = null;
			this.InterviweeTest.CurrentQuestion.Id = null;
			this.InterviweeTest.CurrentQuestion.Text = null;
			// Код выбранного ответа на вопрос.
			this.InterviweeTest.CurrentQuestion.SelectedAnswerId = null;
			this.InterviweeTest.CurrentQuestion.Answers = []
		},

		// Выход из прохождения теста.
		ExitTesting() {
			this.ClearInterviweeTest();
		},

		// Ответить на вопрос.
		AnswerTheQuestion() {
			let _This = this;

			Proxy.AnswerTheQuestion(
				_This.InterviweeTest,
				Data => {
					_This.InterviweeTest = Data;
				},
				Error => { }
			);
		},

		// Получить следующий вопрос.
		GetNextQuestion() {
			let _This = this;

			Proxy.GetNextQuestion(
				_This.InterviweeTest,
				Data => {
					_This.InterviweeTest = Data;
				},
				Error => { }
			);
		},

		// Получить список всех тестов.
		GetAllTests() {
			let _This = this;

			Proxy.GetAllTests(
				null,
				Data => {
					_This.ListTests = Data
				},
				Error => {

				}
			);
		},

		// Начать прохождение теста.
		StartTest() {
			let _This = this;

			_This.InterviweeTest.InterviweeId = _This.Interviewee.Id;
			_This.InterviweeTest.TestId = _This.SelectedTestId;

			Proxy.StartTest(
				_This.InterviweeTest,
				Data => {
					_This.InterviweeTest = Data;
				},
				Error => {

				}
			);
		}
	}
};