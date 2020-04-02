import models from "../models/index.js"
import extend from "../utils/helperFunc.js";
import docModifier from "../utils/docModifier.js"
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
                context.redirect('#/home')
            })
        },
        profile(context) {
            let userId = localStorage.getItem('userId');
            let treksNames =[];
            models.trek.getAll().then((res) => {
                let treks = res.docs.map(docModifier);
                Array.from(treks).forEach(x=>{
                    if (x.uid === userId) {
                        treksNames.push(x);
                    }
                    
                })
                context.treks = treksNames;
                context.treksCount = treksNames.length;
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
                    context.redirect('#/loginHome')
                })
                .catch(err => console.error(err))

        },
        register(context) {
            let {
                username,
                password,
                rePassword
            } = context.params;
            if (password === rePassword && password.length >= 6) {
                context.fromRegister = true;
                models.user.register(username, password)
                    .then((res)=>{
                        let newEle = document.createElement('p');
                        newEle.textContent = 'Successfully registered user. Please wait 5 seconds:';
                        newEle.style.color = 'white';
                        newEle.style.backgroundColor = 'darkgreen'

                        document.querySelector("#main > form > div:nth-child(6)").appendChild(newEle);
                        setTimeout(function(){context.redirect('#/loginHome')}, 5000) 
                    })
                    .catch(err => console.error(err))
            }else{
                let newEle = document.createElement('p');
                        let messagePlace =document.querySelector("#main > form > div:nth-child(6)")
                        newEle.textContent = 'Incorrect password, repassword or email. Wait a second and try again!';
                        newEle.setAttribute('id', 'incorrectPass')
                        newEle.style.color = 'white';
                        newEle.style.backgroundColor = 'red'
                        messagePlace.appendChild(newEle);

                        setTimeout(function(){context.redirect('#/user/register')}, 3000)
            }
        },
    }
}