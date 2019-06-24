import Vue from 'vue'
import './plugins/vuetify'
import App from './App.vue'
import router from './router'
import store from './store'
import 'material-design-icons-iconfont/dist/material-design-icons.css'
import axios from 'axios'

Vue.config.productionTip = false

axios.defaults.baseURL='http://localhost:5000/'

var vm =new Vue({
  router,
  store,
  render: h => h(App)
})
vm.$mount('#app')
