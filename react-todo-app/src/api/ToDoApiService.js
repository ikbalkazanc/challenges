import todo from '../data/todo'



class ToDoService {  
    getToDos() {
        return todo.filter(item => !item.isDeleted);
    }
    createToDo(name){
        todo.push({id:Math.floor((Math.random())*(0-1000+1)),title:name,isComplated:false})
    }
    removeToDo(id){
        todo.forEach((item) => {
            if (id === item.id) {
                item.isDeleted = true;             
            }
        })
    }

    completeToDo(id) {
        todo.forEach((item) => {
            if (id === item.id) {
                item.isComplated = !item.isComplated;             
            }
        })
    }
}

export default ToDoService