import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { RouterModule } from '@angular/router';
import { LayoutComponent } from './layout/layout.component';
import { SharedModule } from 'src/app/shared/shared.module';



@NgModule({
  declarations: [
    NavbarComponent, 
    FooterComponent, 
    SidebarComponent, 
    LayoutComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    SharedModule
  ],
  exports: [
    NavbarComponent,
    FooterComponent,
    SidebarComponent
  ]
})
export class ComponentsModule { }
