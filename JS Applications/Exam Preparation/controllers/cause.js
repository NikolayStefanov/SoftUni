import extend from "../utils/helperFunc.js"
import models from "../models/index.js"
import docModifier from "../utils/docModifier.js"
export default {
    get: {
        create(context) {
            extend(context).then(function () {
                this.partial("../views/cause/create.hbs")
            })
        },
        dashboard(context) {
            models.cause.getAll().then((response) => {
                let causes = response.docs.map(docModifier);
                
                context.causes = causes
                extend(context).then(function () {
                    this.partial("../views/cause/dashboard.hbs")
                })
            })
        },
        details(context) {
            let {
                causeId
            } = context.params;
            models.cause.get(causeId).then((res) => {
                
                let cause = docModifier(res)
                context.cause = cause;

                Object.entries(cause).forEach(([key, value])=>{
                    context[key] = value;
                })
                context.canDonate = cause.uid !== localStorage.getItem('userId')

                extend(context).then(function () {
                    this.partial("../views/cause/details.hbs")
                })

            }).catch((e) => console.error(e))


        },
        

    },
    post: {
        create(context) {
            let data = {
                ...context.params,
                collectedFunds: 0,
                donors: [],
                uid: localStorage.getItem('userId')
            }

            models.cause.create(data).then((res) => {
                    context.redirect('#/causes/dashboard')

                })
                .catch(err => console.error(err))
        },
    },
    del:{
        close(context){
            let {causeId} = context.params
            models.cause.close(causeId).then((res)=>{
                context.redirect('#/causes/dashboard')
            })
            
        }
    },
    put:{
        donate(context){
            let {currentDonation, causeId} = context.params;
            models.cause.get(causeId).then((res)=>{
                let data = docModifier(res);
                data.collectedFunds += +(currentDonation)
                let donorEmail = localStorage.getItem('userEmail')
                data.donors.push(donorEmail);                
                models.cause.donate(data).then((res)=>{
                    context.redirect('#/causes/dashboard')
                    
                })
            })
            
        }
    }
}
