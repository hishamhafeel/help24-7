import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';
import { HttpClient } from '@angular/common/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import { LoginModel } from '../models/login.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService{

  constructor(private http: HttpClient) {
    super()
   }

   authenticateUser(loginModel: LoginModel) {
    return this.http
      .post<LoginModel>(
        `${this.baseEndPoint}/api/Account/Authenticate`,
        loginModel,
        this.httpOptions
      )
      .pipe(this.server4xxError);
  }
}
