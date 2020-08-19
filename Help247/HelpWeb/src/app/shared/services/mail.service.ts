import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from 'src/app/core/services/base.service';
import { catchError } from 'rxjs/operators';
import { ContactUsModel } from 'src/app/contact-us/contact-us.model';

@Injectable({
  providedIn: 'root'
})
export class MailService extends BaseService {

  constructor(
    private http: HttpClient
  ) {
    super();
  }

  sendSubscriptionMail(email: string) {
    return this.http
      .post(
        `${this.baseEndPoint}/api/common/subsribe/${email}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  sendContactUsMail(model: ContactUsModel) {
    return this.http
      .post(
        `${this.baseEndPoint}/api/common/subsribe/contactus`,
        model,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

}
