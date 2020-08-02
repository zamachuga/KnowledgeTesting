import VueApexCharts from 'vue-apexcharts';
import ComponentInterviwee from '../Interviwee/Interviwee-component.vue';
import Proxy from './api-proxy.js';

export default {
	name: 'ComponentStatistic',
	props: ['storage'],
	data() {
		return {
			IsViewChart: true,
			// Выбранный тест для прохождения.
			SelectedTestId: null,
			// Количество раз пройден выбранный тест.
			CountCompleteSelectedTest: null,
			// Список всех тестов.
			ListTests: [],
			// Шаблон данных для диаграммы.
			Chart: {
				type: "bar",
				chartOptions: {
					chart: {
						id: 'ChartTestStatistic'
					},
					xaxis: {
						// Вопросы
						categories: []
					},
					colors: ['#4CAF50', '#D7263D']
				},
				series: [
					{
						name: 'Правильно',
						data: []
					},
					{
						name: 'Неправильно',
						data: []
					},
				]
			},
			// Кто проходит тестирование 
			// (ComponentInterviwee).
			Interviewee: this.storage.Interviewee
		};
	},
	created() {
		this.storage.Bus.$on('EventAuth', this.EventAuth);
		this.storage.Bus.$on('EventLogOut', this.EventLogOut);
	},
	methods: {
		// Получить статистику прохождения теста.
		GetStatisticTest() {
			let _This = this;
			_This.IsViewChart = false;

			Proxy.GetStatisticTest(
				{
					InterviweeId: _This.Interviewee.Id,
					TestId: _This.SelectedTestId
				},
				Data => {
					// Количество раз пройден тест.
					_This.CountCompleteSelectedTest = Data.CountComplete;

					// Вопросы.
					_This.Chart.chartOptions.xaxis.categories = Data.ArrayData[0];

					// Правильные ответы.
					_This.Chart.series[0].data = Data.ArrayData[1];

					// Неправильные ответы.
					_This.Chart.series[1].data = Data.ArrayData[2];

					_This.IsViewChart = true;
				},
				Error => {
					//
				}
			);
		},

		// Получить список тестов тестируемого.
		GetTestsInterviwee() {
			let _This = this;

			Proxy.GetTestsInterviwee(
				_This.storage.Interviewee,
				Data => {
					_This.ListTests = Data;
					if (SelectedTestId) {
						_This.GetStatisticTest();
					}
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