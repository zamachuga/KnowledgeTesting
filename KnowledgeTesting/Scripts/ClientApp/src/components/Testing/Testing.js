import Proxy from './api-proxy.js';
import ComponentInterviwee from './Interviwee/Interviwee-component.vue';
import ComponentTestingProcess from './TestingProcess/TestingProcess-component.vue';

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
			},
			// Кто проходит тестирование 
			// (ComponentInterviwee).
			Interviewee: null
		};
	},
	components: {
		ComponentInterviwee,
		ComponentTestingProcess
	}
};