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
    interests?: string;
    intriduction?: string;
    lookingfor?: string;
    photos?: Photo[];
}
