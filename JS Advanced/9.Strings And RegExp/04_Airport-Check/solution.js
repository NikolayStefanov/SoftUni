function solve() {
    let namesRegEx = RegExp(/( [A-Z]+[a-z]*-[A-Z]+[a-z]* | [A-Z]+[a-z]*-[A-Z]+[a-z]*\.-[A-Z]+[a-z]* )/);
    let airportRegEx = RegExp(/ [A-Z]{3}\/[A-Z]{3}/);
    let flightNumberRegEx = RegExp(/ [A-Z]{1,3}[0-9]{1,5} /);
    let companyNameRegEx = RegExp(/- [A-Z]{1}[A-Za-z]*\*[A-Z]{1}[A-Za-z]* /);
    let [criptedText, printCondition] = document.querySelector("#string").value.split(', ');
    
    let theName = namesRegEx.exec(criptedText)[0];
    let theAirPort = airportRegEx.exec(criptedText)[0];
    let theFlightNumber = flightNumberRegEx.exec(criptedText)[0];
    let theCompanyName = companyNameRegEx.exec(criptedText)[0];
 
    let finalResult = '';
    switch (printCondition) {
        case 'name':
            finalResult = namePrint(theName);
            break;
        case 'flight':
            finalResult = flightPrint(theFlightNumber, theAirPort);
            break;
        case 'company':
            finalResult = companyPrint(theCompanyName);
            break;
        case 'all':
            finalResult = printAll(theName, theFlightNumber, theAirPort, theCompanyName);
            break;
    }

    let result =  document.querySelector("#result")
    let newSpan = document.createElement('span');
    newSpan.textContent = finalResult;
    result.appendChild(newSpan);

    function namePrint(name){
        return `Mr/Ms, ${name.replace(/ /g, '').replace(/-/g, ' ')}, have a nice flight!`
    }
    function flightPrint(flightNumber, airport){
        let airports = airport.split('/');
        return `Your flight number ${flightNumber.replace(/ /g, '')} is from ${airports[0]} to ${airports[1]}.`
    }
    function companyPrint(company){
        return `Have a nice flight with ${company.replace(/- /, '').replace(' ', '').replace(/\*/, ' ')}.`
    }
    function printAll(name, flightNumber, airport, company){
        let airports = airport.split('/');
        return `Mr/Ms, ${name.replace(/ /g, '').replace(/-/g, ' ')}, your flight number ${flightNumber.replace(/ /g, '')} is from ${airports[0]} to ${airports[1]}. ${companyPrint(company)}`
    }
    
}