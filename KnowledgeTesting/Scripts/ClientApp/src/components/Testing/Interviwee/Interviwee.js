import Proxy from './api-proxy.js';

export default {
	name: 'ComponentInterviewee',
	props: ['Interviewee', 'storage'],
	data() {
		return {
			FIO: {
				// Регистрационный код.
				Id: null,
				// Ф
				LastName: "",
				// И
				FirstName: "",
				// О
				SecondName: "",
				Clear() {
					this.Id = null;
					this.LastName = "";
					this.FirstName = "";
					this.SecondName = "";
				}
			}
		};
	},
	methods: {
		Auth() {
			let _This = this;

			Proxy.Auth(
				{
					Id: _This.FIO.Id,
					LastName: _This.FIO.LastName,
					FirstName: _This.FIO.FirstName,
					SecondName: _This.FIO.SecondName,
				},
				Data => {
					if (Data.Id > 0)
						_This.storage.Bus.$emit('EventAuth', Data);
				},
				Error => {

				}
			);
		},

		LogOut() {
			this.FIO.Clear();
			this.storage.Bus.$emit('EventLogOut');
		}
	}
};