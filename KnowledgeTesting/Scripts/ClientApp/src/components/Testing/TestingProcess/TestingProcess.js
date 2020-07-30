import Proxy from './api-proxy.js';

export default {
	name: 'ComponentTestingProcess',
	props: ['storage', 'Interviewee'],
	data() {
		return {
			// Выбранный тест для прохождения.
			SelectedTestId: null,
			// Список всех тестов.
			ListTests:[]
		};
	}
};