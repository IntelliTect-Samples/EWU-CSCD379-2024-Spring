
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

    public parseToken():string[]{
        const token = this.getToken();
        if(token === ""){
            return [];
        }
        var tokenString = JSON.parse(atob(token.split(".")[1]));
        var tokenArray:string[] = [];
        for(var key in tokenString){
            tokenArray.push(tokenString[key]);
        }
        return tokenArray;
    }

    public generateTokenHeader(){
        return{'Authorization': 'Bearer ${this.getToken()}'}
    }


}
enum TokenVals{
    //this isn't used but its a reminder of what the token values are
    sub,
    jti,
    userId,
    userName,
    Age,
    MasterOfTheUniverse,
    Role,
    exp,
    iss,
    aud
}