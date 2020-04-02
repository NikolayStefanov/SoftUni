import models from "../models/index.js"
import extend from "../utils/helperFunc.js";
export default {
    get: {
        login(context){
            extend(context).then(function(){
                this.partial("../views/user/login.hbs")
            })

        },
        register(context){
            extend(context).then(function(){
                this.partial("../views/user/register.hbs")
            })

        },
        logout(context){
            models.user.logout().then(x=>{
                context.redirect('#/home')
            })
        }
    },
    post: {
        login(context){
            let {username, password} = context.params;
            models.user.login(username, password)
            .then((res)=>{
                
                context.username = res.user.email;
                context.isLoggedIn= true;
                context.redirect('#/home')
            })
            .catch(err=> console.error(err))
            
        },
        register(context){
            let {username, password, rePassword} = context.params;
            if (password === rePassword) {
                models.user.register(username, password)
                .then(
                    context.redirect('#/user/login')
                )
                .catch(err=>console.error(err))
            }
        },
        
        
    }
}