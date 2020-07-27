import Proxy from './api-proxy.js';
import ComponentTest from './Test/test-component.vue';
import ComponentTestQuestions from './TestQuestions/TestQuestions-component.vue';

export default {
	name: 'TestManagement',
	props: ['storage'],
	data() {
		return {
			// Текущий компонент.
			CurrentComponent: {
				Component: null,
				Action: null
			},
			// Модель теста с которой работаем на текущий момент.
			// Представление "TestView".
			ModelTest: {
				Id: null,
				Name: null,
				Description: null
			},
			// Список существующих тестов.
			listtests: []
		};
	},
	created() {
		this.GetListTests();
	},
	methods: {
		// Перейти к Управление вопросами.
		GoTestQuestionsView(IdTest) {
			let _This = this;

			Proxy.GetTest(
				{ Id: IdTest },
				Data => {
					_This.ModelTest.Id = Data.Id;
					_This.ModelTest.Name = Data.Name;
					_This.ModelTest.Description = Data.Description;

					_This.CurrentComponent.Component = ComponentTestQuestions;
					_This.CurrentComponent.Action = null;
				},
				Error => {
					_This.ShowMessage("Ошибка <Proxy.GetTest>: " + Error);
				}
			);
		},

		// Перейти к Создать тест.
		GoCreateTest() {
			let _This = this;
			
			_This.ModelTest.Id = null;
			_This.ModelTest.Name = null;
			_This.ModelTest.Description = null;

			_This.CurrentComponent.Component = 'ComponentTest';
			_This.CurrentComponent.Action = 'Create';
		},

		// Перейти к Редактировать тест.
		GoEditTest(IdTest) {
			let _This = this;
			
			Proxy.GetTest(
				{ Id: IdTest },
				Data => {
					_This.ModelTest.Id = Data.Id;
					_This.ModelTest.Name = Data.Name;
					_This.ModelTest.Description = Data.Description;

					_This.CurrentComponent.Component = ComponentTest;
					_This.CurrentComponent.Action = 'Edit';
				},
				Error => {
					_This.ShowMessage("Ошибка <Proxy.GetTest>: " + Error);
				}
			);
		},

		// Удалить тест.
		RemoveTest(IdTest) {
			let _This = this;

			_This.ShowMessage("Удалить тест #" + IdTest);
		},

		// Получить список тестов.
		GetListTests() {
			let _This = this;

			Proxy.GetAllTests(
				null,
				Data => {
					_This.listtests = Data;
				},
				Error => {
					_This.ShowMessage("Ошибка <Proxy.GetAllTests>: " + Error);
				}
			);
		},

		// Отобразить сообщение.
		ShowMessage(Text, Type) {
			let _This = this;
			_This.storage.DegubText = Text;
			console.log(Text);
		},

		// Скрыть дочерний компонент.
		HideChildComponent(){
			let _This = this;
			
			_This.CurrentComponent.Component = null;
		}
	},
	components: {
		ComponentTest,
		ComponentTestQuestions
	}
};