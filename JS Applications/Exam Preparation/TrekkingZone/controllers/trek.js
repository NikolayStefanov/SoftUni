import extend from "../utils/helperFunc.js"
import models from "../models/index.js"
import docModifier from "../utils/docModifier.js"
export default {
    get: {
        create(context) {
            models.trek.getAll().then((response) => {
                let treks = response.docs.map(docModifier);
                context.treks = treks;
                extend(context).then(function () {
                    this.partial("../views/trek/createTrek.hbs")
                })
            })

        },
        trekHome(context) {
            models.trek.getAll().then((response) => {
               


                context.treks = treks
                extend(context).then(function () {
                    this.partial("../views/home/loginHomePage.hbs")
                })
            })
        },
        details(context) {
            let {
                trekId
            } = context.params;

            models.trek.get(trekId).then((res) => {

                let trek = docModifier(res)
                context.trek = trek;
                
               Object.entries(trek).forEach(([key, value]) => {
                   context[key] = value;
               })
               context.canEdit = trek.uid === localStorage.getItem('userId')

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
                organizer: localStorage.getItem('userEmail'),
                likes: 0,
                uid: localStorage.getItem('userId')
            }

            models.trek.create(data).then((res) => {
                    context.redirect('#/loginHome')

                })
                .catch(err => console.error(err))
        },
    },
    del: {
        close(context) {
            let {
                trekId
            } = context.params
            models.trek.close(trekId).then((res) => {
                context.redirect('#/loginHome')
            })

        }
    },
    put: {
        like(context) {
            let {
                trekId
            } = context.params;

            
           models.trek.get(trekId).then((res) => {
               let data = docModifier(res);
               data.likes++;
               models.trek.edit(data).then((res) => {
                  context.redirect(`/#/trek/details/${data.id}`)
               })
           })
        },
        edit(context){
            let{location, dateTime, description,imageURL,trekId } = context.params;
            models.trek.get(trekId).then((res)=>{
                let data =docModifier(res);
                data.location = location;
                data.dateTime = dateTime;
                data.description = description;
                data.imageURL = imageURL;
                models.trek.edit(data).then((res)=>{
                    context.redirect("#/loginHome")
                })
                
            })
            
        }
    }
}