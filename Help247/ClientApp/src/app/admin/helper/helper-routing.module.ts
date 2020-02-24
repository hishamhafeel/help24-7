import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuardService } from '../auth/helpers/auth-guard.service';
import { HelperComponent } from './helper/helper.component';


const routes: Routes = [
  {
    path: '',
    component: HelperComponent,
    canActivate: [AuthGuardService]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HelperRoutingModule { }
