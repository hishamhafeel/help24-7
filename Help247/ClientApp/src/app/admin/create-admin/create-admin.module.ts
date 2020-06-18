import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CreateAdminRoutingModule } from './create-admin-routing.module';
import { CreateAdminComponent } from './create-admin/create-admin.component';
import { SharedModule } from 'src/app/shared/shared.module';


@NgModule({
  declarations: [CreateAdminComponent],
  imports: [
    CommonModule,
    CreateAdminRoutingModule,
    SharedModule
  ]
})
export class CreateAdminModule { }
