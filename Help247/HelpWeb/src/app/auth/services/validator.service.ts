import { Injectable } from '@angular/core';
import { FormControl, AbstractControl, FormGroup } from '@angular/forms';
import { AuthService } from './auth.service';

@Injectable()
export class ValidatorService {

    constructor(public authService: AuthService) {

    }

    checkUsername(control: FormControl): any {

        return new Promise(resolve => {
            this.authService.validateUsername(control.value).subscribe((res) => {
                if (res == false) {
                    resolve(null);
                }
                else {
                    resolve({ 'usernameInUse': true });
                }
            }, (err) => {
                resolve({ 'usernameInUse': true });
            });
        });
    }

    checkEmail(control: FormControl): any {

        return new Promise(resolve => {
            this.authService.validateEmail(control.value).subscribe((res) => {
                if (res == false) {
                    resolve(null);
                }
                else {
                    resolve({ 'emailInUse': true });
                }
            }, (err) => {
                resolve({ 'emailInUse': true });
            });
        });
    }

    matchingPasswords(passwordKey: string, confirmPasswordKey: string) {
        return (group: FormGroup): {
            [key: string]: any
        } => {
            let password = group.controls[passwordKey];
            let confirmPassword = group.controls[confirmPasswordKey];

            if (password.value !== confirmPassword.value) {
                return {
                    mismatchedPasswords: true
                };
            }
        }
    }
}