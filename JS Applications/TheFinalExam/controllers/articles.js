import extend from "../utils/helperFunc.js"
import models from "../models/index.js"
import docModifier from "../utils/docModifier.js"
export default {
    get: {
        create(context) {

            extend(context).then(function () {
                this.partial("../views/articles/create.hbs")
            })

        },
        details(context) {
            let {
                articleId
            } = context.params;

            models.articles.get(articleId).then((res) => {
                let article = docModifier(res)
                context.article = article;
                Object.entries(article).forEach(([key, value]) => {
                    context[key] = value;
                })
                context.canEdit = article.uid === localStorage.getItem('userId')
                extend(context).then(function () {
                    this.partial("../views/articles/details.hbs")
                })
            }).catch((e) => console.error(e))
        },
        edit(context) {
            let {
                articleId
            } = context.params;
            models.articles.get(articleId).then((res) => {
                let article = docModifier(res);
                context.article = article;
                Object.entries(article).forEach(([key, value]) => {
                    context[key] = value;
                })

                extend(context).then(function () {
                    this.partial("../views/articles/edit.hbs")
                })
            }).catch((e) => console.error(e))
        }
    },
    post: {
        create(context) {

            let data = {
                ...context.params,
                creator: localStorage.getItem('userEmail'),
                uid: localStorage.getItem('userId')
            }

            models.articles.create(data).then((res) => {
                    context.redirect('#/home')
                })
                .catch(err => console.error(err))
        },
    },
    del: {
        close(context) {
            let {
                articleId
            } = context.params
            models.articles.close(articleId).then((res) => {
                context.redirect('#/home')
            })

        }
    },
    put: {
        edit(context) {
            let {
                title,
                category,
                content,
                articleId
            } = context.params;

            models.articles.get(articleId).then((res) => {
                let data = docModifier(res);
                data.title = title;
                data.category = category;
                data.content = content;

                models.articles.edit(data).then((res) => {
                    context.redirect(`#/home`)
                })
            })

        }
    }
}