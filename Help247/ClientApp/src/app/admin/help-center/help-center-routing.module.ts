import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HelpCenterComponent } from './help-center/help-center.component';
import { AuthGuardService } from '../auth/helpers/auth-guard.service';


const routes: Routes = [
  {
    path: '',
    component: HelpCenterComponent,
    canActivate: [AuthGuardService]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HelpCenterRoutingModule { }
