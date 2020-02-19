import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdminLayoutRoutingModule } from './admin-layout-routing.module';
import { DashboardComponent } from '../../dashboard/dashboard.component';
import { MatTooltipModule } from '@angular/material';


@NgModule({
  declarations: [
    DashboardComponent
  ],
  imports: [
    CommonModule,
    AdminLayoutRoutingModule,
    MatTooltipModule
  ]
})
export class AdminLayoutModule { }
