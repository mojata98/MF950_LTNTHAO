import Vue from 'vue'
import App from './App.vue'
import axios from 'axios'
import VueAxios from 'vue-axios'
import money from 'v-money'
// import moment from 'moment'
Vue.use(VueAxios, axios)
Vue.config.productionTip = false

new Vue({
  render: h => h(App),
}).$mount('#app')

var moment = require('moment');
Vue.filter('myDate', function(created) {
    return moment(created).format('DD/MM/YYYY');
});
// Vue.use(moment)
Vue.filter('mymoney', function(created) {
  return money(created, {precision: 2});
});