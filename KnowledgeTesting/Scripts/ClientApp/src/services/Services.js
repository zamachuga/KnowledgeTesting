import ServiceAxios from './ServiceAxios.js';
import ServiceBus from './ServiceBus.js';

class ClassServices{
	constructor(){
		this.m_ServiceAxios = ServiceAxios.ServiceAxios;
		this.m_ServiceBus = ServiceBus.Bus;
	}

	get Bus(){return this.m_ServiceBus;}
	get GetServiceAxios(){return this.m_ServiceAxios;}
}

let m_Services = new ClassServices();

export default{
	Axios: m_Services.GetServiceAxios,
	Bus: m_Services.Bus
}