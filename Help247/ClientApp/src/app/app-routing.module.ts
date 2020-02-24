import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './admin/components/layout/layout.component';
import { AuthGuardService } from './admin/auth/helpers/auth-guard.service';


const routes: Routes = [
  { path: 'auth', loadChildren: './admin/auth/auth.module#AuthModule' },
  {
    path: '',
    component: LayoutComponent,
    children: [
      {
        path: '',
        pathMatch: 'full',
        redirectTo: 'dashboard',
      },
      {
        path: 'dashboard',
        loadChildren: './admin/dashboard/dashboard.module#DashboardModule',
        canActivate: [AuthGuardService]
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
