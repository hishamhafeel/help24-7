import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {
  isDashboardClicked: boolean = true;
  isMyTicketsClicked: boolean = false;
  isSettingsClicked: boolean = false;
  isRatingClicked: boolean = false;
  isLogoutClicked: boolean = false;
  constructor() { }

  ngOnInit(): void {
  }

  showDashboard() {
    this.isDashboardClicked = true;
    this.isMyTicketsClicked = false;
    this.isSettingsClicked = false;
    this.isRatingClicked = false;
    this.isLogoutClicked = false;
  }

  showMyTickets() {
    this.isDashboardClicked = false;
    this.isMyTicketsClicked = true;
    this.isSettingsClicked = false;
    this.isRatingClicked = false;
    this.isLogoutClicked = false;
  }

  showSettings() {
    this.isDashboardClicked = false;
    this.isMyTicketsClicked = false;
    this.isSettingsClicked = true;
    this.isRatingClicked = false;
    this.isLogoutClicked = false;
  }

  showRatings() {
    this.isDashboardClicked = false;
    this.isMyTicketsClicked = false;
    this.isSettingsClicked = false;
    this.isRatingClicked = true;
    this.isLogoutClicked = false;
  }

  logout() {
    this.isDashboardClicked = false;
    this.isMyTicketsClicked = false;
    this.isSettingsClicked = false;
    this.isRatingClicked = false;
    this.isLogoutClicked = true;
  }
}
