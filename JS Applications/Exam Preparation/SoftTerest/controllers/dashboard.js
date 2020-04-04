import extend from "../utils/helperFunc.js"
import models from "../models/index.js"
import docModifier from "../utils/docModifier.js"
export default {
    get: {
        create(context) {
            models.dashboard.getAll().then((response) => {
                let ideas = response.docs.map(docModifier);
                context.ideas = ideas;
                extend(context).then(function () {
                    this.partial("../views/trek/create.hbs")
                })
            })

        },
        dashboard(context) {
            models.dashboard.getAll().then((response) => {
                let ideas = response.docs.map(docModifier);
                context.ideas = ideas;
                extend(context).then(function () {
                    this.partial("../views/trek/dashboard.hbs")
                })
            })
        },
        details(context) {
            let {
                ideaId
            } = context.params;

            models.dashboard.get(ideaId).then((res) => {

                let idea = docModifier(res)
                context.idea = idea;
                
               Object.entries(idea).forEach(([key, value]) => {
                   context[key] = value;
               })
               context.canDelete = idea.uid === localStorage.getItem('userId')

               extend(context).then(function () {
                   this.partial("../views/trek/details.hbs")
               })

            }).catch((e) => console.error(e))
        },
        edit(context){
            let {
                trekId
            } = context.params;
            models.trek.get(trekId).then((res)=>{
                let trek = docModifier(res);
                context.trek = trek;
                Object.entries(trek).forEach(([key, value]) => {
                    context[key] = value;
                })
                
                extend(context).then(function () {
                    this.partial("../views/trek/editTrek.hbs")
                })
            }).catch((e) => console.error(e))
        }


    },
    post: {
        create(context) {

            let data = {
                ...context.params,
                creator: localStorage.getItem('userEmail'),
                likes: 0,
                comments: [],
                uid: localStorage.getItem('userId')
            }
            
            models.dashboard.create(data).then((res) => {
                    context.redirect('#/dashboard')
                })
                .catch(err => console.error(err))
        },
    },
    del: {
        close(context) {
            let {
                ideaId
            } = context.params
            models.dashboard.close(ideaId).then((res) => {
                context.redirect('#/dashboard')
            })

        }
    },
    put: {
        like(context) {
            let {
                ideaId
            } = context.params;

            
           models.dashboard.get(ideaId).then((res) => {
               let data = docModifier(res);
               data.likes++;
               models.dashboard.edit(data).then((res) => {
                  context.redirect(`/#/dashboard/details/${data.id}`)
               })
           })
        },
        edit(context){
            let {newComment, ideaId} = context.params;
            let currUser = localStorage.getItem('userEmail')
            let finalComent = `${currUser}: ${newComment}`;
             models.dashboard.get(ideaId).then((res)=>{
                 let data =docModifier(res);
                 data.comments.push(finalComent);
                 models.dashboard.edit(data).then((res)=>{
                     context.redirect(`/#/dashboard/details/${data.id}`)
                 })
              
             })
            
        }
    }
}