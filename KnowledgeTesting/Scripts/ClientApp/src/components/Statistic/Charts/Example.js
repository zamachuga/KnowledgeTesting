export default {
	type: "bar",
	chartOptions: {
		chart: {
			id: 'vuechart-example'
		},
		xaxis: {
			categories: [1991, 1992, 1993, 1994, 1995, 1996, 1997, 1998]
		},
		colors: ['#4CAF50', '#D7263D']
	},
	series: [
		{
			name: 'Правильно',
			data: [30, 40, 45, 50, 49, 60, 70, 91]
		},
		{
			name: 'Неправильно',
			data: [30, 40, 45, 50, 49, 60, 70, 91]
		},
	]
};