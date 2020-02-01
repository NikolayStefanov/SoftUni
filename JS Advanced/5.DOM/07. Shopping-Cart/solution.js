function solve() {
   let textArea = document.querySelector("body > div > textarea");
   //[...document.querySelectorAll(".add-product")].forEach(add => {
   //   add.addEventListener("click", handle)
   //});
   //function handle(e) {
   //   let title = e.target.parentElement.previousElementSibling.firstElementChild.innerText;
   //   let price = e.target.parentElement.nextElementSibling.innerText;
   //   
   //   textArea.value += `Added ${title} for ${price} to the cart.\n`;  
   //}
   document.querySelector("body > div > div:nth-child(2) > div.product-add > button").addEventListener("click", breadHandler);
   document.querySelector("body > div > div:nth-child(3) > div.product-add > button").addEventListener("click", milkHandler);
   document.querySelector("body > div > div:nth-child(4) > div.product-add > button").addEventListener("click", tomatoeHandler)

   function breadHandler() {
      let breadTitle = document.querySelector('body > div > div:nth-child(2) > div.product-details > div').textContent;
      let breadPrice = document.querySelector("body > div > div:nth-child(2) > div.product-line-price").textContent;
      textArea.value += `Added ${breadTitle} for ${breadPrice} to the cart.\n`;
   }

   function milkHandler() {
      let milkTitle = document.querySelector('body > div > div:nth-child(3) > div.product-details > div').textContent;
      let milkPrice = document.querySelector("body > div > div:nth-child(3) > div.product-line-price").textContent;
      textArea.value += `Added ${milkTitle} for ${milkPrice} to the cart.\n`;
   }

   function tomatoeHandler() {
      let tomatoeTitle = document.querySelector('body > div > div:nth-child(4) > div.product-details > div').textContent;
      let tomatoePrice = document.querySelector("body > div > div:nth-child(4) > div.product-line-price").textContent;
      textArea.value += `Added ${tomatoeTitle} for ${tomatoePrice} to the cart.\n`;
   }

   document.querySelector("body > div > button").addEventListener("click", buy);

   function buy() {
      let finalText = textArea.value.split('\n').filter(x => x.length > 0);
      let boughtProducts = [];
      let totalPrice = 0;
      for (const bought of finalText) {
         let currProduct = bought.split(' ')[1]
         if (!boughtProducts.includes(currProduct)) {
            boughtProducts.push(currProduct);
         }
         totalPrice += +(bought.split(' ')[3]);
      }
      textArea.value += `You bought ${boughtProducts.join(', ')} for ${totalPrice.toFixed(2)}.`;
      Array.from(document.querySelectorAll("button")).map(x => x.disabled = true);
   }
};