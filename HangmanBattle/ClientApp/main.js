import Vue from "vue";
import VueSignalR from '@latelier/vue-signalr'

import App from "./App.vue";

Vue.use(VueSignalR, '/chathub');

var app = new Vue({
    render: h => h(App),
    
    created() {
        this.$socket.start({
            log: true // Active only in development for debugging.
        });
    },
});

app.$mount('#app');