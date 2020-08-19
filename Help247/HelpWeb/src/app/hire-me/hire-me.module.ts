import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HireMeRoutingModule } from './hire-me-routing.module';
import { HireMeComponent } from './hire-me/hire-me.component';
import { OpenTicketComponent } from './open-ticket/open-ticket.component';
import { BsDatepickerModule } from 'ngx-bootstrap';
import { TimepickerModule } from 'ngx-bootstrap/timepicker';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { FilterCategoryPipe } from '../shared/pipes/filter-category.pipe';
import { NgxPaginationModule } from 'ngx-pagination';


@NgModule({
  declarations: [
    HireMeComponent,
    OpenTicketComponent,
    FilterCategoryPipe
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    HireMeRoutingModule,
    BsDatepickerModule.forRoot(),
    TimepickerModule.forRoot(),
    NgxPaginationModule
  ]
})
export class HireMeModule { }
