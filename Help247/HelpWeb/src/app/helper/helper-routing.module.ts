import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HelperComponent } from './helper.component';
import { AuthGuardHelperService } from '../auth/authGuard/auth-guard-helper.service';


const routes: Routes = [
  {
    path: '',
    component: HelperComponent,
    canActivate: [AuthGuardHelperService]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HelperRoutingModule { }
