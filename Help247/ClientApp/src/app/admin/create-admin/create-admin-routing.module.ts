import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CreateAdminComponent } from './create-admin/create-admin.component';
import { AuthGuardService } from '../auth/helpers/auth-guard.service';


const routes: Routes = [
  {
    path: '',
    component: CreateAdminComponent,
    canActivate: [AuthGuardService]

  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CreateAdminRoutingModule { }
