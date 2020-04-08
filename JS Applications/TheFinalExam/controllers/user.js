import models from "../models/index.js";
import extend from "../utils/helperFunc.js";
import docModifier from "../utils/docModifier.js";
import {displayError, displaySuccess} from "../utils/notifications.js";
export default {
    get: {
        login(context) {
            extend(context).then(function () {
                this.partial("../views/user/login.hbs")
            })

        },
        register(context) {
            extend(context).then(function () {
                this.partial("../views/user/register.hbs")
            })

        },
        logout(context) {
            models.user.logout().then(x => {
                    setTimeout(()=>context.redirect('#/user/register'), 100) 
            })
        },
    },
    post: {
        login(context) {
            let {
                email,
                password
            } = context.params;
            models.user.login(email, password)
                .then((res) => {

                    context.username = res.user.email;
                    context.isLoggedIn = true;
                    
                    context.redirect('#/home');
                })
                .catch(err => console.error(err))

        },
        register(context) {
            let {
                email,
                password,
                rePass
            } = context.params;
            
             if (password === rePass) {
                 models.user.register(email, password)
                     .then((res) => {
                         context.redirect('#/home');
                     })
                     .catch(err => console.error(err))
             } else {
                 context.redirect('#/user/register')
             }
        },
    }
}