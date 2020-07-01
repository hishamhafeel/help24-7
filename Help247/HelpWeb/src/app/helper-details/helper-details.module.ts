import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HelperDetailsRoutingModule } from './helper-details-routing.module';
import { HelperDetailsComponent } from './helper-details.component';
import { CarouselModule } from 'ngx-owl-carousel-o';


@NgModule({
  declarations: [HelperDetailsComponent],
  imports: [
    CommonModule,
    HelperDetailsRoutingModule,
    CarouselModule
  ]
})
export class HelperDetailsModule { }
