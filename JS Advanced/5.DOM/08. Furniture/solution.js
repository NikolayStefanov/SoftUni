function solve() {
  const txtAreas = document.querySelectorAll('textarea');
  const tBody = document.querySelector("tbody");
  const handlerMap = {
    Generate : addFrn,
    Buy : chOut
  };
[...document.querySelectorAll('button')]
.map(x=>x.addEventListener('click',handlerMap[x.innerHTML]));
 
function addFrn(){  
  let obj = JSON.parse(txtAreas[0].value);
 let rows = obj.map(x=>{  
  let newRow = document.createElement("tr");
   newRow.appendChild(crElem(x.img,'img'));
   newRow.appendChild(crElem(x.name,'p'));
   newRow.appendChild(crElem(x.price,'p'));
   newRow.appendChild(crElem(x.decFactor,'p'));
   newRow.appendChild(crElem(null,'input'));
   return newRow;
 });
 rows.map(x=>tBody.appendChild(x));
}
function crElem(x,y){
  const el = document.createElement("td");
  const p = document.createElement(y);
  if (y === 'img') p.src = x;
  else if (y==='input')  p.type= "checkbox";
  else p.textContent = x;
  el.appendChild(p);
  return el;
}
function chOut() {
  let output = document.querySelectorAll("#exercise textarea")[1];
  let bought = [...document.querySelectorAll('input')].reduce((a,b,i)=> {
    if (b.checked === true) a.push(tBody.children[i]);
    return a;
  },[]);
  let names = bought.map(x=>x.children[1].textContent);
  let totalPrice = bought.reduce((a,b) =>{
    a += Number(b.children[2].textContent);
    return a;
  },0)
  let decFactor = bought.reduce((a,b) => {
    a += Number(b.children[3].textContent);
    return a;
  },0)/bought.length;
  output.value += `Bought furniture: ${names.join(", ")}\n`;
  output.value += `Total price: ${totalPrice.toFixed(2)}\n`;
  output.value += `Average decoration factor: ${decFactor}`;
  }
}