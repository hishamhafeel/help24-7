import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { LoginModel } from '../models/login.model';
import * as jwt_decode from "jwt-decode";
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginModel: LoginModel;
  loginForm: FormGroup;

  isLoginRequested: boolean = false;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private authService: AuthService,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.initLoginForm();
  }

  initLoginForm() {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required]]
    })
  }

  authenticateUser() {
    if(this.loginForm.invalid){
      return;
    }
    this.isLoginRequested = true;
    this.loginModel = new LoginModel();
    this.loginModel = this.loginForm.value;
    this.authService.authenticateUser(this.loginModel).subscribe(
      user => {

        localStorage.setItem('TokenId', user.token);

        var decoded = jwt_decode(user.token);
        var loggedUserId = JSON.parse(JSON.stringify(decoded))["LoggedInUserId"];
        var role = JSON.parse(JSON.stringify(decoded))["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
        localStorage.setItem('LoggedId', loggedUserId);
        setTimeout(() => {
          if(role == "Helper"){
            this.router.navigate(['/helper']);
          }
          else{
            this.router.navigate(['/customer']);
          }
          this.isLoginRequested = false;
        }, 1500);
      },
      error => {
        this.isLoginRequested = false;
        console.log(error);
        this.toastr.error('Error', error.message);
      }
    );
  }

  get username() {
    return this.loginForm.get('username');
  }
  get password() {
    return this.loginForm.get('password');
  }

}
