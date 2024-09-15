// This interface is used to shape the model with required properties
export interface User {
    username: string;
    knownAs: string;
    gender: string;
    token: string;
    photoUrl?: string;
    roles: string[];
}