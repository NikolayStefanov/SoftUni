class SortedList{
    sortedList = []
    size= 0;
    add(element){
        this.sortedList.push(element);
        this.order(this.sortedList);
        this.size = this.sortedList.length;

    }   
    remove(index){
        if (index >=0 && index < this.sortedList.length) {
            this.sortedList.splice(index, 1)
            this.size = this.sortedList.length;
        }
    }
    get(index){
        if (index >=0 && index < this.sortedList.length) {
            return this.sortedList[index];
        }
    }
    order(list){
        list.sort((a,b)=> {
            return a-b;
        })
    }
}


