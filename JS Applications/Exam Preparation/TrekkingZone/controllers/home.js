import extend from "../utils/helperFunc.js"
import models from  "../models/index.js"
import docModifier from "../utils/docModifier.js"

export default {
    get:{
            home(context){
                extend(context).then(function(){
                    this.partial("../views/home/home.hbs")
                })
            },
            loginHome(context){
                models.trek.getAll().then((response) => {
                    let treks = response.docs.map(docModifier);
                    
                    if (treks.length>0) {
                        context.thereIsTreks = true;
                        context.treks = treks;
                    }else{
                        context.thereIsTreks = false;
                    }
                    extend(context).then(function(){
                        this.partial("../views/home/loginHomePage.hbs")
                    })
                })
                
            }
    }

}