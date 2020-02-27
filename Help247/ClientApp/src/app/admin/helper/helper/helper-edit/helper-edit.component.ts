import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HelperModel, HelperCategoryModel } from '../../models/helper.model';
import { HelperService } from '../../services/helper.service';

@Component({
  selector: 'app-helper-edit',
  templateUrl: './helper-edit.component.html',
  styleUrls: ['./helper-edit.component.scss']
})
export class HelperEditComponent implements OnInit {

  helperForm: FormGroup;
  helperModel: HelperModel;
  helperCategories: Array<HelperCategoryModel>;
  isBlocked: boolean = false;

  constructor(
    private helperService: HelperService,
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<HelperEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: HelperModel
  ) { }

  ngOnInit() {
    this.initHelperForm();
    this.getHelperCategories();
  }

  initHelperForm() {
    this.helperForm = this.fb.group({
      id: [{ value: '', disabled: true }],
      name: ['', Validators.required],
      phoneNo: ['', Validators.required],
      email: ['', Validators.required],
      country: ['', Validators.required],
      province: ['', Validators.required],
      district: ['', Validators.required],
      city: ['', Validators.required],
      helperCategoryId: [, [Validators.required]]
    });
    this.patchHelperForm();
  }
  get name() {
    return this.helperForm.get('name');
  }
  get phoneNo() {
    return this.helperForm.get('phoneNo');
  }
  get email() {
    return this.helperForm.get('email');
  }
  get country() {
    return this.helperForm.get('country');
  }
  get province() {
    return this.helperForm.get('province');
  }
  get district() {
    return this.helperForm.get('district');
  }
  get city() {
    return this.helperForm.get('city');
  }
  get helperCategoryId() {
    return this.helperForm.get('helperCategoryId');
  }

  patchHelperForm() {
    this.helperForm.patchValue({
      id: this.data.id,
      name: this.data.name,
      phoneNo: this.data.phoneNo,
      email: this.data.email,
      country: this.data.country,
      province: this.data.province,
      district: this.data.district,
      city: this.data.city,
      helperCategoryId: this.data.helperCategory.id
    });
  }

  getHelperCategories() {
    this.helperService.getHelperCategoryList().subscribe(
      result => {
        this.helperCategories = result;
      },
      error => {

      }
    );
  }

  updateHelper() {
    this.isBlocked = true;
    this.helperModel = Object.assign({}, this.helperForm.value);
    this.helperModel.id = this.helperForm.getRawValue().id;

    this.helperService.updateHelper(this.helperModel).subscribe(
      () => {
        this.closeDialog();
      },
      error => {
        this.isBlocked = false;
      }
    );
  }

  closeDialog(): void {
    this.dialogRef.close();
  }

}
