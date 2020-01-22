function createHTMLTable(jsonText){
    let objects = jsonText.map(x=> JSON.parse(x));
    
    let createTable = content => `<table>${content}\n</table>`;
    let createRow = content => `\n\t<tr>\n${content}\t</tr>`;
    let createData = content => `\t\t<td>${content}</td>\n`;

    let result = objects.reduce((accRows, row)=>{

        let tdForPerson= Object.values(row).reduce((tdAcc, td)=> {
            return tdAcc+createData(td);
        }, '')
        return accRows + createRow(tdForPerson);
    }, '')

    return createTable(result);
    
    
}

function escapeHtml(unsafe) {
    return unsafe
         .replace(/&/g, "&amp;")
         .replace(/</g, "&lt;")
         .replace(/>/g, "&gt;")
         .replace(/"/g, "&quot;")
         .replace(/'/g, "&#039;");
 }

console.log(createHTMLTable(['{"name":"Pesho","position":"Promenliva","salary":100000}',
    '{"name":"Teo","position":"Lecturer","salary":1000}',
    '{"name":"Georgi","position":"Lecturer","salary":1000}']));