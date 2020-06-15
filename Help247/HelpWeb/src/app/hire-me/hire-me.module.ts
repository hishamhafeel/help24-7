import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HireMeRoutingModule } from './hire-me-routing.module';
import { HireMeComponent } from './hire-me/hire-me.component';
import { OpenTicketComponent } from './open-ticket/open-ticket.component';
import { BsDatepickerModule } from 'ngx-bootstrap';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    HireMeComponent,
    OpenTicketComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    HireMeRoutingModule,
    BsDatepickerModule.forRoot()
  ]
})
export class HireMeModule { }
