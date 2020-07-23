// Сервисы.
import Services from '../services/Services.js';
// Компоненты.
import ComponentHome from '../components/Home/home-component.vue';
import ComponentExample from '../components/Example/example-component.vue';

export default {
	name: 'app',
	data() {
		return {
			store: {
				Bus: null
			}
		};
	},
	created(){
		this.store.Bus = Services.Bus;
	},
	components:{
		ComponentHome,
		ComponentExample
	}
};