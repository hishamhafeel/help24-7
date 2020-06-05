import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HelperRoutingModule } from './helper-routing.module';
import { HelperComponent } from './helper.component';


@NgModule({
  declarations: [HelperComponent],
  imports: [
    CommonModule,
    HelperRoutingModule
  ]
})
export class HelperModule { }
