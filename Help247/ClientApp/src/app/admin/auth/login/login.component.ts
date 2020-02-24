import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { LoginModel } from '../models/login.model';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginModel: LoginModel;
  loginForm: FormGroup;
  hide = true;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private authService: AuthService
  ) { }

  ngOnInit() {
    this.initLoginForm();
  }

  initLoginForm() {
    this.loginForm = this.fb.group({
      username: ['usamajumaloon'],
      password: ['Admin@123']
    })
  }

  authenticateUser() {
    this.loginModel = new LoginModel();
    this.loginModel = Object.assign({}, this.loginModel, this.loginForm.value);
    this.authService.authenticateUser(this.loginModel).subscribe(
      user => {
        localStorage.setItem('TokenId', JSON.stringify(user.token));
        this.router.navigate(['/dashboard']);
      },
      error => {
        alert('Invalid Login');
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