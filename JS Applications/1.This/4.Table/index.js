function solve(){
   document.querySelector("body > table > tbody").addEventListener('click', handler)
   function handler(e){
      let targetRow = e.target.parentNode;
      if (targetRow.style.backgroundColor === "rgb(65, 63, 94)") {
         targetRow.removeAttribute('style');
      }else{
         Array.from(document.querySelectorAll("body > table > tbody tr")).forEach(x=>{x.removeAttribute('style')});
         targetRow.style.backgroundColor = "#413f5e";
      }
   }
}