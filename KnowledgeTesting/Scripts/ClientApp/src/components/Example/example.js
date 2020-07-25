import ApiProxy from './api-proxy.js';

export default {
	name: '',
	props: ["storage"],
	data() {
		return {
			UserAuthDataRequestModel: {
				username: null
			}
		};
	},
	methods: {
		// Общее событие для всех.
		OnClick(e) {
			let _This = this;
			console.clear();
		},
		// Выполнить аутентификацию.
		OnLogin(e) {
			let _This = this;
			_This.OnClick(e);

			// Вход в систему.
			ApiProxy.LogIn(
				_This.UserAuthDataRequestModel,
				Data => {
					//_This.globalarray.IsAuth = true;
					_This.$router.push('/');
				},
				Err => {
					console.log(Err);
				}
			);
		}
	}
};