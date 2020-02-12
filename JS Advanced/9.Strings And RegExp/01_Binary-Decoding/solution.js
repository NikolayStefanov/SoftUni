function solve() {
	let binaryCode = document.querySelector("#input").value;
	let decimalNums = [];
	let countOfRemovedNums = Array.from(binaryCode)
	.map(Number)
	.reduce((a,b)=>a+b, 0)
	.toString()
	.split('')
	.map(Number)
	.reduce((a,b)=> a+b,0);

	while(countOfRemovedNums > 9){
		countOfRemovedNums = countOfRemovedNums.toString().split('').map(Number).reduce((a,b)=> a+b, 0);
	}
	binaryCode = binaryCode.split('').filter(x=> x!== '' && x!==' ');
	for (let index = 0; index < countOfRemovedNums; index++) {
		binaryCode.shift();
		binaryCode.pop();
	}
	let count = Math.ceil(binaryCode.length / 8);
	for (let index = 0; index < count; index++) {
		let currBinaryStr = binaryCode.slice(0, 8);
		binaryCode.splice(0, 8);
		let currNumInStr = currBinaryStr.join('');
		decimalNums.push(parseInt(currNumInStr, 2));
	}
	let finalResult = decimalNums.map(x=>String.fromCharCode(x)).filter(x=> x.match((/[A-Za-z ]/))).join('');
	
	document.querySelector("#resultOutput").textContent = finalResult;
}