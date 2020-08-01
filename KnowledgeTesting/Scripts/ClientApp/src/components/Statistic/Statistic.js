import VueApexCharts from 'vue-apexcharts'
import ChartExample from './Charts/Example.js';

export default {
	name: 'ComponentStatistic',
	props: ['storage'],
	data() {
		return {
			chartOptions: ChartExample.chartOptions,
			series: ChartExample.series,
			type: ChartExample.type
		}
	},
	components: {
		apexcharts: VueApexCharts
	}
}