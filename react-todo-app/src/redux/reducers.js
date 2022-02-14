import { createStore,combineReducers } from 'redux';
import ToDoApp from './todo/reducer';

const reducers = combineReducers({
    ToDoApp
})

//const store = createStore(reducers);
export default reducers;