import controllers from "../controllers/index.js"

var app = Sammy('#main', function () {
    this.use('Handlebars', 'hbs');

    //Home
    this.get('#/home', controllers.home.get.home)
    this.get('#/loginHome', controllers.home.get.loginHome)


    //User
    this.get('#/user/login', controllers.user.get.login)
    this.get('#/user/register', controllers.user.get.register)
    this.get('#/user/logout', controllers.user.get.logout)
    this.get('#/user/profile', controllers.user.get.profile)
//
    this.post('#/user/login', controllers.user.post.login)
    this.post('#/user/register', controllers.user.post.register)
//
//   //Treks
    this.get('#/trek/create', controllers.trek.get.create)
    this.get("#/trek/details/:trekId", controllers.trek.get.details)
    this.get("#/trek/edit/:trekId", controllers.trek.get.edit)
    this.get("#/trek/like/:trekId", controllers.trek.put.like)


    this.post('#/trek/create', controllers.trek.post.create)
    this.get("#/trek/close/:trekId", controllers.trek.del.close)
    this.post("#/trek/edit/:trekId", controllers.trek.put.edit)
});

app.run('#/home');