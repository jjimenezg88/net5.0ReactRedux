import MovieActionTypes from './movie.types';
import MovieService from '../../services/movie.service';

export const getMoviesStart = () => ({
    type: MovieActionTypes.GET_MOVIES_START
});

export const getMoviesSuccess = (movies) => ({
    type: MovieActionTypes.GET_MOVIES_SUCCESS,
    payload: movies
});

export const getMoviesFailure = (error) => ({
    type: MovieActionTypes.GET_MOVIES_FAILURE,
    payload: error
});

export const getMoviesStartAsync = (title, genere, actorName) => dispatch => {
    dispatch(getMoviesStart());
    MovieService.getMovies(title, genere, actorName)
        .then(response =>
            dispatch(getMoviesSuccess(response.data))
        )
        .catch(error =>
            dispatch(getMoviesFailure(error.message))
        );
};