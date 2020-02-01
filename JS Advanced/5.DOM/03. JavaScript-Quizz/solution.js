function solve() {
  let correctAnswerCount = 0;
  let correctAnswers = ['onclick','JSON.stringify()','A programming API for HTML and XML documents'];
  [...document.querySelectorAll('.answer-text')]
  .map(x=>x.addEventListener('click',handler));  
 
  function handler(e){
    let section = e.target.parentElement.parentElement.parentElement.parentElement;
    let next = section.nextElementSibling;
    if (e.target.nodeName ==='P'){
   if(correctAnswers.includes(e.target.innerHTML)) correctAnswerCount++;  
   section.style.display = "none";    
   next.style.display = "block";
    }
   if (next.nodeName === 'UL') {
     let resContainer = next.firstElementChild.firstElementChild;
     (correctAnswerCount==correctAnswers.length)
     ? resContainer.textContent = "You are recognized as top JavaScript fan!"
     : resContainer.textContent = `You have ${correctAnswerCount} right answers`
   }
  }
}