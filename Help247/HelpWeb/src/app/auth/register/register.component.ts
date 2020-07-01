import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { CustomerRegisterModel, RegisterModel, HelperRegisterModel } from '../models/register.model';
import { AuthService } from '../services/auth.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HelperService } from 'src/app/shared/services/helper.service';
import { PaginationBase } from 'src/app/shared/models/pagination-base.model';
import { HelperCategoryModel } from 'src/app/helper/models/helper-category.model';
import { FileUploader, FileUploaderOptions, ParsedResponseHeaders } from 'ng2-file-upload';
import { Cloudinary } from '@cloudinary/angular-5.x';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  customerForm: FormGroup;
  helperForm: FormGroup;

  userType: number;
  customerModel: CustomerRegisterModel;
  registerModel: RegisterModel;
  helperModel: HelperRegisterModel;
  helperCategoryList: Array<HelperCategoryModel>
  pagination: PaginationBase;

  uploader: FileUploader;
  url: string;
  public_id: string = "";
  isFormSubmitted: boolean = false;

  isHelperRequested: boolean = false;
  isCustomerRequested: boolean = false;

  constructor(private toastr: ToastrService, private cloudinary: Cloudinary, private helperService: HelperService, private route: ActivatedRoute, private router: Router, private fb: FormBuilder, private authService: AuthService) {
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

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.userType = +params.get('userType');
    });
    this.registerModel = JSON.parse(sessionStorage.getItem('user'));
    this.initCustomerForm();
    this.initHelperForm();
    if (this.userType == 3) {
      this.customerForm.patchValue({
        email: this.registerModel.email
      });
    }
    else {
      this.getHelperCategory();
      this.helperForm.patchValue({
        email: this.registerModel.email
      });
    }

    this.uploader.onBuildItemForm = (fileItem: any, form: FormData): any => {
      // Add Cloudinary's unsigned upload preset to the upload form
      form.append('upload_preset', this.cloudinary.config().upload_preset);
      form.append('folder', 'angular_sample');
      form.append('public_id', this.public_id);
      form.append('file', fileItem);

      // Use default "withCredentials" value for CORS requests
      fileItem.withCredentials = false;
      return { fileItem, form };
    };
  }

  initCustomerForm() {
    this.customerForm = this.fb.group({
      name: [null, [Validators.required]],
      phoneNo: [null, [Validators.required]],
      email: [null, [Validators.required]],
      addressLine: [null, [Validators.required]],
      country: [null, [Validators.required]],
      city: [null, [Validators.required]],
      state: [null, [Validators.required]],
      postalCode: [null, [Validators.required]],
      profilePicUrl: [null, [Validators.required]]
    });
  }

  get c() {
    return this.customerForm.controls;
  }

  get h() {
    return this.helperForm.controls;
  }

  initHelperForm() {
    this.helperForm = this.fb.group({
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
      experience: [0, [Validators.required]],
      aboutMe: [null, [Validators.required]],
      myService: [null, [Validators.required]],
      helperCategoryId: [null, [Validators.required]],
      profilePicUrl: [null, [Validators.required]]
    });
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

  onCustomerSubmit() {
    this.isFormSubmitted = true;
    if (this.customerForm.invalid) {
      return;
    }
    this.customerModel = this.customerForm.value;
    this.customerModel.userName = this.registerModel.userName;
    this.customerModel.password = this.registerModel.password;
    this.customerModel.userType = this.userType;
    this.isCustomerRequested = true;

    this.uploader.queue[0].upload();

    this.uploader.onErrorItem = (item: any, response: string, status: number, headers: ParsedResponseHeaders) =>{
      this.isCustomerRequested = false;
      console.log("Image upload failed");
    }

    // Update model on completion of uploading a file
    this.uploader.onCompleteItem = (item: any, response: string, status: number, headers: ParsedResponseHeaders) => {
      this.url = JSON.parse(response).url;
      this.customerRegister();
    }
  }

  customerRegister(){
    this.customerModel.profilePicUrl = this.url;
    this.authService.register(this.customerModel).subscribe(
      result => {
        console.log('result', result);
        this.toastr.success('Success', 'Account successfully created! Please check your email to confirm');
        sessionStorage.removeItem('user');
        setTimeout(() => {
          this.router.navigate(['auth/login']);
        }, 2000);
      },
      error => {
        console.log('error', error);
        this.isCustomerRequested = false;
        this.toastr.error('Error', error.message);
      }
    );
  }

  onHelperSubmit() {
    this.isFormSubmitted = true;
    if (this.helperForm.invalid) {
      return;
    }
    this.helperModel = this.helperForm.value;
    this.helperModel.userName = this.registerModel.userName;
    this.helperModel.password = this.registerModel.password;
    this.helperModel.userType = this.userType;
    this.helperModel.experience = +this.helperForm.value.experience;

    this.isHelperRequested = true;

    this.uploader.queue[0].upload();

    this.uploader.onErrorItem = (item: any, response: string, status: number, headers: ParsedResponseHeaders) =>{
      this.isHelperRequested = false;
      console.log("Image upload failed");
    }

    // Update model on completion of uploading a file
    this.uploader.onCompleteItem = (item: any, response: string, status: number, headers: ParsedResponseHeaders) => {
      this.url = JSON.parse(response).url;
      this.helperRegister();
    }
  }

  helperRegister(){
    this.helperModel.profilePicUrl = this.url;
    this.authService.register(this.helperModel).subscribe(
      result => {
        console.log('result', result);
        this.toastr.success('Success', 'Account successfully created! Please check your email to confirm');
        sessionStorage.removeItem('user');
        setTimeout(() => {
          this.router.navigate(['auth/login']);
        }, 2000);
      },
      error => {
        console.log('error', error);
        this.isHelperRequested = false;
        this.toastr.error('Error', error.message);
      }
    );
  }

  fileChangeEvent() {
    this.public_id = `img_${Date.now()}`;
  }
}