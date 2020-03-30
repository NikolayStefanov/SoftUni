export default{
    create(data){
        return firebase.firestore().collection('causes').add(data)
    },
    getAll(){
        return firebase.firestore().collection('causes').get();
    },
    get(id){
        return firebase.firestore().collection('causes').doc(id).get()
    },
    close(id){
        return firebase.firestore().collection('causes').doc(id).delete();
    },
    donate(data){
        
        return firebase.firestore().collection('causes').doc(data.id).update(data);
    }
}