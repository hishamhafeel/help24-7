import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ContactUsModel } from './contact-us.model';
import { ToastrService } from 'ngx-toastr';
import { MailService } from '../shared/services/mail.service';

@Component({
  selector: 'app-contact-us',
  templateUrl: './contact-us.component.html',
  styleUrls: ['./contact-us.component.scss']
})
export class ContactUsComponent implements OnInit {

  contactForm: FormGroup;
  contactFormModel: ContactUsModel;
  constructor(private fb: FormBuilder, private toastr: ToastrService, private mailService: MailService) { }

  ngOnInit(): void {
    this.contactFormInit();
  }

  contactFormInit() {
    this.contactForm = this.fb.group({
      name: [null, [Validators.required]],
      email: [null, [Validators.required, Validators.email]],
      description: [null, [Validators.maxLength(500)]]
    });
  }

  submitContactForm() {
    if (this.contactForm.invalid) {
      return;
    }
    // this.contactFormModel = new ContactUsModel();
    this.contactFormModel = {
      name: this.contactForm.value.name,
      email: this.contactForm.value.email,
      description: this.contactForm.value.description
    };

    this.mailService.sendContactUsMail(this.contactFormModel).subscribe(
      result => {
        this.toastr.success("Email sent successfully. You will be contacted soon.", "Success");
        this.contactForm.reset();
      },
      error => {
        this.toastr.success(error.message, "Error");
      }
    );
  }

}
