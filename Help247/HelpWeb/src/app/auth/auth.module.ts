import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AuthRoutingModule } from './auth-routing.module';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { RegisterComponent } from './register/register.component';
import { ValidatorService } from './services/validator.service';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { FileUploadModule } from "ng2-file-upload";
import { Ng2TelInputModule } from 'ng2-tel-input';

@NgModule({
  declarations: [LoginComponent, SignupComponent, RegisterComponent],
  imports: [
    CommonModule,
    AuthRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    FileUploadModule,
    Ng2TelInputModule

  ],
  providers: [
    ValidatorService,
  ]
})
export class AuthModule { }
