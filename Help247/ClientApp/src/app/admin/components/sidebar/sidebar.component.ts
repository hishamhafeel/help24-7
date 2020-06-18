import { Component, OnInit } from '@angular/core';

declare interface RouteInfo {
  path: string;
  title: string;
  icon: string;
  class: string;
}
export const ROUTES: RouteInfo[] = [
  { path: '/dashboard', title: 'Dashboard', icon: 'dashboard', class: '' },
  { path: '/helper', title: 'Helpers', icon: 'assistant', class: '' },
  { path: '/customer', title: 'Customers', icon: 'person', class: '' },
  { path: '/ticket', title: 'Tickets', icon: 'info', class: '' },
  // { path: '/icons', title: 'Feedbacks',  icon:'feedback', class: '' },
  { path: '/service', title: 'Services', icon: 'category', class: '' },
  { path: '/help-center', title: 'Help Center', icon: 'feedback', class: '' },
  // { path: '/admin', title: 'Create Admin', icon: 'admin_panel_settings', class: '' },
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  menuItems: any[];
  role: string;

  constructor() { }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
    this.role = localStorage.getItem("Role");

  }
}
