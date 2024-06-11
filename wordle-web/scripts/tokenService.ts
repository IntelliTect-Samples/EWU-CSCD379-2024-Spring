export default class TokenService {
  private tokenKey: string = 'token';

  // Method to set the token
  public setToken(token: string) {
    localStorage.setItem(this.tokenKey, token);
  }

  // Method to get the token
  public getToken(): string {
    return localStorage.getItem(this.tokenKey) ?? '';
  }

  // Check if the user is logged in
  public isLoggedIn(): boolean {
    // Won't work if the token is expired
    return this.getToken() !== '';
  }

  // Get the username from the token
  public getUserName(): string {
    const token = this.getToken();
    if (!token || token.split('.').length !== 3) {
      return '';
    }
    console.log(JSON.parse(atob(token.split('.')[1])));
    return JSON.parse(atob(token.split('.')[1])).userName;
  }

  // Check if the user can delete and add words
  public canDeleteAndAdd(): boolean {
    const token = this.getToken();
    if (!token || token.split('.').length !== 3) {
      return false;
    }
    const payload = JSON.parse(atob(token.split('.')[1]));
    const birthDate = new Date(payload.BirthDate);
    const isMasterOfTheUniverse = payload.MasterOfTheUniverse;

    const age = this.calculateAge(birthDate);
    return age >= 21 && isMasterOfTheUniverse;
  }

  // Generate the authorization header
  public generateTokenHeader(): { Authorization: string } {
    return { Authorization: `Bearer ${this.getToken()}` };
  }

  // Helper method to calculate age
  private calculateAge(birthDate: Date): number {
    const today = new Date();
    let age = today.getFullYear() - birthDate.getFullYear();
    const monthDiff = today.getMonth() - birthDate.getMonth();
    if (monthDiff < 0 || (monthDiff === 0 && today.getDate() < birthDate.getDate())) {
      age--;
    }
    return age;
  }
}
