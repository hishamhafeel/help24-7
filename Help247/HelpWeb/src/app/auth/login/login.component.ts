import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, AbstractControl, ValidationErrors, ValidatorFn } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { LoginModel } from '../models/login.model';
import * as jwt_decode from "jwt-decode";
import { ToastrService } from 'ngx-toastr';
import { ForgotPasswordModel } from '../models/forgotPassword.model';
import { ValidatorService } from '../services/validator.service';
import { ResetPasswordModel } from '../models/resetPassword.model';

// const passwordMatcher: ValidatorFn = (c: FormGroup): ValidationErrors | null => {
//   const passwordControl = c.get('newPassword');
//   const confirmControl = c.get('newPasswordConfirm');

//   return passwordControl.value != confirmControl.value ? { 'match': true } : null;
// }


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  loginModel: LoginModel;
  forgotPassword: ForgotPasswordModel;
  loginForm: FormGroup;
  resetForm: FormGroup;
  newPasswordForm: FormGroup;
  token: string = null;
  emailId: string = null;
  resetPass: ResetPasswordModel;

  isLoginRequested: boolean = false;
  isPasswordRequested: boolean = false;
  isPasswordRequestedSubmit: boolean = false;
  isResetPassword: boolean = false;

  constructor(
    private fb: FormBuilder,
    private router: Router,
    private authService: AuthService,
    private toastr: ToastrService,
    private route: ActivatedRoute,
    public validatorService: ValidatorService
  ) { }

  ngOnInit(): void {
    this.route.queryParamMap.subscribe(params => {
      this.token = params.get('token');
      this.emailId = params.get('email');
    })
    if (this.token != undefined) {
      this.isResetPassword = true;
      this.initNewPasswordForm();
    }
    else {
      this.initLoginForm();
    }
  }

  initLoginForm() {
    this.loginForm = this.fb.group({
      username: ['', [Validators.required]],
      password: ['', [Validators.required]]
    })
  }

  initNewPasswordForm() {
    this.newPasswordForm = this.fb.group({
      newPassword: ['', [Validators.required]],
      newPasswordConfirm: ['', [Validators.required]]
    }, { validator: this.validatorService.matchingPasswords('newPassword', 'newPasswordConfirm') })
  }

  authenticateUser() {
    if (this.loginForm.invalid) {
      return;
    }
    localStorage.removeItem('TokenId');
    localStorage.removeItem('LoggedId');
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
          if (role == "Helper") {
            this.router.navigate(['/helper']);
          }
          else {
            this.router.navigate(['/customer']);
          }
          this.isLoginRequested = false;
        }, 1500);
      },
      error => {
        this.isLoginRequested = false;
        console.log(error);
        this.toastr.error(error.message, 'Error!',);
      }
    );
  }

  get username() {
    return this.loginForm.get('username');
  }
  get password() {
    return this.loginForm.get('password');
  }

  forgotPasswordClicked() {
    this.initResetForm();
    this.isPasswordRequested = true;
  }
  initResetForm() {
    this.resetForm = this.fb.group({
      email: ['', [Validators.required, Validators.email]],
    });
  }

  get email() {
    return this.resetForm.get('email');
  }

  SendForgotPasswordMail() {
    this.isPasswordRequestedSubmit = true;
    if (!this.resetForm.valid) {
      this.toastr.error("Please enter a valid email address", "Error!")
      this.isPasswordRequestedSubmit = false;
      return;
    }
    this.forgotPassword = new ForgotPasswordModel();
    this.forgotPassword.email = this.resetForm.value.email;
    this.authService.sendForgotPasswordMail(this.forgotPassword).subscribe(
      result => {
        this.toastr.success("Please check your email to reset your password.", "Mail Sent!")
        this.isPasswordRequested = false;
        this.isPasswordRequestedSubmit = false;
      },
      error => {
        if (error.status) {
          this.toastr.error("Email not found, check your email and try again!", "Error!");
        }
        else {
          this.toastr.error(error.message.errors.Email, "Error!");
        }
        this.isPasswordRequestedSubmit = false;
      }
    );
  }

  get newPassword() {
    return this.newPasswordForm.get('newPassword');
  }

  get newPasswordConfirm() {
    return this.newPasswordForm.get('newPasswordConfirm');
  }

  resetPassword() {
    this.resetPass = new ResetPasswordModel();
    this.resetPass.token = this.token;
    this.resetPass.email = this.emailId;
    this.resetPass.newPassword = this.newPasswordConfirm.value;

    this.authService.resetPassword(this.resetPass).subscribe(
      result => {
        this.toastr.success("Password succesfully changed. Login with new password!", "Success");
        this.isResetPassword = false;
        this.router.navigate(['/auth/login']);
      },
      error => {
        this.toastr.error(error.message, "Failed");
      }
    );
  }

}
