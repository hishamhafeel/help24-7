import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';
import { CanActivate, Router } from '@angular/router';
import * as jwt_decode from "jwt-decode";

@Injectable({
  providedIn: 'root'
})
export class AuthGuardCustomerService extends BaseService implements CanActivate {

  constructor(private router: Router) {
    super();
  }

  canActivate() {
    var token = localStorage.getItem('TokenId');
    if (token === null || token === undefined) {
      localStorage.removeItem('TokenId');
      localStorage.removeItem('LoggedId');
      this.router.navigate(['/auth/login']);
      return false;
    }
    else {
      var decoded = jwt_decode(token);
      var role = JSON.parse(JSON.stringify(decoded))["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
      if (role != "Customer") {
        this.router.navigate(['/auth/login']);
        return false;
      }
      return true;
    }
  }
}
