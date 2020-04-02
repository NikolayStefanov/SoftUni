import extend from "../utils/helperFunc.js"

export default {
    get:{
            home(context){
                extend(context).then(function(){
                    this.partial("../views/home/home.hbs")
                })
            }
    }

}