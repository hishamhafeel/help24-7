import { Component, OnInit, TemplateRef } from '@angular/core';
import { HireMeService } from '../hire-me/services/hire-me.service';
import { TicketModel, FeedbackModel } from '../hire-me/models/ticket.model';
import { PaginationBase } from '../shared/models/pagination-base.model';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { CustomerModel } from './models/customer.model';
import { CustomerService } from './services/customer.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {
  isDashboardClicked: boolean = true;
  isMyTicketsClicked: boolean = false;
  isSettingsClicked: boolean = false;
  isRatingClicked: boolean = false;
  isLogoutClicked: boolean = false;

  ticketList: Array<TicketModel>;
  feedbackList: Array<FeedbackModel>;
  pagination: PaginationBase;
  customerForm: FormGroup;
  feedbackForm: FormGroup;
  ticketModel: TicketModel;
  feedbackModel: FeedbackModel = new FeedbackModel();
  customerModel: CustomerModel = new CustomerModel();
  customerId: number;
  ticketId: number;
  helperId: number;

  modalRef: BsModalRef;

  constructor(
    private hireMeService: HireMeService,
    private modalService: BsModalService,
    private customerService: CustomerService,
    private fb: FormBuilder,
    private router: Router
  ) {
    this.pagination = new PaginationBase();
  }

  ngOnInit(): void {
    this.customerId = +localStorage.getItem('LoggedId');
    this.getCustomerById();
  }


  //TICKET START
  getTicketList() {
    this.hireMeService.getTicketListCustomer(this.pagination, this.customerId).subscribe(
      result => {
        console.log('result', result);
        this.ticketList = result.details;
      },
      error => {
        console.log('error', error);
      }
    );
  }

  getTicketById(id: number) {
    this.hireMeService.getTicketById(id).subscribe(
      result => {
        console.log('result', result);
        this.ticketModel = result;
      },
      error => {
        console.log('error', error);
      }
    );
  }

  completeTicket(id) {
    this.hireMeService.completeTicket(id).subscribe(
      result => {
        console.log('result', result);
        this.getTicketList();
      },
      error => {
        console.log('error', error);
      }
    );
  }

  openModal(template: TemplateRef<any>, data) {
    this.getTicketById(data.id);
    this.modalRef = this.modalService.show(template);
  }

  openReviewModal(template: TemplateRef<any>, ticketId, helperId) {
    this.ticketId = ticketId;
    this.helperId = helperId;
    this.initFeedbackForm();
    this.modalRef = this.modalService.show(template);
  }

  initFeedbackForm() {
    this.feedbackForm = this.fb.group({
      description: [null, [Validators.required]],
      rating: [null, [Validators.required]]
    });
  }

  onFeedbackSubmit() {
    if (this.feedbackForm.invalid) {
      return;
    }
    this.feedbackModel = this.feedbackForm.value;
    this.feedbackModel.customerId = this.customerId;
    this.feedbackModel.helperId = this.helperId;
    this.feedbackModel.ticketId = this.ticketId;

    this.customerService.addFeedback(this.feedbackModel).subscribe(
      result => {
        console.log('result', result);
        this.getCustomerById();
      },
      error => {
        console.log('error', error);
      }
    );
  }

  getFeedbackList() {
    this.customerService.getFeedbackList(this.pagination, this.customerId).subscribe(
      result => {
        console.log('result', result);
        this.feedbackList = result.details;
      },
      error => {
        console.log('error', error);
      }
    );
  }

  //TICKET END

  //CUSTOMER START

  getCustomerById() {
    this.customerService.getCustomerById(this.customerId).subscribe(
      result => {
        console.log('result', result);
        this.customerModel = result;
      },
      error => {
        console.log('error', error);
      }
    );
  }

  initCustomerForm() {
    this.customerForm = this.fb.group({
      id: [null, [Validators.required]],
      name: [null, [Validators.required]],
      phoneNo: [null, [Validators.required]],
      email: [null, [Validators.required]],
      addressLine: [null, [Validators.required]],
      country: [null, [Validators.required]],
      city: [null, [Validators.required]],
      state: [null, [Validators.required]],
      postalCode: [null, [Validators.required]],
      profilePicUrl: ['http://www.google5.com', [Validators.required]]
    });
  }

  patchCustomerForm() {
    this.customerForm.patchValue({
      id: this.customerId,
      name: this.customerModel.name,
      phoneNo: this.customerModel.phoneNo,
      email: this.customerModel.email,
      addressLine: this.customerModel.addressLine,
      country: this.customerModel.country,
      city: this.customerModel.city,
      state: this.customerModel.state,
      postalCode: this.customerModel.postalCode,
      profilePicUrl: ['http://www.google5.com', [Validators.required]]
    });
  }

  onCustomerSubmit() {
    if (this.customerForm.invalid) {
      return;
    }
    this.customerModel = this.customerForm.value;

    this.customerService.updateCustomer(this.customerModel).subscribe(
      result => {
        console.log('result', result);
        this.getCustomerById();
      },
      error => {
        console.log('error', error);
      }
    );
  }

  //CUSTOMER END

  showDashboard() {
    this.isDashboardClicked = true;
    this.isMyTicketsClicked = false;
    this.isSettingsClicked = false;
    this.isRatingClicked = false;
    this.isLogoutClicked = false;
  }

  showMyTickets() {
    this.getTicketList();
    this.isDashboardClicked = false;
    this.isMyTicketsClicked = true;
    this.isSettingsClicked = false;
    this.isRatingClicked = false;
    this.isLogoutClicked = false;
  }

  showSettings() {
    this.initCustomerForm();
    this.patchCustomerForm();
    this.isDashboardClicked = false;
    this.isMyTicketsClicked = false;
    this.isSettingsClicked = true;
    this.isRatingClicked = false;
    this.isLogoutClicked = false;
  }

  showRatings() {
    this.getFeedbackList();
    this.isDashboardClicked = false;
    this.isMyTicketsClicked = false;
    this.isSettingsClicked = false;
    this.isRatingClicked = true;
    this.isLogoutClicked = false;
  }

  logout() {
    localStorage.removeItem('TokenId');
    localStorage.removeItem('LoggedId');
    this.router.navigate(['/auth/login']);
    // this.isDashboardClicked = false;
    // this.isMyTicketsClicked = false;
    // this.isSettingsClicked = false;
    // this.isRatingClicked = false;
    // this.isLogoutClicked = true;
  }
}
