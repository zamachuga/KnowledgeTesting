// Модуль маршрутизации. Описывает маршруты (подстроки адреса URL приложения),
// поддерживаемые приложением. При наборе адреса в строке адреса браузера
// приложение включит соответствующий компонент в месте расположения тэга
// <router-view></router-view> (компонент "app.vue").

import Vue from 'vue';
import VueRouter from 'vue-router';
import ComponentHome from './components/Home/home-component.vue';
import ComponentTestManagement from './components/TestManagement/TestManagement-component.vue';
import ComponentTesting from './components/Testing/Testing-component.vue';

Vue.use(VueRouter);

export default new VueRouter({
	routes: [
		{ path: '/', name: 'Home', component: ComponentHome },
		{ path: '/TestManagement', name: 'ComponentTestManagement', component: ComponentTestManagement },
		{ path: '/Testing', name: 'ComponentTesting', component: ComponentTesting }
	]
});