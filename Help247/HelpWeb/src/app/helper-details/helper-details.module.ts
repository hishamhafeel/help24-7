import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HelperDetailsRoutingModule } from './helper-details-routing.module';
import { HelperDetailsComponent } from './helper-details.component';


@NgModule({
  declarations: [HelperDetailsComponent],
  imports: [
    CommonModule,
    HelperDetailsRoutingModule
  ]
})
export class HelperDetailsModule { }
