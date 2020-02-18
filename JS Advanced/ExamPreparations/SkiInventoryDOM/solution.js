function solve() {
   let addButton = document.querySelector("#add-new > button")
   let itemInputs = document.querySelectorAll("#add-new input")
   let totalPrice = 0;

   addButton.addEventListener('click', addProduct);

   document.querySelector("#products > div > button").addEventListener('click', filterProducts);

   let buyButton = document.querySelector("#myProducts > button");
   buyButton.addEventListener('click', buyProducts);

   function buyProducts(e){
      totalPrice = 0;
      document.querySelector("#myProducts > ul").innerHTML='';
      document.querySelector("body > h1:nth-child(4)").innerHTML = 'Total Price: 0.00'
   }

   function addInClientList(e){
      let availableCount = +(e.target.parentNode.parentNode.querySelector("strong").innerHTML.split(' ')[1]);
      let productName = e.target.parentNode.parentNode.querySelector('span').innerHTML;
      let productPrice = +(e.target.parentNode.querySelector("strong").innerHTML);

      let theAddedList = document.createElement('li');
      theAddedList.textContent = productName;

      let myProductPrice = document.createElement('strong');
      myProductPrice.innerHTML = (productPrice.toFixed(2));
      theAddedList.appendChild(myProductPrice);
      document.querySelector("#myProducts > ul").appendChild(theAddedList);

      totalPrice += productPrice;
      document.querySelector("body > h1:nth-child(4)").innerHTML = `Total Price: ${totalPrice.toFixed(2)}`
      if (availableCount === 1) {
         let parentElement = e.target.parentNode.parentNode;
         parentElement.remove();
      }else{
         availableCount -= 1;
         e.target.parentNode.parentNode.querySelector("strong").innerHTML = `Available: ${availableCount}`
      }
      
   }

   function filterProducts(e){
      let textContains = document.querySelector("#filter").value.toLowerCase();
      
      let listItems = document.querySelectorAll("#products ul li span");
      Array.from(listItems).forEach(span=>{
         if (!span.innerHTML.toLowerCase().includes(textContains)) {
            span.parentNode.style.display = 'none';
         }
         else{
            span.parentNode.style.display = 'block';
         }
         
      })

   }
   function addProduct(e){
      e.preventDefault();
      let name = itemInputs[0].value;
      let quantity = itemInputs[1].value;
      let price = +(itemInputs[2].value);

      let theUL = document.querySelector("#products > ul");
      let listEl = document.createElement('li');
      let spanEl = document.createElement('span');
      spanEl.innerHTML = name;
      let strongElQuantity = document.createElement('strong');
      strongElQuantity.innerHTML =`Available: ${quantity}`;
      let divEl = document.createElement('div')
      let strongElPrice = document.createElement('strong');
      strongElPrice.innerHTML = price.toFixed(2);
      let newButton = document.createElement('button');
      newButton.innerHTML = "Add to Client's List"

      divEl.appendChild(strongElPrice);
      divEl.appendChild(newButton);
      listEl.appendChild(spanEl);
      listEl.appendChild(strongElQuantity);
      listEl.appendChild(divEl);
      theUL.appendChild(listEl);
      newButton.addEventListener('click', addInClientList)
   };
};