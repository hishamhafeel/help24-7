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
      },
      {
        path: 'helper',
        loadChildren: './admin/helper/helper.module#HelperModule',
        canActivate: [AuthGuardService]
      },
      {
        path: 'customer',
        loadChildren: './admin/customer/customer.module#CustomerModule',
        canActivate: [AuthGuardService]
      },
      {
        path: 'help-center',
        loadChildren: './admin/help-center/help-center.module#HelpCenterModule',
        canActivate: [AuthGuardService]
      },
      {
        path: 'ticket',
        loadChildren: './admin/ticket/ticket.module#TicketModule',
        canActivate: [AuthGuardService]
      },
      {
        path: 'service',
        loadChildren: './admin/helper-category/helper-category.module#HelperCategoryModule',
        canActivate: [AuthGuardService]
      },
      {
        path: 'image',
        loadChildren: './admin/image-upload/image-upload.module#ImageUploadModule'
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
