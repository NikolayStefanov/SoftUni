function solve(){
   document.querySelector("body > div > div > aside > section:nth-child(1) > form > button").addEventListener('click', createHandler)
   function createHandler(e){
      e.preventDefault();
      let author = document.querySelector("#creator").value;
      let title = document.querySelector("#title").value;
      let category = document.querySelector("#category").value;
      let content = document.querySelector("#content").value;
      
      let newArticle = document.createElement('article');
      let newH1 = document.createElement('h1');
      newH1.textContent = title;

      let newCategoryParagraph = document.createElement('p');
      let strongCategory = document.createElement('strong');
      strongCategory.innerHTML = category;
      newCategoryParagraph.innerHTML= 'Category:';
      newCategoryParagraph.appendChild(strongCategory)

      let newCreatorParagraph = document.createElement('p');
      let strongCreator = document.createElement('strong');
      strongCreator.innerHTML = author;
      newCreatorParagraph.innerHTML= 'Creator:';
      newCreatorParagraph.appendChild(strongCreator);

      let newContentParagraph = document.createElement('p');
      newContentParagraph.innerHTML= content;

      let divForButtons = document.createElement('div');
      divForButtons.className = 'buttons'; 
      let deleteButton = document.createElement('button');
      deleteButton.className = 'btn delete';
      deleteButton.textContent = 'Delete'
      let archiveButton = document.createElement('button');
      archiveButton.className = 'btn archive';
      archiveButton.textContent = 'Archive';
      divForButtons.appendChild(deleteButton);
      divForButtons.appendChild(archiveButton);

      newArticle.appendChild(newH1);
      newArticle.appendChild(newCategoryParagraph);
      newArticle.appendChild(newCreatorParagraph);
      newArticle.appendChild(newContentParagraph);
      newArticle.appendChild(divForButtons);

      document.querySelector("body > div > div > main > section").appendChild(newArticle);
      archiveButton.addEventListener('click', achieveFunc)
      deleteButton.addEventListener('click', deleteFunc)
      
   }
   function achieveFunc(e){
       let targetTitle = e.target.parentNode.parentNode.querySelector('h1').textContent;
       let ul = document.querySelector("body > div > div > aside > section.archive-section > ul");

       let newList = document.createElement('li');
       newList.innerHTML= targetTitle;
       ul.appendChild(newList);

       let tempArr = [];
       let ulValues = document.querySelectorAll("body > div > div > aside > section.archive-section > ul li");

       let newUL = document.createElement('ul');

       if (ulValues.length >= 1) {
         for (const li of ulValues) {
            let currTitle = li.textContent;
            tempArr.push(currTitle);
         }
         tempArr = tempArr.sort((a,b)=>a.localeCompare(b));

         for (const temp of tempArr) {
            let currLi = document.createElement('li');
            currLi.textContent = temp;
            newUL.appendChild(currLi);
         }
         ul.remove();
         document.querySelector("body > div > div > aside > section.archive-section").appendChild(newUL);
         e.target.parentNode.parentNode.remove();
       }
   }
   function deleteFunc(e){
      let targetEv= e.target.parentNode.parentNode;
      targetEv.remove();
   }
  }
