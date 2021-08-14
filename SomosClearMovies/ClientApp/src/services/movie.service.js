import { API } from "../utils/api";

const MovieService = {
    getMovies: (title, genere, actorName) => {
        let params;
        if (title) {
            params = `title=${title}`
        }

        if (genere) {
            params = !!params ? `${params}&genere=${genere}` : `genere=${genere}`;
        }

        if (actorName) {
            params = !!params ? `${params}&actorName=${actorName}` : `actorName=${actorName}`;
        }

        if (params) {
            params = `?${params}`;
        } else {
            params = '';
        }

        return API.get(`api/v1.0/Movies/GetMovies${params}`);
    }
};

export default MovieService;