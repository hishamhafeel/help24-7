import { Component, OnInit, TemplateRef } from '@angular/core';
import { TicketModel } from '../hire-me/models/ticket.model';
import { PaginationBase } from '../shared/models/pagination-base.model';
import { HireMeService } from '../hire-me/services/hire-me.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap';
import { HelperService } from '../shared/services/helper.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HelperModel } from './models/helper.model';
import { HelperCategoryModel } from './models/helper-category.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-helper',
  templateUrl: './helper.component.html',
  styleUrls: ['./helper.component.scss']
})
export class HelperComponent implements OnInit {
  isDashboardClicked: boolean = true;
  isMyJobsClicked: boolean = false;
  isSettingsClicked: boolean = false;
  isRatingClicked: boolean = false;
  isLogoutClicked: boolean = false;

  ticketList: Array<TicketModel>;
  pagination: PaginationBase;
  helperForm: FormGroup;
  ticketModel: TicketModel;
  helperModel: HelperModel;
  helperCategoryList: Array<HelperCategoryModel>
  helperId: number;

  modalRef: BsModalRef;

  constructor(
    private hireMeService: HireMeService,
    private modalService: BsModalService,
    private helperService: HelperService,
    private fb: FormBuilder,
    private router: Router
  ) {
    this.pagination = new PaginationBase();
  }

  ngOnInit(): void {
    this.helperId = +localStorage.getItem('LoggedId');
    this.getHelperById();
  }

  //TICKET START

  getTicketList() {
    this.hireMeService.getTicketListHelper(this.pagination, this.helperId).subscribe(
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

  approveTicket(id) {
    this.hireMeService.approveTicket(id).subscribe(
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

  //TICKET END

  //HELPER START

  getHelperById() {
    this.helperService.getHelperById(this.helperId).subscribe(
      result => {
        console.log('result', result);
        this.helperModel = result;
      },
      error => {
        console.log('error', error);
      }
    );
  }

  getHelperCategory() {
    this.helperService.getHelperCategoryList(this.pagination).subscribe(
      result => {
        console.log('result', result);
        this.helperCategoryList = result.details;
      },
      error => {
        console.log('error', error);
      }
    );
  }

  initHelperForm() {
    this.helperForm = this.fb.group({
      id: [null, [Validators.required]],
      firstName: [null, [Validators.required]],
      lastName: [null, [Validators.required]],
      phoneNo: [null, [Validators.required]],
      mobileNo: [null, [Validators.required]],
      email: [null, [Validators.required]],
      addressLine: [null, [Validators.required]],
      country: [null, [Validators.required]],
      city: [null, [Validators.required]],
      state: [null, [Validators.required]],
      postalCode: [null, [Validators.required]],
      profilePicUrl: ['http://www.rgoogle.com', [Validators.required]],
      experience: [null, [Validators.required]],
      aboutMe: [null, [Validators.required]],
      myService: [null, [Validators.required]],
      helperCategoryId: [null, [Validators.required]]
    });
  }

  patchHelperForm() {
    this.helperForm.patchValue({
      id: this.helperId,
      firstName: this.helperModel.firstName,
      lastName: this.helperModel.lastName,
      phoneNo: this.helperModel.phoneNo,
      mobileNo: this.helperModel.mobileNo,
      email: this.helperModel.email,
      addressLine: this.helperModel.addressLine,
      country: this.helperModel.country,
      city: this.helperModel.city,
      state: this.helperModel.state,
      postalCode: this.helperModel.postalCode,
      profilePicUrl: ['http://www.rgoogle.com', [Validators.required]],
      experience: this.helperModel.experience,
      aboutMe: this.helperModel.aboutMe,
      myService: this.helperModel.myService,
      helperCategoryId: this.helperModel.helperCategory.id,
    });
  }

  onHelperSubmit() {
    if (this.helperForm.invalid) {
      return;
    }
    this.helperModel = this.helperForm.value;

    this.helperService.updateHelper(this.helperModel).subscribe(
      result => {
        console.log('result', result);
        this.getHelperById();
      },
      error => {
        console.log('error', error);
      }
    );
  }

  //HELPER END

  showDashboard() {
    this.isDashboardClicked = true;
    this.isMyJobsClicked = false;
    this.isSettingsClicked = false;
    this.isRatingClicked = false;
    this.isLogoutClicked = false;
  }

  showMyJobs() {
    this.getTicketList();
    this.isDashboardClicked = false;
    this.isMyJobsClicked = true;
    this.isSettingsClicked = false;
    this.isRatingClicked = false;
    this.isLogoutClicked = false;
  }

  showSettings() {
    this.initHelperForm();
    this.patchHelperForm();
    this.isDashboardClicked = false;
    this.isMyJobsClicked = false;
    this.isSettingsClicked = true;
    this.isRatingClicked = false;
    this.isLogoutClicked = false;
  }

  showRatings() {
    this.isDashboardClicked = false;
    this.isMyJobsClicked = false;
    this.isSettingsClicked = false;
    this.isRatingClicked = true;
    this.isLogoutClicked = false;
  }

  logout() {
    localStorage.removeItem('TokenId');
    localStorage.removeItem('LoggedId');
    this.router.navigate(['/auth/login']);
    // this.isDashboardClicked = false;
    // this.isMyJobsClicked = false;
    // this.isSettingsClicked = false;
    // this.isRatingClicked = false;
    // this.isLogoutClicked = true;
  }
}
