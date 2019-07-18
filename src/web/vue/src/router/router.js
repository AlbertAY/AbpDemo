    
// 引入路由模块并使用它
import Vue from 'vue'
import VueRouter from 'vue-router'
import index from '../views/signalr/sender.vue'

Vue.use(VueRouter)

// 创建路由实例并配置路由映射  
const router = new VueRouter({
    routes: [{
            path: '/',
            component: index,
        }
       
    ]
})
// 输出router
export default router;