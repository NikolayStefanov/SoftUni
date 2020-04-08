import extend from "../utils/helperFunc.js"
import models from  "../models/index.js"
import docModifier from "../utils/docModifier.js"

export default {
    get:{
            home(context){
                models.articles.getAll().then((res)=>{
                    let articles = res.docs.map(docModifier);
                    let cSharpArticles = [];
                    let jsArticles = [];
                    let javaArticles = [];
                    let pythonArticles = [];

                    articles.forEach(x=>{
                        let curCategory = x.category;
                        switch (curCategory) {
                            case 'C#':
                                cSharpArticles.push(x);
                                break;
                            case 'JavaScript':
                                jsArticles.push(x);
                                break;
                            case 'Java':
                                javaArticles.push(x);
                                break;
                            case 'Pyton':
                                pythonArticles.push(x);
                                break;
                        }
                    })
                    context.jsArticles = jsArticles;
                    context.cSharpArticles = cSharpArticles;
                    context.pythonArticles = pythonArticles;
                    context.javaArticles =javaArticles;
                    extend(context).then(function(){
                        this.partial("../views/home/home.hbs")
                    })
                })
                
            }
    }

}