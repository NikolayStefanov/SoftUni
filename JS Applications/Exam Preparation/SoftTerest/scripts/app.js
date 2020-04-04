import controllers from "../controllers/index.js"

var app = Sammy('#main', function () {
    this.use('Handlebars', 'hbs');

//   //  Home
     this.get('#/home', controllers.home.get.home)
//     this.get('#/loginHome', controllers.home.get.loginHome)


//   //  User
     this.get('#/user/login', controllers.user.get.login)
     this.get('#/user/register', controllers.user.get.register)
     this.get('#/user/logout', controllers.user.get.logout)
     this.get('#/user/profile', controllers.user.get.profile)

     this.post('#/user/login', controllers.user.post.login)
     this.post('#/user/register', controllers.user.post.register)
//   // Treks
    this.get('#/dashboard', controllers.dashboard.get.dashboard)
    this.get('#/idea/create', controllers.dashboard.get.create)
    this.get("#/dashboard/details/:ideaId", controllers.dashboard.get.details)
     this.get("#/idea/comment/:ideaId", controllers.dashboard.put.edit)
     this.get("#/idea/like/:ideaId", controllers.dashboard.put.like)


     this.post('#/idea/create', controllers.dashboard.post.create)
     this.get("#/idea/close/:ideaId", controllers.dashboard.del.close)
});

app.run('#/home');