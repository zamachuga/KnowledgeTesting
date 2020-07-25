// Сервисы.
//import Services from '../services/Services.js';
// Компоненты.
import ComponentHome from '../components/Home/home-component.vue';
//import ComponentExample from '../components/Example/example-component.vue';
import ComponentNavi from '../components/Navi/navi-component.vue';

export default {
	name: 'app',
	data() {
		return {
			// Хранилищей передающееся между компонентами.
			storage: {
				// Шина данных.
				Bus: null,
				// Тестовые данные.
				TextTest: 'Test text'
			}
		};
	},
	created(){
		//this.storage.Bus = Services.Bus;
	},
	components:{
		ComponentHome,
		//ComponentExample,
		ComponentNavi
	}
};