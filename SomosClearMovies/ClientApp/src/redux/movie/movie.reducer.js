import MovieActionTypes from './movie.types';

const INITIAL_STATE = {
    movies: [],
    isGettingMovies: false,
    errorMessage: undefined
};

const movieReducer = (state = INITIAL_STATE, action) => {
    const { type, payload } = action;
    switch (type) {
        case MovieActionTypes.GET_MOVIES_START:
            return {
                ...state,
                isGettingMovies: true,
                errorMessage: undefined
            };
        case MovieActionTypes.GET_MOVIES_SUCCESS:
            return {
                ...state,
                isGettingMovies: false,
                errorMessage: undefined,
                movies: payload
            };
        case MovieActionTypes.GET_MOVIES_FAILURE:
            return {
                ...state,
                isGettingMovies: false,
                errorMessage: payload,
            };
        default:
            return state;
    }
};

export default movieReducer;
