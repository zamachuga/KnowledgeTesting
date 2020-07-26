class ClassSettingsGlobal {
	constructor(){
		this.m_UrlApi = "http://localhost:57735/";
		this.m_IsDebug = true;
	}

	// Базовый URL к Api.
	get UrlApi() {
		return this.m_UrlApi;
	}
	// True - включить режим отладки приложения.
	get IsDebug(){
		return this.m_IsDebug;
	}
}

let SettingsGlobal = new ClassSettingsGlobal();

export default {
	Global: SettingsGlobal
};