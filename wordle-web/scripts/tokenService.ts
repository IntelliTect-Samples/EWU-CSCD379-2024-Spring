export const key = Symbol() as InjectionKey<TokenService>;

export class TokenService {
  private tokenKey: string = 'token';

  public setToken(token: string) {
    localStorage.setItem(this.tokenKey, token);
  }

  public getToken(): string {
    return localStorage.getItem(this.tokenKey) ?? '';
  }

  public isLoggedIn(): boolean {
    // Won't work if the token is expired
    return this.getToken() !== '';
  }

  public getUserName() {
    const token = this.getToken();
    if (token === '' || token.split('.').length !== 3) {
      return '';
    }
    console.log(JSON.parse(atob(token.split('.')[1])));
    return JSON.parse(atob(token.split('.')[1])).userName;
  }

  public getMotU(): boolean {
    const token = this.getToken();
    if (token === '' || token.split('.').length !== 3) {
      return false;
    }
    console.log(JSON.parse(atob(token.split('.')[1])));
    let result = JSON.parse(atob(token.split('.')[1])).MasterOfTheUniverse;
    return result?.toLowerCase() === 'true';
  }

  public isOlderThanTwentyOne() {
    const token = this.getToken();
    if (token === '' || token.split('.').length !== 3) {
      return false;
    }
    console.log(JSON.parse(atob(token.split('.')[1])));
    let result = JSON.parse(atob(token.split('.')[1])).BirthDate.split('/');
    let year = result[2];
    let month = result[0];
    let day = result[1];
    let now = new Date();
    let yearDifference = now.getFullYear() - year;
    if (yearDifference > 21) {
      return true;
    } else if (yearDifference == 21) {
      return now.getMonth() >= month ? now.getDay() >= day : false;
    } else {
      return false;
    }
  }

  public generateTokenHeader() {
    return { Authorization: `Bearer ${this.getToken()}` };
  }
}
