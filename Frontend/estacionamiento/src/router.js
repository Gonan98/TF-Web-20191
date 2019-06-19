import Vue from 'vue'
import Router from 'vue-router'
import Home from './views/Home.vue'
import Cajero from './components/Cajero.vue'
import Comprobante from './components/Comprobante.vue'
import Espacio from './components/Espacio.vue'
import Estacionamiento from './components/Estacionamiento.vue'
import Ingreso from './components/Ingreso.vue'
import Localizacion from './components/PuntoAtencion.vue'
import Tarifa from './components/Tarifa.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  base: process.env.BASE_URL,
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/about',
      name: 'about',
    },
    {
      path: '/cajeros',
      name: 'cajeros',
      component: Cajero
    },
    {
      path: '/comprobantes',
      name: 'comprobantes',
      component: Comprobante
    },
    {
      path: '/espacios',
      name: 'espacio',
      component: Espacio
    },
    {
      path: '/estacionamiento',
      name: 'estacionamientos',
      component:  Estacionamiento
    },
    {
      path: '/ingresos',
      name: 'ingresos',
      component: Ingreso
    },
    {
      path: '/localizaciones',
      name: 'localizaciones',
      component:  Localizacion
    },
    {
      path: '/punto_atenciones',
      name: 'punto_atenciones',
      component: PuntoAtencion 
    },
    {
      path: '/tarifas',
      name: 'tarifas',
      component: Tarifa
    }
  ]
})
