import { Component, OnInit, TemplateRef } from '@angular/core';
import { HireMeService } from '../hire-me/services/hire-me.service';
import { TicketModel, FeedbackModel } from '../hire-me/models/ticket.model';
import { PaginationBase } from '../shared/models/pagination-base.model';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { CustomerModel } from './models/customer.model';
import { CustomerService } from './services/customer.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import {
  FileUploader,
  FileUploaderOptions,
  ParsedResponseHeaders,
} from 'ng2-file-upload';
import { Cloudinary } from '@cloudinary/angular-5.x';
import { ToastrService } from 'ngx-toastr';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { HelperService } from '../shared/services/helper.service';
import { HelperModel } from '../helper/models/helper.model';
import { HelperCategoryModel } from '../helper/models/helper-category.model';
import { ValidatorService } from '../auth/services/validator.service';
import { ResetPasswordModel } from '../auth/models/resetPassword.model';
import { AuthService } from '../auth/services/auth.service';
import { ForgotPasswordModel } from '../auth/models/forgotPassword.model';
import { TokenModel } from './models/token.model';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss'],
})
export class CustomerComponent implements OnInit {
  isDashboardClicked: boolean = true;
  isMyTicketsClicked: boolean = false;
  isSettingsClicked: boolean = false;
  isRatingClicked: boolean = false;
  isLogoutClicked: boolean = false;

  ticketList: Array<TicketModel>;
  feedbackList: Array<FeedbackModel>;
  helperList: Array<HelperModel>;
  helperCategoryList: Array<HelperCategoryModel>;
  pagination: PaginationBase;
  customerForm: FormGroup;
  feedbackForm: FormGroup;
  ticketForm: FormGroup;
  accountForm: FormGroup;
  ticketModel: TicketModel = new TicketModel();
  feedbackModel: FeedbackModel = new FeedbackModel();
  customerModel: CustomerModel = new CustomerModel();
  lastTicketModel: TicketModel = new TicketModel();
  tokenModel: TokenModel = new TokenModel();
  forgotPasswordModel: ForgotPasswordModel = new ForgotPasswordModel()
  customerId: number;
  ticketId: number;
  helperId: number;
  uploader: FileUploader;
  url: string;
  public_id: string = '';
  modalRef: BsModalRef;
  isCustomerRequested: boolean = false;
  fromDate: Date;
  toDate: Date;
  rating: number = 4;
  ratingDescription: string = '';
  feedbackId: number;
  resetPass: ResetPasswordModel;
  token: string = null;
  emailId: string = null;
  customOptions: OwlOptions = {
    loop: true,
    nav: true,
    dots: false,
    items: 4,
    navText: [
      "<img src='assets/images/slider-prv.png'>",
      "<img src='assets/images/slider-nxt.png'>",
    ],
    responsive: {
      0: {
        items: 1,
      },
      400: {
        items: 3,
      },
      768: {
        items: 3,
      },
      1024: {
        items: 4,
      },
    },
  };

  helperOptions: OwlOptions = {
    loop: true,
    nav: true,
    dots: false,
    navText: [
      "<img src='assets/images/slider-prv.png'>",
      "<img src='assets/images/slider-nxt.png'>",
    ],
    responsive: {
      0: {
        items: 1,
      },
      400: {
        items: 2,
      },
      768: {
        items: 2,
      },
      1024: {
        items: 3,
      },
    },
  };

  isEdit: boolean = false;

  constructor(
    private hireMeService: HireMeService,
    private modalService: BsModalService,
    private customerService: CustomerService,
    private fb: FormBuilder,
    private router: Router,
    private cloudinary: Cloudinary,
    private toastr: ToastrService,
    private helperService: HelperService,
    public validatorService: ValidatorService,
    private authService: AuthService
  ) {
    this.pagination = new PaginationBase();

    const uploaderOptions: FileUploaderOptions = {
      url: `https://api.cloudinary.com/v1_1/${
        this.cloudinary.config().cloud_name
        }/upload`,
      autoUpload: false,
      isHTML5: true,
      removeAfterUpload: true,
      headers: [
        {
          name: 'X-Requested-With',
          value: 'XMLHttpRequest',
        },
      ],
    };
    this.uploader = new FileUploader(uploaderOptions);
  }

  ngOnInit(): void {
    this.customerId = +localStorage.getItem('LoggedId');
    this.getLastTicketDetails();
    this.getCustomerById();
    this.getTopHelpers();
    this.getHelperCategory();



    this.uploader.onBuildItemForm = (fileItem: any, form: FormData): any => {
      // Add Cloudinary's unsigned upload preset to the upload form
      form.append('upload_preset', this.cloudinary.config().upload_preset);
      form.append('folder', 'angular_sample');
      form.append('file', fileItem);
      form.append('public_id', this.public_id);

      // Use default "withCredentials" value for CORS requests
      fileItem.withCredentials = false;
      return { fileItem, form };
    };
  }

  initAccountForm() {
    this.accountForm = this.fb.group({
      newPassword: ['', [Validators.required]],
      newPasswordConfirm: ['', [Validators.required]]
    }, { validator: this.validatorService.matchingPasswords('newPassword', 'newPasswordConfirm') })
  }

  get newPassword() {
    return this.accountForm.get('newPassword');
  }

  get newPasswordConfirm() {
    return this.accountForm.get('newPasswordConfirm');
  }

  resetPassword() {
    this.resetPass = new ResetPasswordModel();
    this.resetPass.email = this.customerModel.email;
    this.forgotPasswordModel.email = this.customerModel.email;
    this.resetPass.newPassword = this.newPasswordConfirm.value;

    this.authService.changePasswordLoggedIn(this.resetPass).subscribe(
      result => {
        this.toastr.success("Password succesfully changed. Login with new password!", "Success");
        this.logout()
      },
      error => {
        this.toastr.error(error.message, "Failed");
      }
    );
  }

  getLastTicketDetails() {
    this.customerService.getLastTicket().subscribe(
      result => {
        this.lastTicketModel = result;
      }
    );
  }
  getTopHelpers() {
    this.pagination.take = 10;
    this.helperService.getHelperList(this.pagination).subscribe(
      (result) => {
        console.log('result', result);
        this.helperList = result.details;
        console.log('hl', this.helperList);
      },
      (error) => {
        console.log('error', error);
      }
    );
  }

  getHelperCategory() {
    this.pagination.take = 8;
    this.helperService.getHelperCategoryList(this.pagination).subscribe(
      (result) => {
        this.helperCategoryList = result.details;
      },
      (error) => {
        console.log('error', error);
      }
    );
  }

  //TICKET START
  getTicketList() {
    this.hireMeService
      .getTicketListCustomer(this.pagination, this.customerId)
      .subscribe(
        (result) => {
          console.log('result', result);
          this.ticketList = result.details;
        },
        (error) => {
          console.log('error', error);
        }
      );
  }

  getTicketById(id: number) {
    this.hireMeService.getTicketById(id).subscribe(
      (result) => {
        this.ticketModel = result;
        if (this.isEdit) {
          this.patchTicketForm();
        }
      },
      (error) => {
        console.log('error', error);
      }
    );
  }

  completeTicket(id) {
    this.hireMeService.completeTicket(id).subscribe(
      (result) => {
        console.log('result', result);
        this.getTicketList();
      },
      (error) => {
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
      rating: [null, [Validators.required]],
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
      (result) => {
        this.toastr.success('Feedback successfully submitted');
        this.modalRef.hide();
        this.getCustomerById();
        this.getTicketList();
      },
      (error) => {
        this.toastr.error(error, error.Message);
      }
    );
  }

  getFeedbackList() {
    this.customerService
      .getFeedbackList(this.pagination, this.customerId)
      .subscribe(
        (result) => {
          console.log('result', result);
          this.feedbackList = result.details;
        },
        (error) => {
          console.log('error', error);
        }
      );
  }

  openTicketModal(template: TemplateRef<any>, data) {
    this.isEdit = true;
    this.initTicketForm();
    this.getTicketById(data.id);

    this.modalRef = this.modalService.show(template);
  }

  initTicketForm() {
    this.ticketForm = this.fb.group({
      title: [null, [Validators.required]],
      helpTime: [new Date(), [Validators.required]],
      country: [null, [Validators.required]],
      state: [null, [Validators.required]],
      city: [null, [Validators.required]],
      address: [null, [Validators.required]],
      contactNo1: [null, [Validators.required]],
      contactNo2: [null, [Validators.required]],
      // helpDateFrom: [new Date(), [Validators.required]],
      // helpDateTo: [new Date(), [Validators.required]],
      otherRequirements: [null, [Validators.required]],
    });
  }

  patchTicketForm() {
    this.ticketForm.patchValue({
      title: this.ticketModel.title,
      helpTime: this.ticketModel.helpTime,
      country: this.ticketModel.country,
      state: this.ticketModel.state,
      city: this.ticketModel.city,
      address: this.ticketModel.address,
      contactNo1: this.ticketModel.contactNo1,
      contactNo2: this.ticketModel.contactNo2,
      otherRequirements: this.ticketModel.otherRequirements,
      // helpDateFrom: new Date(this.ticketModel.helpDateFrom),
      // helpDateTo: new Date(this.ticketModel.helpDateTo),
    });
    this.fromDate = new Date(this.ticketModel.helpDateFrom);
    this.toDate = new Date(this.ticketModel.helpDateTo);
  }
  async onTicketSubmit() {
    if (this.ticketForm.invalid) {
      return;
    }
    this.ticketModel.title = this.ticketForm.value.title;
    this.ticketModel.helpTime = this.ticketForm.value.helpTime;
    this.ticketModel.country = this.ticketForm.value.country;
    this.ticketModel.helpDateFrom = this.fromDate;
    this.ticketModel.helpDateTo = this.toDate;
    this.ticketModel.state = this.ticketForm.value.state;
    this.ticketModel.city = this.ticketForm.value.city;
    this.ticketModel.address = this.ticketForm.value.address;
    this.ticketModel.contactNo1 = this.ticketForm.value.contactNo1;
    this.ticketModel.contactNo2 = this.ticketForm.value.contactNo2;
    this.ticketModel.otherRequirements = this.ticketForm.value.otherRequirements;

    this.customerService.updateTicket(this.ticketModel).subscribe(
      (result) => {
        this.toastr.success('Ticket successfully updated');
        this.modalRef.hide();
        this.getTicketList();
      },
      (error) => {
        this.toastr.error('Error', error.message);
      }
    );
  }

  async formatAMPM(date) {
    var hours = date.getHours();
    var minutes = date.getMinutes();
    var ampm = hours >= 12 ? 'pm' : 'am';
    hours = hours % 12;
    hours = hours ? hours : 12; // the hour '0' should be '12'
    minutes = minutes < 10 ? '0' + minutes : minutes;
    var strTime = hours + ':' + minutes + ' ' + ampm;
    return strTime;
  }

  onChangeDateFrom(event: Date) {
    this.fromDate = event;
  }

  onChangeDateTo(event: any) {
    this.toDate = event;
  }

  //TICKET END

  //CUSTOMER START

  getCustomerById() {
    this.customerService.getCustomerById(this.customerId).subscribe(
      (result) => {
        console.log('result', result);
        this.customerModel = result;
      },
      (error) => {
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
      profilePicUrl: [null]
    });
  }

  get c() {
    return this.customerForm.controls;
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
      postalCode: this.customerModel.postalCode
    });
    this.url = this.customerModel.image.imageUrl;
  }

  onCustomerSubmit() {
    if (this.customerForm.invalid) {
      return;
    }
    this.customerModel = this.customerForm.value;
    this.isCustomerRequested = true;

    if (this.uploader.queue.length == 0) {
      this.updateCustomer();
    }
    else {
      this.uploader.queue[0].upload();

      this.uploader.onErrorItem = (item: any, response: string, status: number, headers: ParsedResponseHeaders) => {
        this.isCustomerRequested = false;
        this.toastr.error("Image upload failed", "Error");
      }

      // Update model on completion of uploading a file
      this.uploader.onCompleteItem = (item: any, response: string, status: number, headers: ParsedResponseHeaders) => {
        this.url = JSON.parse(response).url;
        this.toastr.success("Image upload successful", "Success");
        this.updateCustomer();
      }
    }
  }

  updateCustomer() {
    debugger
    this.customerModel.profilePicUrl = this.url;
    this.customerService.updateCustomer(this.customerModel).subscribe(
      result => {
        this.toastr.success("Successfully saved profile settings", "Success");
        this.getCustomerById();
        this.isCustomerRequested = false;
      },
      error => {
        this.toastr.error(error.Message, "Error");
        this.isCustomerRequested = false;
      }
    );
  }

  //CUSTOMER END

  //FEEDBACK START

  openReviewEditModal(template: TemplateRef<any>, feedbackId, helperId, ticketId) {
    this.helperId = helperId;
    this.ticketId = ticketId;
    this.feedbackId = feedbackId;
    this.initFeedbackForm();
    this.getFeedback(feedbackId);
    this.modalRef = this.modalService.show(template);
  }

  getFeedback(feedbackId: number) {
    this.customerService.getFeedback(feedbackId).subscribe(
      (result) => {
        this.feedbackModel = result;
        this.patchFeedbackForm();
      },
      (error) => {
        this.toastr.error(error, error.Message);
      });
  }
  patchFeedbackForm() {
    this.feedbackForm.patchValue({
      rating: this.feedbackModel.rating,
      description: this.feedbackModel.description,
    });
  }
  onFeedbackEdit() {
    if (this.feedbackForm.invalid) {
      return;
    }
    this.feedbackModel = this.feedbackForm.value;
    this.feedbackModel.id = this.feedbackId;

    this.customerService.updateFeedback(this.feedbackModel).subscribe(
      (result) => {
        this.toastr.success('Feedback successfully updated');
        this.modalRef.hide();
        this.getFeedbackList();
      },
      (error) => {
        this.toastr.error(error, error.Message);
      }
    );
  }

  openReviewDeleteModal(template: TemplateRef<any>, feedbackId) {
    this.feedbackId = feedbackId;
    this.modalRef = this.modalService.show(template);
  }

  deleteFeedback() {
    this.customerService.deleteFeedback(this.feedbackId).subscribe(
      (result) => {
        this.toastr.success('Feedback successfully deleted');
        this.modalRef.hide();
        this.getFeedbackList();
      },
      (error) => {
        this.toastr.error(error, error.Message);
      }
    );
  }
  //FEEDBACK END
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
    this.initAccountForm();
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
  }

  fileChangeEvent() {
    this.public_id = `img_${Date.now()}`;
  }
}
