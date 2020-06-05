import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HireMeRoutingModule } from './hire-me-routing.module';
import { HireMeComponent } from './hire-me/hire-me.component';
import { OpenTicketComponent } from './open-ticket/open-ticket.component';


@NgModule({
  declarations: [
    HireMeComponent,
    OpenTicketComponent,
  ],
  imports: [
    CommonModule,
    HireMeRoutingModule
  ]
})
export class HireMeModule { }
