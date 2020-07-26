class ClassSettingsGlobal {
	// Базовый URL к Api.
	get UrlApi() {
		return 'http://localhost:57735/';
	}
	// True - включить режим отладки приложения.
	get IsDebug(){
		return true;
	}
}

let SettingsGlobal = new ClassSettingsGlobal();

export default {
	Global: SettingsGlobal
};