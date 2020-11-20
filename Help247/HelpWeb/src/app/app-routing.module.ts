import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LayoutComponent } from './layout/layout/layout.component';


const routes: Routes = [
  {
    path: '',
    component: LayoutComponent,
    children: [
      {
        path: '',
        loadChildren: () => import('./home/home.module').then(m => m.HomeModule),
        pathMatch: 'full'
      },
      // {
      //   path: 'home',
      //   loadChildren: () => import('./home/home.module').then(m => m.HomeModule)
      // },
      {
        path: 'about-us',
        loadChildren: () => import('./about-us/about-us.module').then(m => m.AboutUsModule)
      },
      {
        path: 'services',
        loadChildren: () => import('./services/services.module').then(m => m.ServicesModule)
      },
      {
        path: 'hire-me',
        loadChildren: () => import('./hire-me/hire-me.module').then(m => m.HireMeModule)
      },
      {
        path: 'contact-us',
        loadChildren: () => import('./contact-us/contact-us.module').then(m => m.ContactUsModule)
      },
      {
        path: 'auth',
        loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule)
      },
      {
        path: 'customer',
        loadChildren: () => import('./customer/customer.module').then(m => m.CustomerModule)
      },
      {
        path: 'helper',
        loadChildren: () => import('./helper/helper.module').then(m => m.HelperModule)
      },
      {
        path: 'helper-details',
        loadChildren: () => import('./helper-details/helper-details.module').then(m => m.HelperDetailsModule)
      },
      {
        path: 'help-center',
        loadChildren: () => import('./help-center/help-center.module').then(m => m.HelpCenterModule)
      },
    ],
  },

];

@NgModule({
  imports: [RouterModule.forRoot(routes, { scrollPositionRestoration: 'enabled' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
