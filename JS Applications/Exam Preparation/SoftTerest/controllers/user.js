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
                setTimeout(() => document.getElementById('successBox').style.display = 'block', 250);
                    setTimeout(() => document.getElementById('successBox').style.display = 'none', 3000);
                    setTimeout(()=>context.redirect('#/home'), 100) 
            })
        },
        profile(context) {
            let userId = localStorage.getItem('userId');
            let ideaNames = [];
            models.dashboard.getAll().then((res) => {
                let ideas = res.docs.map(docModifier);
                Array.from(ideas).forEach(x => {
                    if (x.uid === userId) {
                        ideaNames.push(x);
                    }

                })
                context.ideas = ideaNames;
                context.ideasCount = ideaNames.length;
                extend(context).then(function () {
                    this.partial("../views/user/profile.hbs")
                });
            });
        }
    },
    post: {
        login(context) {
            let {
                username,
                password
            } = context.params;
            models.user.login(username, password)
                .then((res) => {

                    context.username = res.user.email;
                    context.isLoggedIn = true;
                    displaySuccess();
                    
                    setTimeout(context.redirect('#/home'), 5000);
                })
                .catch(err => console.error(err))

        },
        register(context) {
            let {
                username,
                password,
                repeatPassword
            } = context.params;

            if (password === repeatPassword && password.length >= 6) {
                models.user.register(username, password)
                    .then((res) => {
                        displaySuccess();
                        setTimeout(()=>context.redirect('#/home'), 100) 
                    })
                    .catch(err => console.error(err))
            } else {
                context.redirect('#/user/register')
                displayError();
            }
        },
    }
}