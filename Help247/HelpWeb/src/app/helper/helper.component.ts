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
import { FileUploader, FileUploaderOptions, ParsedResponseHeaders } from 'ng2-file-upload';
import { Cloudinary } from '@cloudinary/angular-5.x';
import { ResetPasswordModel } from '../auth/models/resetPassword.model';
import { ValidatorService } from '../auth/services/validator.service';
import { AuthService } from '../auth/services/auth.service';

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
  feedbackModel: FeedbackModel = new FeedbackModel();
  jobsCountModel: JobsCountModel = new JobsCountModel();
  helperCategoryList: Array<HelperCategoryModel>
  helperId: number;
  customerId: number;
  ticketId: number;
  daysToCompleteJob: number = 0;

  modalRef: BsModalRef;

  isHelperRequested: boolean = false;
  isSkillRequested: boolean = false;
  rating: number = 4;
  ratingDescription: string = '';

  uploader: FileUploader;
  url: string;
  urlList: Array<string> = [];
  isUploadRequested: boolean = false;
  public_id: string = "";
  image1: string = "";
  image2: string = "";
  image3: string = "";
  image4: string = "";
  image5: string = "";
  imageList: Array<string> = [];
  feedbackString: string = null;
  accountForm: FormGroup;
  resetPass: any;
  forgotPasswordModel: any;

  constructor(
    private hireMeService: HireMeService,
    private modalService: BsModalService,
    private helperService: HelperService,
    private fb: FormBuilder,
    private router: Router,
    private toastr: ToastrService,
    private cloudinary: Cloudinary,
    public validatorService: ValidatorService,
    private authService: AuthService
  ) {
    this.pagination = new PaginationBase();

    const uploaderOptions: FileUploaderOptions = {
      url: `https://api.cloudinary.com/v1_1/${this.cloudinary.config().cloud_name}/upload`,
      autoUpload: false,
      isHTML5: true,
      removeAfterUpload: true,
      headers: [
        {
          name: 'X-Requested-With',
          value: 'XMLHttpRequest'
        }
      ]
    };
    this.uploader = new FileUploader(uploaderOptions);
  }

  ngOnInit(): void {
    this.helperId = +localStorage.getItem('LoggedId');
    this.getJobCount(this.helperId);
    this.getHelperById();
    this.getHelperCategory();
    this.getSkills();
    this.getImages();
    this.getFeedbacksForHelper(this.helperId);
    this.getTicketList();

    this.uploader.onBuildItemForm = (fileItem: any, form: FormData): any => {
      // Add Cloudinary's unsigned upload preset to the upload form
      form.append('upload_preset', this.cloudinary.config().upload_preset);
      form.append('folder', 'angular_sample');
      if (this.public_id != "") {
        form.append('public_id', this.public_id);
      }
      form.append('file', fileItem);

      // Use default "withCredentials" value for CORS requests
      fileItem.withCredentials = false;
      return { fileItem, form };
    };
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
        this.ticketList = result.details;
        console.log('tl', this.ticketList);
        this.ticketList.forEach(element => {
          if (element.ticketStatusId == 2) {
            this.ticketModel = element;
            this.daysToCompleteJob = this.calculateDaysCount(element.createdOn);
            return;
          }
        });
      },
      error => {
        this.toastr.error('Error', error.message);
      }
    );
  }

  calculateDaysCount(createdOn: Date): number {
    const today = new Date();
    const createdOnConverted = new Date(createdOn);
    let differenceInTime = today.getTime() - createdOnConverted.getTime();
    differenceInTime = Math.ceil(differenceInTime / (1000 * 3600 * 24));
    console.log(differenceInTime);
    return differenceInTime;
  }

  getTicketById(id: number) {
    this.hireMeService.getTicketById(id).subscribe(
      result => {
        this.ticketModel = result;
      },
      error => {
        this.toastr.error('Error', error.message);
      }
    );

    this.helperService.getFeedbackByTicketId(id).subscribe(
      result => {
        this.feedbackString = result.description;
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

  rejectTicket(id: number) {
    this.helperService.cancelTicket(id).subscribe(
      result => {
        this.toastr.success('Cancel Success', "Successfully rejected ticket!");
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
  closeModal() {
    this.modalRef.hide();

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
      profilePicUrl: [null],
      experience: [null, [Validators.required]],
      aboutMe: [null, [Validators.required]],
      myService: [null, [Validators.required]],
      helperCategoryId: [null, [Validators.required]]
    });
  }

  get h() {
    return this.helperForm.controls;
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
      //profilePicUrl: 'http://www.rgoogle.com',
      experience: this.helperModel.experience,
      aboutMe: this.helperModel.aboutMe,
      myService: this.helperModel.myService,
      helperCategoryId: this.helperModel.helperCategory.id,
    });
    this.url = this.helperModel.image.imageUrl;
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
      this.toastr.error('Error', "Only 5 skills are allowed");

      return;
    }
    this.skills.push(this.fb.control(''))
  }

  deleteSkill(i: number) {
    this.skills.removeAt(i);
  }

  onSkillSubmit() {
    if (this.skillModel == null) {
      this.skillModel = new SkillModel();
    }
    this.skillModel.skillNames = this.skillForm.value.skills;
    this.skillModel.helperId = this.helperId;
    this.isSkillRequested = true;
    this.helperService.addSkill(this.skillModel).subscribe(
      result => {
        console.log('result', result);
        this.getHelperById();
        this.isSkillRequested = false;
        this.toastr.success("Success", "Skills successfully updated");

      },
      error => {
        this.toastr.error('Error', error.message);
        this.isSkillRequested = false;
      }
    );
  }

  onHelperSubmit() {
    if (this.helperForm.invalid) {
      return;
    }
    this.helperModel = this.helperForm.value;
    this.helperModel.experience = +this.helperForm.value.experience;
    this.isHelperRequested = true;

    if (this.uploader.queue.length == 0) {
      this.updateHelper();
    }
    else {
      this.uploader.queue[0].upload();

      this.uploader.onErrorItem = (item: any, response: string, status: number, headers: ParsedResponseHeaders) => {
        this.isHelperRequested = false;
        console.log("Image upload failed");
      }

      // Update model on completion of uploading a file
      this.uploader.onCompleteItem = (item: any, response: string, status: number, headers: ParsedResponseHeaders) => {
        this.url = JSON.parse(response).url;
        this.toastr.success("Image uploaded successfully", "Success");
        this.updateHelper();
      }
    }
  }

  updateHelper() {
    this.helperModel.profilePicUrl = this.url;
    this.helperService.updateHelper(this.helperModel).subscribe(
      result => {
        this.toastr.success("Helper profile successfully updated", "Success");
        this.getHelperById();
        this.isHelperRequested = false;
      },
      error => {
        this.isHelperRequested = false;
        this.toastr.error(error.message, "Error");
      }
    );
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
    debugger
    this.resetPass = new ResetPasswordModel();
    this.resetPass.email = this.helperModel.email;
    this.forgotPasswordModel.email = this.helperModel.email;
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

  //HELPER END

  //FEEDBACK START

  getFeedbacksForHelper(id: number) {
    this.helperService.getFeedbackByHelperId(id).subscribe(
      result => {
        this.feedbackList = result;
        this.feedbackModel = result[0];
      },
      error => {
        this.toastr.error('Error', error.message);
      }
    );
  }

  getFeedbackById(id: number) {
    this.helperService.getFeedbackById(id).subscribe(
      result => {
        this.feedbackModel = result;
      },
      error => {
        this.toastr.error('Error', error.message);
      }
    )
  }
  openFeedbackModal(template: TemplateRef<any>, data) {
    this.rating = data.rating;
    this.ratingDescription = data.description;
    this.modalRef = this.modalService.show(template);
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
    //this.getTicketList();
    this.isDashboardClicked = false;
    this.isMyJobsClicked = true;
    this.isSettingsClicked = false;
    this.isRatingClicked = false;
    this.isLogoutClicked = false;
  }

  showSettings() {
    this.initHelperForm();
    this.initAccountForm();
    this.initSkillsForm();
    this.patchHelperForm();
    if (this.skillModel != null) {
      this.patchSkillForm();
    }
    this.isDashboardClicked = false;
    this.isMyJobsClicked = false;
    this.isSettingsClicked = true;
    this.isRatingClicked = false;
    this.isLogoutClicked = false;
  }

  showRatings() {
    // this.getFeedbacksForHelper(this.helperId);
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
  }

  fileChangeEvent() {
    this.public_id = `img_${Date.now()}`;
  }

  fileUpload() {
    this.isUploadRequested = true;
    this.uploader.uploadAll();
    var count = this.uploader.queue.length;

    this.uploader.onErrorItem = (item: any, response: string, status: number, headers: ParsedResponseHeaders) => {
      console.log("Image upload failed");
    }

    this.uploader.onCompleteItem = (item: any, response: string, status: number, headers: ParsedResponseHeaders) => {
      this.urlList.push(JSON.parse(response).url);
      count--;
      console.log(JSON.parse(response));
      console.log(count);
      if (count == 0) {
        this.postUpload();
      }
    }
  }

  getImages() {
    this.helperService.getImages(this.helperId).subscribe(
      result => {
        console.log('Images', result);
        this.imageList = [];
        let self = this
        result.forEach(function (value, i) {
          self.imageList.push(value.imageUrl);
          if (i == 0) {
            self.image1 = value.imageUrl.split("profile_pic/").pop();
          } else if (i == 1) {
            self.image2 = value.imageUrl.split("profile_pic/").pop();
          } else if (i == 2) {
            self.image3 = value.imageUrl.split("profile_pic/").pop();
          } else if (i == 3) {
            self.image4 = value.imageUrl.split("profile_pic/").pop();
          } else if (i == 4) {
            self.image5 = value.imageUrl.split("profile_pic/").pop();
          }
        });
      },
      error => {
        this.toastr.error('Error', error.message);
      }
    );
  }

  postUpload() {
    var imageListModel = {
      imageUrls: this.urlList
    }
    this.helperService.uploadImages(imageListModel).subscribe(
      result => {
        console.log('result', result);
        this.isUploadRequested = false;
      },
      error => {
        console.log('error', error.message);
        this.isUploadRequested = false;
      }
    );
  }

  onFileChanged(event, num) {
    switch (num) {
      case 1: this.image1 = event.target.files[0].name; break;
      case 2: this.image2 = event.target.files[0].name; break;
      case 3: this.image3 = event.target.files[0].name; break;
      case 4: this.image4 = event.target.files[0].name; break;
      case 5: this.image5 = event.target.files[0].name; break;
    }
  }


}
