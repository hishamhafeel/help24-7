export class LoginModel {
    username: string;
    password: string;
    token: string;
    tokenExpiration: Date;
    isAdmin: boolean;
}