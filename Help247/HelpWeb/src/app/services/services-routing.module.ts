import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ServicesComponent } from './services/services.component';
import { SubServiceComponent } from './sub-service/sub-service.component';


const routes: Routes = [
  {
    path: '',
    component: ServicesComponent
  },
  {
    path: 'sub-service',
    component: SubServiceComponent
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ServicesRoutingModule { }
