import { createStore, applyMiddleware, compose } from 'redux';

// Import custom components
import reducers from '../redux/reducers';

const store = createStore(reducers);



export default store;