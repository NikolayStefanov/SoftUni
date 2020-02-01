function solve() {
    let alphabeticalObj = {
        0: 'A', 1: 'B', 2: 'C', 3: 'D', 4: 'E', 5: 'F', 6: 'G', 7: 'H', 8: 'I', 9: 'J', 10: 'K', 11: 'L',12: 'M', 13: 'N',
        14: 'O', 15: 'P', 16: 'Q', 17: 'R', 18: 'S', 19: 'T', 20: 'U', 21: 'V', 22: 'W', 23: 'X', 24: 'Y', 25: 'Z'        
    };
    let addButton = document.querySelector("#exercise > article > button");
 
    function fillUpTheList(){
        let givenName = document.querySelector('input').value;
        let allOrderedList = document.querySelector("#exercise > div > ol").children;
       
        let firstLetter = givenName[0].toUpperCase();
        for (const key in alphabeticalObj) {
            if (firstLetter === alphabeticalObj[key]) {
               
                givenName = givenName.charAt(0).toUpperCase() + givenName.slice(1).toLowerCase();
                if (allOrderedList[key].textContent.length == 0) {
                    allOrderedList[key].textContent = givenName;
                }
                else{
                    allOrderedList[key].textContent += ', ' + givenName;
                }
            }
        }
       
     document.querySelector("#exercise > article > input[type=text]").value ='';
    }
    addButton.addEventListener("click", fillUpTheList);
}