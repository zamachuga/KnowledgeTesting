import Vue from 'vue';

// Экземпляр Vue для создания глобальной шины событий.
// Используется как глобальный объект живущий на сессии сервера
// с которым можно работать стандартным языком js.
const m_Bus = new Vue();

export default{
	Bus: m_Bus
};