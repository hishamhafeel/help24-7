import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginModel } from '../models/login.model';
import { AuthService } from '../services/auth.service';
import { NotificationService } from 'src/app/shared/services/notification.service';

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
      username: ['admin'],
      password: ['Admin@123']
    })
  }

  authenticateUser() {
    this.isBlocked = true;
    this.loginModel = new LoginModel();
    this.loginModel = Object.assign({}, this.loginModel, this.loginForm.value);
    this.authService.authenticateUser(this.loginModel).subscribe(
      user => {
        localStorage.setItem('TokenId', user.token);
        this.router.navigate(['/dashboard']);
      },
      error => {
        this.notificationService.errorMessage();
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
    this.router.navigate(['/dashboard']);
  }

}