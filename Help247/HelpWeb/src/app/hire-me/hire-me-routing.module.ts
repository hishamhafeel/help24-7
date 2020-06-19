import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HireMeComponent } from './hire-me/hire-me.component';
import { OpenTicketComponent } from './open-ticket/open-ticket.component';
import { AuthGuardCustomerService } from '../auth/authGuard/auth-guard-customer.service';


const routes: Routes = [
  {
    path: '',
    component: HireMeComponent
  },
  {
    path: 'open-ticket/:id',
    component: OpenTicketComponent,
    canActivate: [AuthGuardCustomerService]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HireMeRoutingModule { }
