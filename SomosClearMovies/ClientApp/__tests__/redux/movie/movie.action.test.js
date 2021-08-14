import configureStore from 'redux-mock-store';

import * as movieRedux from './../../../src/redux/movie'

const mockStore = configureStore();

const store = mockStore();

describe('Movie Actions', () => {
    beforeEach(() => { // Runs before each test in the suite
        store.clearActions();
    });

    test('Dispatches the getMoviesStart action', () => {
        const expectedActions = [
            {
                type: movieRedux.MovieActionTypes.GET_MOVIES_START
            },
        ];
        store.dispatch(movieRedux.getMoviesStart());
        expect(store.getActions()).toEqual(expectedActions);
    })

    test('Dispatches the getMoviesSuccess action', () => {
        const movies = [
            {
                title: 'Movie 1',
                genere: 'Action',
                actors: [
                    'Actor 1',
                    'Actor 2',
                    'Actor 3'
                ]
            }
        ];
        const expectedActions = [
            {
                type: movieRedux.MovieActionTypes.GET_MOVIES_SUCCESS,
                payload: movies
            },
        ];
        store.dispatch(movieRedux.getMoviesSuccess(movies));
        expect(store.getActions()).toEqual(expectedActions);
    })

    test('Dispatches the getMoviesFailure action', () => {
        const error = 'error';
        const expectedActions = [
            {
                type: movieRedux.MovieActionTypes.GET_MOVIES_FAILURE,
                payload: error
            },
        ];
        store.dispatch(movieRedux.getMoviesFailure(error));
        expect(store.getActions()).toEqual(expectedActions);
    })
});