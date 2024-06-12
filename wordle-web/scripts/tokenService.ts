export default class TokenService {
  private tokenKey = "token";

  public setToken(token: string): void {
    localStorage.setItem(this.tokenKey, token);
  }

  public getToken(): string {
    return localStorage.getItem(this.tokenKey) ?? "";
  }

  public isLoggedIn(): boolean {
    return this.getToken() !== "";
  }

  public getUserName(): string {
    const token = this.getToken();
    if (token === "") {
      return "";
    }
    const decodedToken = JSON.parse(atob(token.split(".")[1]));
    return decodedToken.userName;
  }

  public canDeleteAndAdd(): boolean {
    const token = this.getToken();
    if (token === "") {
      return false;
    }
    const decodedToken = JSON.parse(atob(token.split(".")[1]));
    const birthDate = new Date(decodedToken.BirthDate);
    const isMasterOfTheUniverse = decodedToken.MasterOfTheUniverse;
    const age = new Date().getFullYear() - birthDate.getFullYear();

    return age >= 21 && isMasterOfTheUniverse;
  }

  public generateTokenHeader(): Record<string, string> {
    return { Authorization: `Bearer ${this.getToken()}` };
  }
}
