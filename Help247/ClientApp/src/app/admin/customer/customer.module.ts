import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomerRoutingModule } from './customer-routing.module';
import { CustomerComponent } from './customer/customer.component';
import { CustomerEditComponent } from './customer/customer-edit/customer-edit.component';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [CustomerComponent, CustomerEditComponent],
  imports: [
    CommonModule,
    CustomerRoutingModule,
    SharedModule
  ],
  entryComponents: [CustomerEditComponent]
})
export class CustomerModule { }
