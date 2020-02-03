function create(words) {
   let targetDiv = document.querySelector("#content");
   

   words.forEach(element => {
      let currDiv = document.createElement('div')
      targetDiv.appendChild(currDiv);
      let currPar = document.createElement('p');
      currPar.textContent = element;
      currPar.style.display = 'none';
      currDiv.appendChild(currPar);
   });

   targetDiv.addEventListener('click', handled)
   function handled(e){
      e.target.children[0].style.display = 'block';
   }
}