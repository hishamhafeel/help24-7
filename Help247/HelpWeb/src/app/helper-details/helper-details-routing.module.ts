import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HelperDetailsComponent } from './helper-details.component';

const routes: Routes = [
  {
    path: '',
    component: HelperDetailsComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HelperDetailsRoutingModule { }
