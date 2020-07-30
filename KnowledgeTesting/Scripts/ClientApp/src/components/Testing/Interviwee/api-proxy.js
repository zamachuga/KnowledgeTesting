import Proxy from './api-proxy.js';

export default {
	name: 'Testing',
	props: ['storage'],
	data() {
		return {
			// Текущий компонент.
			CurrentComponent: {
				// Какой подчиненный компонент необходимо отобразить.
				// null - главный компонент.
				Component: null,
				// Действие ожидаемое от Component.
				Action: null,
				// Содержит объект параметров для Component.
				Parameters: null
			}
		};
	}
};