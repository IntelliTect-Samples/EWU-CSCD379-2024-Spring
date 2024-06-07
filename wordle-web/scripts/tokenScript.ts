export default class TokenScript 
{
  private tokenKey: string = 'token';

  public setToken(token: string){
    localStorage.setItem(this.tokenKey, token);
  }

  public getToken(): string {
    return localStorage.getItem(this.tokenKey) ?? '';
  }

  public isLoggedIn(): boolean {
    return this.getToken() !== '';
  }

  public getUserName() {
    var token = this.getToken();
    if (token === ''){
      return token;
    }
    //console.log(JSON.parse(atob(token.split('.')[1])));
    return JSON.parse(atob(token.spit('.')[1])).username;
  }


  public deleteAndAdd() {
    var token = this.getToken();
    if (token === '') {
      return false;
    }
    const bDay = JSON.parse(atob(token.split('.')[1])).Birthdate;
    const year = new Date().getFullYear();
    const bDayYear = new Date(bDay).getFullYear();

    const masterOfTheUniverse = JSON.parse(atob(token.split(".")[1])).MaterOfTheUniverse;


    return year - bDayYear >= 21 && masterOfTheUniverse;
  }


  public generateTokenHeader() {
    return { Authorization: 'Bearer ${this.getToken()}' };
  }
}
