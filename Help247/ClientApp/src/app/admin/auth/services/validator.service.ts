import { Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { FormControl } from '@angular/forms';


@Injectable({
    providedIn: 'root'
})
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
}