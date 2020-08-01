import Proxy from './api-proxy.js';
import ComponentInterviwee from '../Interviwee/Interviwee-component.vue';
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
			}
		};
	},
	created() {
		this.storage.Bus.$on('EventAuth', this.EventAuth);
		this.storage.Bus.$on('EventLogOut', this.EventLogOut);
	},
	computed: {
		// Кто проходит тестирование 
		// (ComponentInterviwee).
		Interviewee() {
			return this.storage.Interviewee;
		}
	},
	methods: {
		EventAuth(EventData) {
			this.storage.Interviewee = EventData;
		},

		EventLogOut() {
			this.storage.Interviewee = null;
		}
	},
	components: {
		ComponentInterviwee,
		ComponentTestingProcess
	}
};