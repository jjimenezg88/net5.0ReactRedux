import { applyMiddleware, createStore } from 'redux';
import thunk from 'redux-thunk';
import logger from 'redux-logger';
import rootReducer from './root.reducer';

const configureStore = () => {
    const middleware = [thunk];

    if (process.env.NODE_ENV === 'development') {
        middleware.push(logger);
    }

    return createStore(
        rootReducer,
        applyMiddleware(...middleware)
    );
};

export default configureStore;
