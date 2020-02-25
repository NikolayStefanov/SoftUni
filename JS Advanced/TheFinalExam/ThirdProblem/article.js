class Article{
    _comments= [];
    _likes = [];
    constructor(title, creator){
        this.title = title;
        this.creator = creator;
    }
    get likes(){
        if (this._likes.length === 0) {
            return `${this.title} has 0 likes`
        }
        if (this._likes.length === 1) {
            return `${this._likes[0]} likes this article!`
        }
        return `${this._likes[0]} and ${this._likes.length - 1} others like this article!`
    }
    like (username){
        if (this._likes.some(x=> x === username)) {
            throw new Error("You can't like the same article twice!");
        }
        if (this.creator === username) {
            throw new Error("You can't like your own articles!");
        }
        this._likes.push(username);
        return `${username} liked ${this.title}!`
    }
    dislike (username){
        if (this._likes.every(x=> x !== username)) {
            throw new Error(`You can't dislike this article!"`);
        }
        this._likes = this._likes.filter(x=> x!== username)
        return `${username} disliked ${this.title}`
    }
    comment (username, content, id){
        let targetComment = this._comments.find(x=> x.Id === id)
        if (id === undefined || !targetComment) {
            let nextID = this._comments.length+1;
            let newestComment = {Id: nextID, Username: username, Content: content, Replies: []}
            this._comments.push(newestComment);
            return `${username} commented on ${this.title}`;
        }
        if (targetComment) {
            let repliesCount = targetComment.Replies.length+1;
            let currReply = `${targetComment.Id}.${repliesCount}`
            let newestReply = {Id: currReply, Username: username, Content: content}
            targetComment.Replies.push(newestReply);
            return `You replied successfully`
        }
    }
    toString(sortingType){
        let result = '';
        result += `Title: ${this.title}\nCreator: ${this.creator}\nLikes: ${this._likes.length}\nComments:\n`
        if (sortingType === 'asc') {
            this._comments = this._comments.sort((a,b)=> a.Id-b.Id);
            for (const com of this._comments) {
                result+=`-- ${com.Id}. ${com.Username}: ${com.Content}\n`
                com.Replies = com.Replies.sort((a,b)=> +(a.Id)-(+(b.Id)));
                for (const reply of com.Replies) {
                    result += `--- ${reply.Id}. ${reply.Username}: ${reply.Content}\n`
                }
            }
        }
        else if(sortingType === 'desc'){
            this._comments = this._comments.sort((a,b)=> b.Id-a.Id);
            for (const com of this._comments) {
                result+=`-- ${com.Id}. ${com.Username}: ${com.Content}\n`
                com.Replies = com.Replies.sort((a,b)=> +(b.Id)-(+(a.Id)));
                for (const reply of com.Replies) {
                    result += `--- ${reply.Id}. ${reply.Username}: ${reply.Content}\n`
                }
            }
        }else{
           this._comments = this._comments.sort((a,b)=> a.Username.localeCompare(b.Username))
            for (const com of this._comments) {
                result+=`-- ${com.Id}. ${com.Username}: ${com.Content}\n`
                com.Replies = com.Replies.sort((a,b)=> a.Username.localeCompare(b.Username));
                for (const reply of com.Replies) {
                    result += `--- ${reply.Id}. ${reply.Username}: ${reply.Content}\n`
                }
            }
        }
         
        return result.trim();
    }
}
let art = new Article("My Article", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));
