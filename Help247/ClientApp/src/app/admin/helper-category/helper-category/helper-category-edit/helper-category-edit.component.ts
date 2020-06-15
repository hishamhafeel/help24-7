import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { HelperCategoryService } from '../../services/helper-category.service';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { HelperCategoryModel, SubServiceModel } from '../../models/helper-category.model';

@Component({
  selector: 'app-helper-category-edit',
  templateUrl: './helper-category-edit.component.html',
  styleUrls: ['./helper-category-edit.component.scss']
})
export class HelperCategoryEditComponent implements OnInit {

  helperCategoryForm: FormGroup;
  helperCategoryModel: HelperCategoryModel;
  servicesProvidedArr = [];
  isBlocked: boolean = false;
  subService = new SubServiceModel();
  servicesProvided: { [key: string]: string };
  subServiceTitle = new FormControl('');
  subServiceDescription = new FormControl('');
  // serviceProvidedModel = new ServicesProvided();

  constructor(
    private helperCategoryService: HelperCategoryService,
    private notificationService: NotificationService,
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<HelperCategoryEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: number) { }

  ngOnInit() {
    this.initHelperForm();
    this.getHelperCategoryById(this.data);
  }

  initHelperForm() {
    this.helperCategoryForm = this.fb.group({
      id: [{ value: '', disabled: true }],
      name: ['', Validators.required],
      title: ['', Validators.required],
      shortDescription: ['', Validators.required],
      longDescription: ['', Validators.required],
      iconUrl: ['', Validators.required],
      imageUrl: ['', Validators.required]
      // servicesProvided: []
    });
  }

  get id() {
    return this.helperCategoryForm.get('id');
  }
  get name() {
    return this.helperCategoryForm.get('name');
  }

  get title() {
    return this.helperCategoryForm.get('title');
  }
  get shortDescription() {
    return this.helperCategoryForm.get('shortDescription');
  }
  get longDescription() {
    return this.helperCategoryForm.get('longDescription');
  }
  get iconUrl() {
    return this.helperCategoryForm.get('iconUrl');
  }
  get imageUrl() {
    return this.helperCategoryForm.get('imageUrl');
  }
  // get subServiceTitle() {
  //   return this.helperCategoryForm.get('subServiceTitle');
  // }
  // get subServiceDescription() {
  //   return this.helperCategoryForm.get('subServiceTitle');
  // }


  patchHelperForm() {
    this.helperCategoryForm.patchValue({
      id: this.helperCategoryModel.id,
      name: this.helperCategoryModel.name,
      title: this.helperCategoryModel.title,
      shortDescription: this.helperCategoryModel.shortDescription,
      longDescription: this.helperCategoryModel.longDescription,
      iconUrl: this.helperCategoryModel.iconUrl,
      imageUrl: this.helperCategoryModel.imageUrl,
      // servicesProvided: this.servicesProvided
    });
  }

  getHelperCategoryById(id: number) {
    this.helperCategoryService.getHelperCategoryById(id).subscribe(
      result => {
        this.helperCategoryModel = result;
        // this.servicesProvided = result.servicesProvided;
        this.servicesProvidedArr.push(result.servicesProvided);
        this.patchHelperForm();

      },
      error => {
        this.notificationService.errorMessage(error.message);
      }
    );
  }

  updateHelperCategory() {
    this.isBlocked = true;
    this.helperCategoryModel = Object.assign({}, this.helperCategoryForm.value);
    this.helperCategoryModel.id = this.helperCategoryForm.getRawValue().id;

    this.servicesProvided = {};
    this.servicesProvided = this.helperCategoryModel.servicesProvided;
    this.servicesProvided[this.subServiceTitle.value] = this.subServiceDescription.value;
    this.helperCategoryModel.servicesProvided = this.servicesProvided;

    this.helperCategoryService.updateHelperCategory(this.helperCategoryModel).subscribe(
      () => {
        this.closeDialog();
        this.notificationService.successMessage("Successfully updated helper");
      },
      error => {
        this.isBlocked = false;
        this.notificationService.errorMessage(error.message);
      }
    );
  }

  addSubService() {
    this.subService = new SubServiceModel();
    this.servicesProvidedArr[0].push(this.subService);
  }
  closeDialog(): void {
    this.dialogRef.close();
  }
}
