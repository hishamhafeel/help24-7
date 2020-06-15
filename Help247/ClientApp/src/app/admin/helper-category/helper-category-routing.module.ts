import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AuthGuardService } from '../auth/helpers/auth-guard.service';
import { HelperCategoryComponent } from './helper-category/helper-category.component';


const routes: Routes = [
  {
    path: '',
    component: HelperCategoryComponent,
    canActivate: [AuthGuardService]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HelperCategoryRoutingModule { }
