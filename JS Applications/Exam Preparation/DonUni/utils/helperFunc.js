export default function(context){
        firebase.auth().onAuthStateChanged(function(user) {
            if (user) {
              // User is signed in.
              context.isLoggedIn = true;
              context.username = user.email;
              context.userId = user.uid;
              localStorage.setItem('userId', user.uid)
              localStorage.setItem('userEmail', user.email)
              // ...
            } else {
              // User is signed out.
              context.isLoggedIn = false;
              context.username = null;
              context.userId = null;
              localStorage.clear();
              // ...
            }
          })

          return context.loadPartials({
            header: "../views/common/header.hbs",
            footer: "../views/common/footer.hbs"
          })
}