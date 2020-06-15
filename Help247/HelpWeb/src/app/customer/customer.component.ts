import { Component, OnInit, TemplateRef } from '@angular/core';
import { HireMeService } from '../hire-me/services/hire-me.service';
import { TicketModel } from '../hire-me/models/ticket.model';
import { PaginationBase } from '../shared/models/pagination-base.model';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

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

  ticketList: Array<TicketModel>;
  pagination: PaginationBase;
  ticketModel: TicketModel;

  modalRef: BsModalRef;

  constructor(
    private hireMeService: HireMeService,
    private modalService: BsModalService
  ) {
    this.pagination = new PaginationBase(); 
  }

  ngOnInit(): void {
  }

  getTicketList() {
    this.hireMeService.getTicketList(this.pagination).subscribe(
      result => {
        console.log('result', result);
        this.ticketList = result.details;
      },
      error => {
        console.log('error', error);
      }
    );
  }

  openModal(template: TemplateRef<any>, data) {
    this.ticketModel = data;
    this.modalRef = this.modalService.show(template);
  }

  showDashboard() {
    this.isDashboardClicked = true;
    this.isMyTicketsClicked = false;
    this.isSettingsClicked = false;
    this.isRatingClicked = false;
    this.isLogoutClicked = false;
  }

  showMyTickets() {
    this.getTicketList();
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
