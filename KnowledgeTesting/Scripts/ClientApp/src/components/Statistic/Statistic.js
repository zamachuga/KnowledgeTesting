import VueApexCharts from 'vue-apexcharts'
import ChartExample from './Charts/Example.js';
import ComponentInterviwee from '../Interviwee/Interviwee-component.vue';
import Proxy from './api-proxy.js';

export default {
	name: 'ComponentStatistic',
	props: ['storage'],
	data() {
		return {
			// Выбранный тест для прохождения.
			SelectedTestId: null,
			// Список всех тестов.
			ListTests: [],
			// Шаблон данных для диаграммы.
			Chart: {
				chartOptions: ChartExample.chartOptions,
				series: ChartExample.series,
				type: ChartExample.type
			},
			// Кто проходит тестирование 
			// (ComponentInterviwee).
			Interviewee: this.storage.Interviewee
		};
	},
	methods: {
		// Получить статистику прохождения теста.
		GetStatisticTest() {
			let _This = this;

			console.warn("Выбран тест " + _This.SelectedTestId);
		},

		// Получить список тестов тестируемого.
		GetTestsInterviwee() {
			let _This = this;

			Proxy.GetTestsInterviwee(
				_This.storage.Interviewee,
				Data => {
					_This.ListTests = Data
				},
				Error => { }
			);
		}
	},
	components: {
		VueApexCharts,
		ComponentInterviwee
	}
}