import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { FormGroup, FormBuilder } from '@angular/forms';
import { HelperModel } from '../../models/helper.model';
import { HelperService } from '../../services/helper.service';

@Component({
  selector: 'app-helper-edit',
  templateUrl: './helper-edit.component.html',
  styleUrls: ['./helper-edit.component.scss']
})
export class HelperEditComponent implements OnInit {

  helperForm: FormGroup;
  helperModel: HelperModel;

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
      id: [{value: '', disabled: true}],
      name: [''],
      phoneNo: [''],
      email: [''],
      country: [''],
      province: [''],
      district: [''],
      city: [''],
      helperCategory: []
    });
    this.patchHelperForm();
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
      helperCategory: this.data.helperCategory
    });
  }

  getHelperCategories(){
    
  }

  updateHelper() {
    this.helperModel = Object.assign({}, this.helperForm.value);
    this.helperModel.id = this.helperForm.getRawValue().id;

    this.helperService.updateHelper(this.helperModel).subscribe(
      () => {
        this.closeDialog();
      },
      error => {

      }
    );
  }

  closeDialog(): void {
    this.dialogRef.close();
  }

}
