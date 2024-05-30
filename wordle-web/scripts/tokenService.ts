export default class TokenService {
    private tokenKey: string = "token";

    public setToken(token: string): void {
        localStorage.setItem(this.tokenKey, token);
    }

    public getToken(): string {
        return localStorage.getItem(this.tokenKey) ?? "";
    }

    public isLoggedIn(): boolean {
        return this.getToken() !== "";
    }

    public getUserName(){
        const token = this.getToken();
        if(token === ""){
            return "";
        }
        return JSON.parse(atob(token.split(".")[1]));
    }

    public generateTokenHeader(){
        return{'Authorization': 'Bearer ${this.getToken()}'}
    }


}