export default class TokenService {
  private tokenKey: string = "token";

  public setToken(token: string) {
    localStorage.setItem(this.tokenKey, token);
  }

  public getToken(): string {
    return localStorage.getItem(this.tokenKey) ?? "";
  }

  public isLoggedIn(): boolean {
    // Won't work if the token is expired
    return this.getToken() !== "";
  }

  public getUserName() {
    const token = this.getToken();
    if (token === "") {
      return "";
    }
    console.log(JSON.parse(atob(token.split(".")[1])));
    return JSON.parse(atob(token.split(".")[1])).userName;
  }

  public canDeleteAndAdd() {
    const token = this.getToken();
    if (token === "") {
      return false;
    }
    const birthday = JSON.parse(atob(token.split(".")[1])).BirthDate;
    const masterOfTheUniverse = JSON.parse(
      atob(token.split(".")[1])
    ).MasterOfTheUniverse;
    const year = new Date().getFullYear();
    const birthYear = new Date(birthday).getFullYear();

    return year - birthYear >= 21 && masterOfTheUniverse;
  }

  public generateTokenHeader() {
    return { Authorization: `Bearer ${this.getToken()}` };
  }
}
