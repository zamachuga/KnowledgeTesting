export default {
	name: "Question",
	props: ['CurrentComponent', 'storage'],
	data() {
		return {
			QuestionId: null,
			QuestionText: null
		};
	},
	created() {
		let _This = this;

		if (typeof _This.CurrentComponent.Parameters.QuestionId != undefined) {
			_This.QuestionId = _This.CurrentComponent.Parameters.QuestionId;
		}
		if (typeof _This.CurrentComponent.Parameters.QuestionText != undefined) {
			_This.QuestionText = _This.CurrentComponent.Parameters.QuestionText;
		}
	},
	methods: {
		// Событие создать вопрос.
		EventCreate() {
			let _This = this;
			_This.storage.Bus.$emit("ActionQuestionCreate", _This.QuestionText);
			_This.CloseComponent();
		},

		// Событие редактировать вопрос.
		EventEdit() {
			let _This = this;
			
			_This.storage.Bus.$emit(
				"ActionQuestionEdit",
				{
					QuestionId: _This.QuestionId,
					QuestionText: _This.QuestionText
				}
			);
			_This.CloseComponent();
		},

		// Закроем компонент перейдя на предыдущий.
		CloseComponent() {
			let _This = this;
			_This.CurrentComponent.Component = _This.CurrentComponent.Parameters.PrevComponent;
			_This.CurrentComponent.Parameters = null;
		}
	}
};