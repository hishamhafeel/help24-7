import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CustomerComponent } from './customer.component';
import { AuthGuardCustomerService } from '../auth/authGuard/auth-guard-customer.service';


const routes: Routes = [
  {
    path: '',
    component: CustomerComponent,
    canActivate: [AuthGuardCustomerService]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CustomerRoutingModule { }
