import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CustomerRoutingModule } from './customer-routing.module';
import { CustomerComponent } from './customer.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FileUploadModule } from 'ng2-file-upload';
import { NgxStarRatingModule } from 'ngx-star-rating';
import { CarouselModule } from 'ngx-owl-carousel-o';
import { TimepickerModule } from 'ngx-bootstrap/timepicker';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';

@NgModule({
  declarations: [CustomerComponent],
  imports: [
    CommonModule,
    CustomerRoutingModule,
    ModalModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
    FileUploadModule,
    NgxStarRatingModule,
    CarouselModule,
    BsDatepickerModule.forRoot(),
    TimepickerModule.forRoot(),
  ],
})
export class CustomerModule {}
