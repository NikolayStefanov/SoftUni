function notify(message) {
   let nitificationWindow =  document.querySelector("#notification");
   nitificationWindow.textContent = message;
   nitificationWindow.style.display = "block";
   setTimeout(showField, 2000); 
   function showField(){
    nitificationWindow.style.display = 'none';
   }
}