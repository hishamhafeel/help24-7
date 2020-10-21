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
import { HttpClientModule } from '@angular/common/http';
import { ValidatorService } from '../auth/services/validator.service';

@NgModule({
  declarations: [CustomerComponent],
  imports: [
    CommonModule,
    HttpClientModule,
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
  providers: [ValidatorService,]
})
export class CustomerModule { }
