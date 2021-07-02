import { IGender } from "./IGender";

export interface IMovie {
    id: number;
    title: string;
    year: number;
    rating: number;
    genres: IGender[]
}