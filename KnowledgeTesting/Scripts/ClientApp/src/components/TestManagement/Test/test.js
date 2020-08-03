import Proxy from './api-proxy.js';

export default {
	name: "Test",
	props: ['ModelTest', 'CurrentComponent'],
	methods: {
		// Создать тест.
		CreateTest() {
			let _This = this;

			Proxy.CreateTest(
				_This.ModelTest,
				Data => {
					_This.$emit('IsChanged');
					_This.$emit('HideChildComponent');
				},
				Error => {
					_This.ShowMessage("Ошибка <Proxy.CreateTest>: " + Error);
				}
			);			
		},

		// Сохранить изменения теста.
		SaveChangeTest() {
			let _This = this;

			Proxy.SaveChangeTest(
				_This.ModelTest,
				Data => {
					_This.$emit('IsChanged');
					_This.$emit('HideChildComponent');
				},
				Error => {
					_This.ShowMessage("Ошибка <Proxy.SaveChangeTest>: " + Error);
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