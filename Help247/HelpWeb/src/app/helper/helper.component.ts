import { Component, OnInit, TemplateRef } from '@angular/core';
import { TicketModel, FeedbackModel } from '../hire-me/models/ticket.model';
import { PaginationBase } from '../shared/models/pagination-base.model';
import { HireMeService } from '../hire-me/services/hire-me.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap';
import { HelperService } from '../shared/services/helper.service';
import { FormGroup, FormBuilder, Validators, FormArray } from '@angular/forms';
import { HelperModel } from './models/helper.model';
import { HelperCategoryModel } from './models/helper-category.model';
import { Router } from '@angular/router';
import { SkillModel } from './models/skills.model';
import { JobsCountModel } from './models/jobs.model';
import { ToastrService } from 'ngx-toastr';

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
  feedbackList: Array<FeedbackModel>;
  pagination: PaginationBase;
  helperForm: FormGroup;
  skillForm: FormGroup;
  ticketModel: TicketModel = new TicketModel();
  helperModel: HelperModel = new HelperModel();
  skillModel: SkillModel = new SkillModel();
  jobsCountModel: JobsCountModel = new JobsCountModel();
  helperCategoryList: Array<HelperCategoryModel>
  helperId: number;

  modalRef: BsModalRef;

  constructor(
    private hireMeService: HireMeService,
    private modalService: BsModalService,
    private helperService: HelperService,
    private fb: FormBuilder,
    private router: Router,
    private toastr: ToastrService

  ) {
    this.pagination = new PaginationBase();
  }

  ngOnInit(): void {
    this.helperId = +localStorage.getItem('LoggedId');
    this.getJobCount(this.helperId);
    this.getHelperById();
    this.getSkills();
  }
  //DASHBOARD START

  getJobCount(helperId: number) {
    this.helperService.getJobCount(helperId).subscribe(
      result => {
        this.jobsCountModel = result;
      },
      error => {
        this.toastr.error('Error', error.message);
      }
    );
  }

  //DARSHBOARD END

  //TICKET START

  getTicketList() {
    this.hireMeService.getTicketListHelper(this.pagination, this.helperId).subscribe(
      result => {
        console.log('result', result);
        this.ticketList = result.details;
      },
      error => {
        this.toastr.error('Error', error.message);
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
        this.toastr.error('Error', error.message);
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
        this.toastr.error('Error', error.message);
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
        this.toastr.error('Error', error.message);
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
        this.toastr.error('Error', error.message);
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

  getSkills() {
    this.helperService.getSkill(this.helperId).subscribe(
      result => {
        console.log('result', result);
        this.skillModel = result;
      },
      error => {
        this.toastr.error('Error', error.message);
      }
    );
  }

  initSkillsForm() {
    this.skillForm = this.fb.group({
      skills: this.fb.array([])
    });
  }

  patchSkillForm() {
    this.skillModel.skillNames.forEach(element => {
      console.log(element);
      this.skills.push(this.fb.control(element))
    });
  }

  get skills() {
    return this.skillForm.get('skills') as FormArray;
  }

  addNewSkill() {
    if (this.skills.controls.length >= 5) {
      return;
    }
    this.skills.push(this.fb.control(''))
  }

  deleteSkill(i: number) {
    this.skills.removeAt(i);
  }

  onSkillSubmit() {
    this.skillModel.skillNames = this.skillForm.value.skills;
    this.skillModel.helperId = this.helperId;
    this.helperService.addSkill(this.skillModel).subscribe(
      result => {
        console.log('result', result);
        this.getHelperById();
      },
      error => {
        this.toastr.error('Error', error.message);
      }
    );
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
        this.toastr.error('Error', error.message);
      }
    );
  }

  //HELPER END

  //FEEDBACK START

  getFeedbacksForHelper(id: number) {
    this.helperService.getFeedbackByHelperId(id).subscribe(
      result => {
        this.feedbackList = result;
      },
      error => {
        this.toastr.error('Error', error.message);
      }
    );
  }

  //FEEDBACK END

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
    this.initSkillsForm();
    this.patchHelperForm();
    this.patchSkillForm();
    this.isDashboardClicked = false;
    this.isMyJobsClicked = false;
    this.isSettingsClicked = true;
    this.isRatingClicked = false;
    this.isLogoutClicked = false;
  }

  showRatings() {
    this.getFeedbacksForHelper(this.helperId);
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
