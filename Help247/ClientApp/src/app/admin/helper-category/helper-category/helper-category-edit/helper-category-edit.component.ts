import { Component, OnInit, Inject } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl, FormArray } from '@angular/forms';
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
  subServicesArr: FormArray;
  isBlocked: boolean = false;
  subService: SubServiceModel;
  subServiceToSave: SubServiceModel;
  // servicesProvided: { [key: string]: string };
  // subServiceTitle = new FormControl('');
  // subServiceDescription = new FormControl('');
  // serviceProvidedModel = new ServicesProvided();

  constructor(
    private helperCategoryService: HelperCategoryService,
    private notificationService: NotificationService,
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<HelperCategoryEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: number) { }

  ngOnInit() {
    this.subServicesArr = new FormArray([]);
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
      imageUrl: ['', Validators.required],
      subServices: this.fb.array([])
    });
  }

  initSubServices(): FormGroup {
    return this.fb.group({
      id: [{ value: '', disabled: true }],
      name: ['', Validators.required],
      description: ['', Validators.required]
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
  get subServices() {
    return this.helperCategoryForm.get('subServices') as FormArray;
  }
  get subServiceId() {
    return this.helperCategoryForm.get('subService.subServiceId');
  }
  get subServiceName() {
    return this.helperCategoryForm.get('subServices.subServiceName');
  }
  get subServiceDescription() {
    return this.helperCategoryForm.get('subServices.subServiceDescription');
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
      //subServices: this.subServicesArr
    });
    this.helperCategoryModel.subServices.forEach(element => {
      const ser = this.fb.group({
        id: element.id,
        name: element.name,
        description: element.description
      });
      this.subServices.push(ser)
    });
  }

  getHelperCategoryById(id: number) {
    this.helperCategoryService.getHelperCategoryById(id).subscribe(
      result => {
        this.helperCategoryModel = result;
        this.patchHelperForm();
        //this.subServicesArr.setValue(result.subServices);
      },
      error => {
        this.notificationService.errorMessage(error.message);
      }
    );
  }

  updateHelperCategory() {
    this.isBlocked = true;
    this.helperCategoryModel = this.helperCategoryForm.value;
    this.helperCategoryModel.id = this.data;

    this.helperCategoryService.updateHelperCategory(this.helperCategoryModel).subscribe(
      () => {
        this.closeDialog();
        this.notificationService.successMessage("Successfully updated Helper Category");
      },
      error => {
        this.isBlocked = false;
        this.notificationService.errorMessage(error.message);
      }
    );
  }

  addSubService() {
    this.subServicesArr = this.helperCategoryForm.get('subServices') as FormArray;
    this.subServices.push(this.initSubServices());
  }

  saveSubService(i) {
    this.subServiceToSave = new SubServiceModel();
    this.subServiceToSave = this.subServices.value[i];
    this.subServiceToSave.helperCategoryId = this.data;
    // this.subServiceToSave.name = this.subServiceName.value;
    // this.subServiceToSave.description = this.subServiceDescription.value;
    // this.subServiceToSave.helperCategoryId = this.id.value;

    this.helperCategoryService.postSubService(this.subServiceToSave).subscribe(
      () => {
        this.notificationService.successMessage("Successfully updated Helper Category");
        this.getHelperCategoryById(this.data);
      },
      error => {
        this.notificationService.errorMessage(error.message);
      }
    )

    console.log(this.subServiceToSave);
  }

  updateSubService(i) {
    var model: SubServiceModel = this.subServices.value[i];
    model.helperCategoryId = this.data;
    this.helperCategoryService.updateSubService(model).subscribe(
      () => {
        this.notificationService.successMessage("Successfully updated Sub Service");
      },
      error => {
        this.notificationService.errorMessage(error.message);
      }
    )
  }

  deleteSubService(i) {
    var model = this.subServices.value[i];
    this.helperCategoryService.deleteSubService(model.id).subscribe(
      () => {
        this.notificationService.successMessage("Successfully deleted Sub Service");
        this.subServices.removeAt(i);
      },
      error => {
        this.notificationService.errorMessage(error.message);
      }
    )
  }
  closeDialog(): void {
    this.dialogRef.close();
  }
}
