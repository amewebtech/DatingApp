import { Photo } from './Photo';

export interface User {
    id: number;
    username: string;
    knownAs: string;
    age: number;
    gender: string;
    created: Date;
    lastActive: Date;
    photoUrl: string;
    city: string;
    country: string;
// tslint:disable-next-line: comment-format
//Optional always after mandatory
    interest?: string;
    intriduction?: string;
    lookingFor?: string;
    photos?: Photo[];
}
