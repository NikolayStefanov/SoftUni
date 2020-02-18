class Forum{
    constructor(){
        this._users = [];
        this._questions = [];
        this._id = 1;
    }
    register(username, password, repeatPassword, email){
        if (Array.from(arguments).some(x=> x=== '')) {
            throw new Error('Input can not be empty')
        }
        else if (password !== repeatPassword) {
            throw new Error('Passwords do not match');
        }
        else if (this._users.some(obj=> obj['email'] === email) || this._users.some(obj=> obj['username'] === username)) {
             throw new Error('This user already exists!');
        }
        this._users.push({'username': username, 'email': email, 'password': password, 'logged': false})
        return `${username} with ${email} was registered successfully!`;
    }
    login(username, password){
        if (this._users.every(obj=> obj.username !== username)) {
            throw new Error('There is no such user');
        }
        let targetUser = this._users.find(x=> x.username === username);
        if (targetUser && targetUser.password === password) {
            targetUser.logged = true;
            return 'Hello! You have logged in successfully';
        }
    }
    logout(username, password){
        if (this._users.every(obj=> obj.username !== username)) {
            throw new Error('There is no such user');
        }
        let targetUser = this._users.find(x=> x.username === username);
        targetUser.logged = false;

        if (targetUser && targetUser.password === password) {
            return 'You have logged out successfully';
        }
    }
    postQuestion(username, question){
        if (this._users.every(x=> x.username !== username) || this._users.find(x=> x.username === username).logged === false) {
            throw new Error('You should be logged in to post questions');
        }
        else if(question === ''){
            throw new Error('Invalid question')
        }
        this._questions.push({ 'username': username,'id': this._id, 'question': question, 'answers': []});
        this._id++;

        return 'Your question has been posted successfully';
    }
    postAnswer(username, questionID, answer){
        if (this._users.every(x=> x.username !== username) || this._users.find(x=> x.username === username).logged === false) {
            throw new Error('You should be logged in to post answers');
        }else if(answer === ''){
            throw new Error('Invalid answer')
        }else if(this._questions.every(x=> x.id !== questionID)){
            throw new Error('There is no such question');
        }
        let targetQuestion = this._questions.find(x=> x.id === questionID);
        targetQuestion.answers.push(`---${username}: ${answer}`);
        return 'Your answer has been posted successfully';
    }
    showQuestions(){
        let resultOutput= ``;
        for (const question of this._questions) {
            resultOutput += `Question ${question.id} by ${question.username}: ${question.question}\n`
            for (const ans of question.answers) {
                resultOutput+= ans + '\n';
            }
        }
        return resultOutput;
    }
}
let forum = new Forum();

forum.register('Jonny', '12345', '12345', 'jonny@abv.bg');
forum.register('Peter', '123ab7', '123ab7', 'peter@gmail@.com');
forum.login('Jonny', '12345');
forum.login('Peter', '123ab7');

forum.postQuestion('Jonny', "Do I need glasses for skiing?");
forum.postAnswer('Peter',1, "Yes, I have rented one last year.");
forum.postAnswer('Jonny',1, "What was your budget");
forum.postAnswer('Peter',1, "$50");
forum.postAnswer('Jonny',1, "Thank you :)");

console.log(forum.showQuestions());











