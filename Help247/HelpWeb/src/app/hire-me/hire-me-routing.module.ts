import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HireMeComponent } from './hire-me/hire-me.component';
import { OpenTicketComponent } from './open-ticket/open-ticket.component';


const routes: Routes = [
  {
    path: '',
    component: HireMeComponent
  },
  {
    path: 'open-ticket/:id',
    component: OpenTicketComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HireMeRoutingModule { }
