import {
    ADD_NEW_ITEM,
    REMOVE_ITEM,
    COMPLETE_ITEM
} from '../actionsTypes'

import ToDoApiService from '../../api/ToDoApiService'
const todoservice = new ToDoApiService();
const INIT_STATE = {
    todoItems: todoservice.getToDos(),changes:false
};
// eslint-disable-next-line import/no-anonymous-default-export
export default (state = INIT_STATE, action) => {
    
    switch (action.type) {
       
        case ADD_NEW_ITEM:

            todoservice.createToDo(action.payload)
            state.todoItems = todoservice.getToDos();
            return { ...state,changes:!state.changes};

        case COMPLETE_ITEM:
            
            todoservice.completeToDo(action.payload)
            state.todoItems = todoservice.getToDos();
            return { ...state,changes:!state.changes};

      
        case REMOVE_ITEM:
            todoservice.removeToDo(action.payload)
            state.todoItems = todoservice.getToDos();
            return { ...state,changes:!state.changes};

        default: return { ...state };
    }
}
