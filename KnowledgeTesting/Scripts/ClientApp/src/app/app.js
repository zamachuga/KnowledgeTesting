// Сервисы.
import Services from '../services/Services.js';
// Настройки.
import Settings from '../configs/settings.js';
// Компоненты.
import ComponentHome from '../components/Home/home-component.vue';
import ComponentExample from '../components/Example/example-component.vue';
import ComponentNavi from '../components/Navi/navi-component.vue';

export default {
	name: 'app',
	data() {
		return {
			// Хранилищей передающееся между компонентами.
			storage: {
				// Сообщение отладки.
				DegubText: null,
				// Общие настройки приложения.
				Settings: null,
				// Шина данных.
				Bus: null
			}
		};
	},
	created() {
		this.storage.Bus = Services.Bus;
		this.storage.Settings = Settings.Global;
	},
	methods:{
		ClearErrors(){
			this.storage.DegubText = null;
		}
	},
	components: {
		ComponentHome,
		ComponentExample,
		ComponentNavi
	}
};