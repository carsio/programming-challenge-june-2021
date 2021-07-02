import { IResponse } from '../interfaces/IResponseData';
import { IGender } from '../interfaces/IGender';
import { IMovie } from '../interfaces/IMovie';
import api from './api';

export const movieService = {
    getMovies(
        year: string,
        gender: string,
        topK: string
    ) : Promise<IResponse<IMovie[]>> {
        return api.get(`/movies?year=${year}&&gender=${gender}&&topK=${topK}`);
    },  
    getGenres() : Promise<IResponse<IGender[]>> {
        return api.get(`/genres`);
    }
}