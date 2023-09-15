import IPhoto from "./IPhoto";

export default interface IPhotoResponse {
    results: IPhoto[];
    page: number;
    pageSize: number;
    totalPages: number;
} 

