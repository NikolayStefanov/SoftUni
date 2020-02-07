class CheckingAccount{
    clientId;
    email;
    firstName;
    lastName;
    constructor(clientId, email, firstName, lastName){
        this.cliendIdSetter = clientId;
        this.emailSetter = email;
        this.firstNameSetter = firstName;
        this.lastNameSetter = lastName;
    }
    get clientIdGetter(){
        return this.clientId;
    }
    set cliendIdSetter(id){
        if (typeof(id) != 'string' || !this.isNumber(id) || id.length != 6) {
            throw new TypeError('Client ID must be a 6-digit number')
        }
        this.clientId = id;
    }

    get emailGetter(){
        return this.email;
    }
    set emailSetter(em){
        if (!this.validateEmail(em)) {
            throw new TypeError("Invalid e-mail");
        }
        this.email = em;
    }

    get firstNameGetter(){
        return this.firstName;
    }
    set firstNameSetter(fName){
        if (!fName.match(/^[a-zA-Z0-9_\-+ ]*$/)) {
            throw new TypeError('First name must contain only Latin characters');
        }
        if (fName.length < 3 || fName.length > 20) {
            throw new TypeError('First name must be between 3 and 20 characters long');
        }
        this.firstName = fName;
    }

    get lastNameGetter(){
        return this.lastName;
    }
    set lastNameSetter(lName){
        if (!lName.match(/^[a-zA-Z0-9_\-+ ]*$/)) {
            throw new TypeError('Last name must contain only Latin characters');
        }
        if (lName.length < 3 || lName.length > 20) {
            throw new TypeError('Last name must be between 3 and 20 characters long');
        }
        this.lastName = lName;
    }
    isNumber(str) 
    {
        return /^\d+$/.test(str);
    }
    validateEmail(email){
        const regEx = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+/;
        return regEx.test(email);
    }
}
let temp = new CheckingAccount('123456', 'ivn@dsada', 'Nikolay', 'Stfanov');
console.log(temp.clientId);
console.log(temp.email);
console.log(temp.firstName);
console.log(temp.lastName);



