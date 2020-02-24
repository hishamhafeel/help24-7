import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';
import { CanActivate, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService extends BaseService implements CanActivate {

  constructor(private router: Router) {
    super();
  }

  canActivate() {
    if (
      localStorage.getItem('TokenId') === null ||
      localStorage.getItem('TokenId') === undefined
    ) {
      localStorage.removeItem('TokenId');
      this.router.navigate(['/auth/login']);
      return false;
    } else {
      return true;
    }
  }
}
