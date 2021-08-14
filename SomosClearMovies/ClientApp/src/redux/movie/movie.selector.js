import { createSelector } from "reselect";

const selectMovie = state => state.movies;

export const selectMoviesCollection = createSelector(
    [selectMovie],
    movies => movies.movies
);

export const selectMovies = createSelector(
    [selectMoviesCollection],
    movies => movies.map(movie => ({
        title: movie.title,
        genre: movie.genre,
        actors: movie.actors.join(', ')
    }))
);