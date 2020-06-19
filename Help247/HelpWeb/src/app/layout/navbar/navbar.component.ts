import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import * as jwt_decode from "jwt-decode";

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  routerlink: string = "/auth/signup";

  constructor(public router: Router) { }

  ngOnInit(): void {
    this.getUser();
  }

  get changeUser() {
    this.getUser();
    return;
  }

  getUser() {
    var token = localStorage.getItem('TokenId');
    if (token != null) {
      var decoded = jwt_decode(localStorage.getItem('TokenId'));
      var role = JSON.parse(JSON.stringify(decoded))["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
      if (role == "Helper") {
        this.routerlink = "/helper";
        return "Profile";
      }
      else if (role == "Customer") {
        this.routerlink = "/customer";
        return "Profile";
      }
      else {
        this.routerlink = "/auth/signup";
        return "Register";
      }
    }
    return "Register";
  }
}