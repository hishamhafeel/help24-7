import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ValidatorService } from '../services/validator.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.scss']
})
export class SignupComponent implements OnInit {

  signupForm: FormGroup;
  submitted: boolean = false;

  constructor(private fb: FormBuilder, public validatorService: ValidatorService, private router: Router) { }

  ngOnInit(): void {
    this.initSignUpForm();
    sessionStorage.removeItem('user');
  }

  initSignUpForm() {
    this.signupForm = this.fb.group({
      email: [
        '',
        {
          validators: [Validators.required, Validators.email],
          asyncValidators: [this.validatorService.checkEmail.bind(this.validatorService)],
          updateOn: 'blur'
        }
      ],
      userName: [
        '',
        {
          validators: [Validators.required],
          asyncValidators: [this.validatorService.checkUsername.bind(this.validatorService)],
          updateOn: 'blur'
        }
      ],
      password: ['', [Validators.required]],
      userType: [2, [Validators.required]]
    });
  }

  onSubmit() {
    this.submitted = true;
    // stop here if form is invalid
    if (this.signupForm.invalid) {
      return;
    }
    var t = this.signupForm.value;
    sessionStorage.setItem('user', JSON.stringify(t));
    this.router.navigate(['auth/register/'+this.signupForm.value.userType]);
  }

  get f() {
    return this.signupForm.controls;
  }
}
