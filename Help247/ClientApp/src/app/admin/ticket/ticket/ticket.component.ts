import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { MatPaginator, MatTableDataSource, MatDialog } from '@angular/material';
import { HelperComponent } from '../../helper/helper/helper.component';
import { HelperModel } from '../../helper/models/helper.model';
import { HelperService } from '../../helper/services/helper.service';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { HelperEditComponent } from '../../helper/helper/helper-edit/helper-edit.component';
import { TicketService } from '../services/ticket.service';
import { TicketModel, TicketPaginationModel } from '../models/ticket.model';
import { Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';

@Component({
  selector: 'app-ticket',
  templateUrl: './ticket.component.html',
  styleUrls: ['./ticket.component.scss']
})
export class TicketComponent implements OnInit {

  @ViewChild('deleteDialog', { static: false }) deleteDialog: TemplateRef<HelperComponent>;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  pendingTicketDataSource = new MatTableDataSource();
  approvedTicketDataSource = new MatTableDataSource();
  completedTicketDataSource = new MatTableDataSource();
  cancelledTicketDataSource = new MatTableDataSource();
  helpersTicketDataSource = new MatTableDataSource();
  customersTicketDataSource = new MatTableDataSource();
  PENDING_TICKET_DETAILS: Array<TicketModel>;
  APPROVED_TICKET_DETAILS: Array<TicketModel>;
  COMPLETED_TICKET_DETAILS: Array<TicketModel>;
  CANCELLED_TICKET_DETAILS: Array<TicketModel>;
  HELPERS_TICKET_DETAILS: Array<TicketModel>;
  CUSTOMERS_TICKET_DETAILS: Array<TicketModel>;
  searchTermHelper$ = new Subject<string>();
  searchTermCustomer$ = new Subject<string>();
  pagination: TicketPaginationModel;
  pageSize = 10;
  isLoadingResults: boolean = false;
  hasHelperRecords: boolean = false;

  displayedColumns: string[] = [
    'id',
    'helper',
    'customer',
    'title',
    'helpDateFrom',
    'helpDateTo',
    'country',
    'state',
    'city',
    'address',
    'contactNo1'
  ];


  constructor(
    private ticketService: TicketService,
    private notificationService: NotificationService,
    public dialog: MatDialog
  ) {
    this.pagination = new TicketPaginationModel();

    this.searchTermHelper$.pipe(debounceTime(200))
      .pipe(distinctUntilChanged()).subscribe((data: any) => {
        this.isLoadingResults = true;
        let paginationObj = Object.create(this.pagination);
        if (data != "" && data)
          paginationObj.helperName = data;
        this.ticketService.getTicket(paginationObj)
          .subscribe((result: any) => {
            this.HELPERS_TICKET_DETAILS = result.details;
            this.helpersTicketDataSource = new MatTableDataSource<TicketModel>(
              this.HELPERS_TICKET_DETAILS
            );
            this.paginator.length = result.totalRecords;
            this.isLoadingResults = false;
          })
      });

    this.searchTermCustomer$.pipe(debounceTime(200))
      .pipe(distinctUntilChanged()).subscribe((data: any) => {
        this.isLoadingResults = true;
        let paginationObj = Object.create(this.pagination);
        if (data != "" && data)
          paginationObj.customerName = data;
        this.ticketService.getTicket(paginationObj)
          .subscribe((result: any) => {
            this.CUSTOMERS_TICKET_DETAILS = result.details;
            this.customersTicketDataSource = new MatTableDataSource<TicketModel>(
              this.CUSTOMERS_TICKET_DETAILS
            );
            this.paginator.length = result.totalRecords;
            this.isLoadingResults = false;
          })
      });
  }


  ngOnInit() {
    this.getPendingTicket();
  }

  getPendingTicket() {
    this.isLoadingResults = true;
    let paginationObj = Object.create(this.pagination);
    paginationObj.ticketStatusId = 1;
    this.ticketService.getTicket(paginationObj).subscribe(
      result => {
        this.PENDING_TICKET_DETAILS = result.details;
        this.pendingTicketDataSource = new MatTableDataSource<TicketModel>(
          this.PENDING_TICKET_DETAILS
        );
        this.paginator.length = result.totalRecords;
        this.isLoadingResults = false;
      },
      error => {
        this.isLoadingResults = false;
        this.notificationService.errorMessage(error.message);
      }
    );
  }

  getApprovedTicket() {
    this.isLoadingResults = true;
    let paginationObj = Object.create(this.pagination);
    paginationObj.ticketStatusId = 2;
    this.ticketService.getTicket(paginationObj).subscribe(
      result => {
        this.APPROVED_TICKET_DETAILS = result.details;
        this.approvedTicketDataSource = new MatTableDataSource<TicketModel>(
          this.APPROVED_TICKET_DETAILS
        );
        this.paginator.length = result.totalRecords;
        this.isLoadingResults = false;
      },
      error => {
        this.isLoadingResults = false;
        this.notificationService.errorMessage(error.message);
      }
    );
  }

  getCompletedTicket() {
    this.isLoadingResults = true;
    let paginationObj = Object.create(this.pagination);
    paginationObj.ticketStatusId = 3;
    this.ticketService.getTicket(paginationObj).subscribe(
      result => {
        this.COMPLETED_TICKET_DETAILS = result.details;
        this.completedTicketDataSource = new MatTableDataSource<TicketModel>(
          this.COMPLETED_TICKET_DETAILS
        );
        this.paginator.length = result.totalRecords;
        this.isLoadingResults = false;
      },
      error => {
        this.isLoadingResults = false;
        this.notificationService.errorMessage(error.message);
      }
    );
  }

  getCancelledTicket() {
    this.isLoadingResults = true;
    let paginationObj = Object.create(this.pagination);
    paginationObj.ticketStatusId = 4;
    this.ticketService.getTicket(paginationObj).subscribe(
      result => {
        this.CANCELLED_TICKET_DETAILS = result.details;
        this.cancelledTicketDataSource = new MatTableDataSource<TicketModel>(
          this.CANCELLED_TICKET_DETAILS
        );
        this.paginator.length = result.totalRecords;
        this.isLoadingResults = false;
      },
      error => {
        this.isLoadingResults = false;
        this.notificationService.errorMessage(error.message);
      }
    );
  }

  getAllTicket() {
    this.isLoadingResults = true;
    let paginationObj = Object.create(this.pagination);
    paginationObj.helperName = '';
    paginationObj.customerName = '';
    this.ticketService.getTicket(paginationObj).subscribe(
      result => {
        this.HELPERS_TICKET_DETAILS = result.details;
        this.CUSTOMERS_TICKET_DETAILS = result.details;
        this.helpersTicketDataSource = new MatTableDataSource<TicketModel>(
          this.HELPERS_TICKET_DETAILS
        );
        this.customersTicketDataSource = new MatTableDataSource<TicketModel>(
          this.CUSTOMERS_TICKET_DETAILS
        );
        this.paginator.length = result.totalRecords;
        this.isLoadingResults = false;
      },
      error => {
        this.isLoadingResults = false;
        this.notificationService.errorMessage(error.message);
      }
    );
  }

  tabClick(event: any) {
    switch (event.tab.textLabel) {
      case "Pending": {
        this.getPendingTicket();
        break;
      }
      case "Approved": {
        this.getApprovedTicket();
        break;
      }
      case "Completed": {
        this.getCompletedTicket();
        break;
      }
      case "Cancelled": {
        this.getCancelledTicket();
        break;
      }
      case "Helper": {
        this.getAllTicket();
        break;
      }
      case "Customer": {
        this.getAllTicket();
        break;
      }
    }
  }

  // getPagedTickets(event?: MatPaginator) {
  //   if (event !== undefined && event !== null) {
  //     this.pagination.skip = event.pageIndex * event.pageSize;
  //     this.pagination.take = event.pageSize;
  //   } else {
  //     this.pagination.take = this.pageSize;
  //   }
  //   this.getAllTicket();
  // }

  // openDialog(model: TicketModel): void {
  //   const dialogRef = this.dialog.open(HelperEditComponent, {
  //     width: 'auto',
  //     data: model
  //   });

  //   dialogRef.afterClosed().subscribe(result => {
  //     this.getAllHelper();
  //   });
  // }

  // openDeleteDialog(id) {
  //   let dialogRef = this.dialog.open(this.deleteDialog);

  //   dialogRef.afterClosed().subscribe(result => {
  //     // Note: If the user clicks outside the dialog or presses the escape key, there'll be no result
  //     if (result !== undefined) {
  //       if (result === 'yes') {
  //         this.deleteHelper(id);
  //       } else if (result === 'no') {
  //         //Do nothing
  //       }
  //     }
  //   })
  // }

  // deleteHelper(id) {
  //   this.helperService.deleteHelper(id)
  //     .subscribe(result => {
  //       this.getAllHelper();
  //     },
  //       error => {
  //         this.notificationService.errorMessage(error.message);
  //       });
  // }


}