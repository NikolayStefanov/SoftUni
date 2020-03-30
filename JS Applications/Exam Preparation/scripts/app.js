import controllers from "../controllers/index.js"

var app = Sammy('#main', function () {
    this.use('Handlebars', 'hbs');

    //Home
    this.get('#/home', controllers.home.get.home)

    //User
    this.get('#/user/login', controllers.user.get.login)
    this.get('#/user/register', controllers.user.get.register)
    this.get('#/user/logout', controllers.user.get.logout)

    this.post('#/user/login', controllers.user.post.login)
    this.post('#/user/register', controllers.user.post.register)

    //Causes
    this.get('#/causes/create', controllers.cause.get.create)
    this.get("#/causes/dashboard", controllers.cause.get.dashboard)
    this.get("#/causes/details/:causeId", controllers.cause.get.details)

    this.post("#/causes/create", controllers.cause.post.create)
    
    this.get("#/causes/close/:causeId", controllers.cause.del.close)
    this.post("#/causes/donate/:causeId", controllers.cause.put.donate)
});

app.run('#/home');