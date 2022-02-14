import { ADD_NEW_ITEM  } from "../actionsTypes";


export const addTodo = content => ({
    type: ADD_NEW_ITEM,
    payload: {
        todoItems: [],
      
    }
  });