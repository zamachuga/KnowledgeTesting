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
		// Получить следующий вопрос.
		GetNextQuestion(){

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