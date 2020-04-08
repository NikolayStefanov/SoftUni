import controllers from "../controllers/index.js"

var app = Sammy('#main', function () {
    this.use('Handlebars', 'hbs');

// //   //  Home
      this.get('#/home', controllers.home.get.home)
      this.get('#/loginHome', controllers.home.get.loginHome)


// //   //  User
      this.get('#/user/login', controllers.user.get.login)
      this.get('#/user/register', controllers.user.get.register)
      this.get('#/user/logout', controllers.user.get.logout)

      this.post('#/user/login', controllers.user.post.login)
      this.post('#/user/register', controllers.user.post.register)
// //   // Articles
      this.get('#/article/create', controllers.articles.get.create)
      this.get("#/article/details/:articleId", controllers.articles.get.details)
      this.get("#/article/edit/:articleId", controllers.articles.get.edit)
      this.get("#/article/delete/:articleId", controllers.articles.del.close)

      this.post("#/article/edit/:articleId", controllers.articles.put.edit)
      this.post('#/article/create', controllers.articles.post.create)
});

app.run('#/user/register');