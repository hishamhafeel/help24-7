import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomerRoutingModule } from './customer-routing.module';
import { CustomerComponent } from './customer.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RatingModule } from 'ngx-bootstrap/rating';
import { FileUploadModule } from 'ng2-file-upload';


@NgModule({
  declarations: [
    CustomerComponent,
  ],
  imports: [
    CommonModule,
    CustomerRoutingModule,
    ModalModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
    RatingModule.forRoot(),
    FileUploadModule
  ]
})
export class CustomerModule { }
