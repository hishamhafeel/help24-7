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
  fileName: string = "";

  constructor(private cloudinary: Cloudinary, private helperService: HelperService, private route: ActivatedRoute, private router: Router, private fb: FormBuilder, private authService: AuthService) {
    this.pagination = new PaginationBase();
  }

  ngOnInit() {
    this.route.paramMap.subscribe(params => {
      this.userType = +params.get('userType');
    });
    this.registerModel = JSON.parse(sessionStorage.getItem('user'));
    if (this.userType == 3) {
      this.initCustomerForm();
      this.customerForm.patchValue({
        email: this.registerModel.email
      });
    }
    else {
      this.getHelperCategory();
      this.initHelperForm();
      this.helperForm.patchValue({
        email: this.registerModel.email
      });
    }

    const uploaderOptions: FileUploaderOptions = {
      url: `https://api.cloudinary.com/v1_1/${this.cloudinary.config().cloud_name}/upload`,
      autoUpload: true,
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

    this.uploader.onBuildItemForm = (fileItem: any, form: FormData): any => {
      // Add Cloudinary's unsigned upload preset to the upload form
      form.append('upload_preset', this.cloudinary.config().upload_preset);
      form.append('folder', 'angular_sample');
      form.append('file', fileItem);

      // Use default "withCredentials" value for CORS requests
      fileItem.withCredentials = false;
      return { fileItem, form };
    };

    this.uploader.onErrorItem = (item: any, response: string, status: number, headers: ParsedResponseHeaders) =>
      console.log("Image upload failed")

    // Update model on completion of uploading a file
    this.uploader.onCompleteItem = (item: any, response: string, status: number, headers: ParsedResponseHeaders) => {
      this.url = JSON.parse(response).url;
    }
  }

  initCustomerForm() {
    this.customerForm = this.fb.group({
      name: ['Test Customer', [Validators.required]],
      phoneNo: ['+94772563489', [Validators.required]],
      email: [null, [Validators.required]],
      addressLine: ['311/1/A Malay Colony Ambalantota', [Validators.required]],
      country: ['Sri Lanka', [Validators.required]],
      city: ['Ambalantota', [Validators.required]],
      state: ['Hambantota', [Validators.required]],
      postalCode: ['82100', [Validators.required]]
    });
  }

  initHelperForm() {
    this.helperForm = this.fb.group({
      firstName: ['Test', [Validators.required]],
      lastName: ['Customer', [Validators.required]],
      phoneNo: ['+94774065416', [Validators.required]],
      mobileNo: ['+94774065416', [Validators.required]],
      email: [null, [Validators.required]],
      addressLine: ['311/1/A Malay Colony Ambalantota', [Validators.required]],
      country: ['Sri Lanka', [Validators.required]],
      city: ['Ambalantota', [Validators.required]],
      state: ['Hambantota', [Validators.required]],
      postalCode: ['82100', [Validators.required]],
      experience: [2, [Validators.required]],
      aboutMe: ['I am Sri lankan', [Validators.required]],
      myService: ['About my service description', [Validators.required]],
      helperCategoryId: [null, [Validators.required]]
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
    if (this.customerForm.invalid) {
      return;
    }
    this.customerModel = this.customerForm.value;
    this.customerModel.userName = this.registerModel.userName;
    this.customerModel.password = this.registerModel.password;
    this.customerModel.userType = this.userType;
    this.customerModel.profilePicUrl = this.url;

    this.authService.register(this.customerModel).subscribe(
      result => {
        console.log('result', result);
        this.router.navigate(['auth/login']);
      },
      error => {
        console.log('error', error);
      }
    );
  }

  onHelperSubmit() {
    if (this.helperForm.invalid) {
      return;
    }
    this.helperModel = this.helperForm.value;
    this.helperModel.userName = this.registerModel.userName;
    this.helperModel.password = this.registerModel.password;
    this.helperModel.userType = this.userType;
    this.helperModel.profilePicUrl = this.url;

    this.authService.register(this.helperModel).subscribe(
      result => {
        console.log('result', result);
        this.router.navigate(['auth/login']);
      },
      error => {
        console.log('error', error);
      }
    );
  }

  fileEvent(fileInput) {
    let file = fileInput.target.files[0];
    this.fileName = file.name;
  }
}