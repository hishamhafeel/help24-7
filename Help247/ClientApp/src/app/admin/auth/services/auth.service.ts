import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';
import { HttpClient } from '@angular/common/http';
import { LoginModel } from '../models/login.model';
import { catchError, map } from 'rxjs/operators';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService {

  constructor(private http: HttpClient, private router: Router) {
    super();
  }


  authenticateUser(loginModel: LoginModel) {
    return this.http
      .post<LoginModel>(
        `${this.baseEndPoint}/api/Account/Authenticate`,
        loginModel,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  logout() {
    localStorage.removeItem('TokenId');
    this.router.navigate(['/auth/login']);
  }

  validateUsername(username) {
    return this.http.get(`${this.baseEndPoint}/api/Account/checkusername?username=${username}`, this.httpOptions)
      .pipe(map(res => res), catchError(this.server4xxError));
  }

  validateEmail(email) {
    return this.http.get(`${this.baseEndPoint}/api/Account/checkemail?email=${email}`, this.httpOptions)
      .pipe(map(res => res), catchError(this.server4xxError));
  }
}
