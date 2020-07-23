import Axios from 'axios';
import Settings from '../configs/settings.js';

class ClassServiceAxios {
	constructor() {
		// Стандартный запрос к WebApi.
		this.m_Api = Axios.create({
			headers: { "Content-Type": "application/json" }
		});
		// Запрос к WebApi для OAuth.
		this.m_ApiOAuth = Axios.create({
			headers: { "Content-Type": "application/x-www-form-urlencoded" }
		});
	}

	// Выполнить стаднартный запрос WebApi.
	PostApi(Controller, Action, Request, Try, Cath) {
		let _URL = Settings.Global.URL + Controller + '/' + Action;

		return this.m_Api
			// POST запрос.
			.post(_URL, Request, { withCredentials: false })
			// Выполнить обработчик содержимого ответа.
			.then(response => { if (Try) Try(response.data); })
			// Выполнить обработчик ошибки.
			.catch(err => { if (Cath) Cath(err); })
			;
	}
}

let ServiceAxios = new ClassServiceAxios();

export default {
	ServiceAxios
}