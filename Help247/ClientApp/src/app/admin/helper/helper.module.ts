import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HelperRoutingModule } from './helper-routing.module';
import { HelperComponent } from './helper/helper.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { HelperEditComponent } from './helper/helper-edit/helper-edit.component';


@NgModule({
  declarations: [HelperComponent, HelperEditComponent],
  imports: [
    CommonModule,
    HelperRoutingModule,
    SharedModule
  ],
  entryComponents: [HelperEditComponent]
})
export class HelperModule { }
