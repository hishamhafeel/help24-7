import { Component, OnInit, ViewChild, TemplateRef, Inject } from '@angular/core';
import { MatPaginator, MAT_DIALOG_DATA, MatDialogRef } from '@angular/material';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CustomerModel } from '../../models/customer.model';
import { CustomerService } from '../../services/customer.service';
import { NotificationService } from 'src/app/shared/services/notification.service';

@Component({
  selector: 'app-customer-edit',
  templateUrl: './customer-edit.component.html',
  styleUrls: ['./customer-edit.component.scss']
})
export class CustomerEditComponent implements OnInit {

  customerForm: FormGroup;
  customerModel: CustomerModel;
  isBlocked: boolean = false;

  constructor(
    private customerService: CustomerService,
    private notificationService: NotificationService,
    private fb: FormBuilder,
    public dialogRef: MatDialogRef<CustomerEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: CustomerModel
  ) { }

  ngOnInit() {
    this.initCustomerForm();
  }

  initCustomerForm() {
    this.customerForm = this.fb.group({
      id: [{ value: '', disabled: true }],
      name: ['', Validators.required],
      phoneNo: ['', Validators.required],
      email: ['', Validators.required],
      country: ['', Validators.required],
      province: ['', Validators.required],
      district: ['', Validators.required],
      city: ['', Validators.required]
    });
    this.patchCustomerForm();
  }
  get name() {
    return this.customerForm.get('name');
  }
  get phoneNo() {
    return this.customerForm.get('phoneNo');
  }
  get email() {
    return this.customerForm.get('email');
  }
  get country() {
    return this.customerForm.get('country');
  }
  get province() {
    return this.customerForm.get('province');
  }
  get district() {
    return this.customerForm.get('district');
  }
  get city() {
    return this.customerForm.get('city');
  }

  patchCustomerForm() {
    this.customerForm.patchValue({
      id: this.data.id,
      name: this.data.name,
      phoneNo: this.data.phoneNo,
      email: this.data.email,
      country: this.data.country,
      province: this.data.province,
      district: this.data.district,
      city: this.data.city
    });
  }

  updateCustomer() {
    this.isBlocked = true;
    this.customerModel = Object.assign({}, this.customerForm.value);
    this.customerModel.id = this.customerForm.getRawValue().id;

    this.customerService.updateCustomer(this.customerModel).subscribe(
      () => {
        this.closeDialog();
        this.notificationService.successMessage("Successfully updated customer");
      },
      error => {
        this.isBlocked = false;
        this.notificationService.errorMessage(error.message);
      }
    );
  }

  closeDialog(): void {
    this.dialogRef.close();
  }
}