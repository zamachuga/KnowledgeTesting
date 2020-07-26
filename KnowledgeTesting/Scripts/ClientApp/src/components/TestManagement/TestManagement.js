import Proxy from './api-proxy.js';

export default {
	name: 'TestManagement',
	props: ['storage'],
	data() {
		return {
			IsTestView: false,
			IsCreateTest: false,
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
		// Создать тест.
		CreateTest(){
			let _This = this;

			Proxy.CreateTest(
				_This.ModelTest,
				Data => {					
					_This.IsTestView = false;
					_This.GetListTests();
				},
				Error => {
					_This.ShowMessage("Ошибка <Proxy.CreateTest>: " + Error);
				}
			);
		},

		// Сохранить изменения теста.
		SaveChangeTest(){
			let _This = this;

			Proxy.SaveChangeTest(
				_This.ModelTest,
				Data => {					
					_This.IsTestView = false;
					_This.GetListTests();
				},
				Error => {
					_This.ShowMessage("Ошибка <Proxy.SaveChangeTest>: " + Error);
				}
			);
		},

		// Отменить изменения.
		CancelChangeTest() {
			let _This = this;

			_This.ModelTest.Id = null;
			_This.ModelTest.Name = null;
			_This.ModelTest.Description = null;

			_This.IsTestView = false;
			_This.GetListTests();
		},

		// Создать тест.
		GoCreateTest() {
			let _This = this;

			_This.ModelTest.Id = "";
			_This.ModelTest.Name = "";
			_This.ModelTest.Description = "";

			_This.IsTestView = true;
			_This.IsCreateTest = true;
		},

		// Редактировать тест.
		GoEditTest(IdTest) {
			let _This = this;

			Proxy.GetTest(
				{ Id: IdTest },
				Data => {
					_This.ModelTest.Id = Data.Id;
					_This.ModelTest.Name = Data.Name;
					_This.ModelTest.Description = Data.Description;
				},
				Error => {
					_This.ShowMessage("Ошибка <Proxy.GetTest>: " + Error);
				}
			);

			_This.IsTestView = true;
			_This.IsCreateTest = false;
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
		}
	}
};