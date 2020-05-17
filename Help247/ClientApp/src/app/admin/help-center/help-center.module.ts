import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HelpCenterRoutingModule } from './help-center-routing.module';
import { HelpCenterComponent } from './help-center/help-center.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [HelpCenterComponent],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    HelpCenterRoutingModule,
    SharedModule
  ]
})
export class HelpCenterModule { }
