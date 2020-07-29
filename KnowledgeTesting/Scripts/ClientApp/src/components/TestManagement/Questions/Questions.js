import Proxy from './api-proxy.js';
import ComponentQuestion from '../Question/Question-component.vue';

export default {
	name: "Questions",
	props: ['CurrentComponent', 'storage'],
	data() {
		return {
			// Модель ответа на вопрос.
			ModelQuestionAnswer: {
				QuestionId: 0,
				AnswerId: 0,
				AnswerText: null,
				IsCorrect: false
			},
			// Список всех вопросов.
			ListQuestions: [],
			// Список ответов для добавления.
			ListAnswers: [],
			// Выбранный ответ для добавления.
			SelectedAnswerToAdd: null,
			// Текст нового ответа.
			TextNewAnswer: null
		};
	},
	created() {
		this.GetAllQuestions();
	},
	methods: {
		// Создать новый вопрос.
		CreateQuestion(Text) {
			let _This = this;

			Proxy.CreateQuestion(
				{Id: null, Text: Text},
				Data => _This.GetAllQuestions(),
				Error => _This.GetAllQuestions()
			);
		},

		// Редактировать вопрос.
		EditQuestion(EventData) {
			let _This = this;

			Proxy.EditQuestion(
				{Id: EventData.QuestionId, Text: EventData.QuestionText},
				Data => _This.GetAllQuestions(),
				Error => _This.GetAllQuestions()
			);
		},

		// Перейти к Создание нового вопроса.
		GoCreateQuestion() {
			let _This = this;

			// Какой подчиненный компонент необходимо отобразить.
			// null - главный компонент.
			_This.CurrentComponent.Component = ComponentQuestion;
			// Регистрируем ожидаемое событие на шине.
			_This.storage.Bus.$on("ActionQuestionCreate", _This.CreateQuestion);
			// Действие ожидаемое от Component.
			_This.CurrentComponent.Action = 'Create';
			// Содержит объект параметров для Component.
			_This.CurrentComponent.Parameters = { PrevComponent: 'ComponentQuestions' };
		},

		// Перейти к Редактирование вопроса.
		GoEditQuestion(QuestionId, QuestionText) {
			let _This = this;

			// Какой подчиненный компонент необходимо отобразить.
			// null - главный компонент.
			_This.CurrentComponent.Component = ComponentQuestion;
			// Регистрируем ожидаемое событие на шине.
			_This.storage.Bus.$on("ActionQuestionEdit", _This.EditQuestion);
			// Действие ожидаемое от Component.
			_This.CurrentComponent.Action = 'Edit';
			// Содержит объект параметров для Component.
			_This.CurrentComponent.Parameters = {
				PrevComponent: 'ComponentQuestions',
				QuestionId: QuestionId,
				QuestionText: QuestionText
			};
		},

		// Создать ответ и добавить в вопрос.
		CreateAnswerToQuestion(QuestionId, AnswerText) {
			let _This = this;

			Proxy.CreateAnswerToQuestion(
				{
					QuestionId: QuestionId,
					AnswerText: AnswerText
				},
				Data => _This.GetAllQuestions(),
				Error => _This.GetAllQuestions()
			);
		},

		// Добавить ответ в вопрос.
		AddAnswerToQuestion(QuestionId, AnswerId) {
			let _This = this;

			Proxy.AddAnswerToQuestion(
				{
					QuestionId: QuestionId,
					AnswerId: AnswerId
				},
				Data => _This.GetAllQuestions(),
				Error => _This.GetAllQuestions()
			);
		},

		// Получить список вопросов для выбора.
		GetAllAnswers() {
			let _This = this;

			Proxy.GetAllAnswers(
				null,
				Data => {
					_This.ListAnswers = Data;
				},
				Error => { }
			);
		},

		// Удалить ответ.
		RemoveAnswer(QuestionId, AnswerId) {
			let _This = this;

			Proxy.RemoveAnswerFromQuestion(
				{
					QuestionId: QuestionId,
					AnswerId: AnswerId
				},
				Data => _This.GetAllQuestions(),
				Error => _This.GetAllQuestions()
			);
		},

		// Выбрать правильный ответ.
		SetCorrectAnswer(QuestionId, AnswerId) {
			let _This = this;

			_This.ModelQuestionAnswer.QuestionId = QuestionId;
			_This.ModelQuestionAnswer.AnswerId = AnswerId;

			Proxy.SetCorrectAnswer(
				_This.ModelQuestionAnswer,
				Data => _This.GetAllQuestions(),
				Error => _This.GetAllQuestions()
			);
		},

		// Получить список всех вопросов.
		GetAllQuestions() {
			let _This = this;
			_This.ListQuestions = [];

			Proxy.GetAllQuestions(
				{ FilterName: null },
				Data => {
					_This.ListQuestions = Data;
					// Вроде обошлось, похоже была проблема в том, что вместо data, было написано Data,
					// а при переводе в код страницы некоторые слова переводятся в нижний регистр 
					// построителем страниц и особенностями JavaScript.
					//_This.$forceUpdate();
				},
				Error => { }
			);
		}
	},
	components: {
		ComponentQuestion
	}
};