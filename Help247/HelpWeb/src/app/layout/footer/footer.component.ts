import { Component, OnInit } from '@angular/core';
import { MailService } from 'src/app/shared/services/mail.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.scss']
})
export class FooterComponent implements OnInit {

  subscribeEmail: any;
  isError: boolean = false;

  constructor(private mailSerice: MailService, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  sendSubscriptionMail(email) {
    if (email == null) {
      this.isError = true;
      return;
    }
    else {
      this.mailSerice.sendSubscriptionMail(email).subscribe(
        result => {
          this.toastr.success("Mail sent successfully", "Success");
          this.subscribeEmail = null;
        },
        error => {
          this.toastr.error("Error in sending subscription mail", "Error");
        }
      );
    }

  }
}
