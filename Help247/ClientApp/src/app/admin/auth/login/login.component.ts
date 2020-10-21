import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginModel } from '../models/login.model';
import { AuthService } from '../services/auth.service';
import { NotificationService } from 'src/app/shared/services/notification.service';
import * as jwt_decode from "jwt-decode";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginModel: LoginModel;
  loginForm: FormGroup;
  hide = true;
  isBlocked = false;
  openLock: boolean = false;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private authService: AuthService,
    private notificationService: NotificationService
  ) { }

  ngOnInit() {
    this.initLoginForm();
  }

  initLoginForm() {
    this.loginForm = this.fb.group({
      username: [''],
      password: ['']
    })
  }

  authenticateUser() {
    this.isBlocked = true;
    this.loginModel = new LoginModel();
    this.loginModel = Object.assign({}, this.loginModel, this.loginForm.value);
    this.authService.authenticateUser(this.loginModel).subscribe(
      user => {
        localStorage.setItem('TokenId', user.token);
        var decoded = jwt_decode(user.token);
        var role = JSON.parse(JSON.stringify(decoded))["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
        localStorage.setItem('Role', role);

        this.openLock = true;
        setTimeout(() => {
          this.router.navigate(['/helper']);
        }, 1500);
      },
      error => {
        this.notificationService.errorMessage(error.message);
        this.isBlocked = false;
      }
    );
  }

  get username() {
    return this.loginForm.get('username');
  }
  get password() {
    return this.loginForm.get('password');
  }

  dashboard() {
    this.router.navigate(['/helper']);
  }

}