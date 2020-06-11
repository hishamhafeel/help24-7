import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';
import { HttpClient } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends BaseService {

  constructor(
    private http: HttpClient
  ) {
    super();
  }

  validateUsername(username) {
    return this.http.get(`${this.baseEndPoint}` + '/api/Account/checkusername?username=' + username).pipe(map(res => res), catchError(this.server4xxError));
  }

  validateEmail(email) {
    return this.http.get(`${this.baseEndPoint}` + '/api/Account/checkemail?email=' + email).pipe(map(res => res), catchError(this.server4xxError));
  }

  register(model: any) {
    return this.http
      .post(
        `${this.baseEndPoint}/api/Account/register`,
        model,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }
}
