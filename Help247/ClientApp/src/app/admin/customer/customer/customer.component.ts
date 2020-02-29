import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { MatTableDataSource, MatPaginator, MatDialog } from '@angular/material';
import { CustomerModel } from '../models/customer.model';
import { PaginationBase } from 'src/app/shared/models/pagination-base.model';
import { CustomerService } from '../services/customer.service';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { CustomerEditComponent } from './customer-edit/customer-edit.component';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  @ViewChild('deleteDialog', { static: false }) deleteDialog: TemplateRef<CustomerComponent>;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  dataSource = new MatTableDataSource();
  CUSTOMER_DETAILS: Array<CustomerModel>;
  pagination: PaginationBase;
  pageSize = 10;
  isLoadingResults: boolean = false;

  displayedColumns: string[] = [
    'id',
    'name',
    'phoneNo',
    'email',
    'country',
    'province',
    'district',
    'city',
    'edit',
    'delete'
  ];

  constructor(
    private customerService: CustomerService,
    private notificationService: NotificationService,
    public dialog: MatDialog
  ) {
    this.pagination = new PaginationBase();
  }


  ngOnInit() {
    this.getAllCustomer();
  }

  getAllCustomer() {
    this.isLoadingResults = true;
    this.customerService.getCustomer(this.pagination).subscribe(
      result => {
        this.CUSTOMER_DETAILS = result.details;
        this.dataSource = new MatTableDataSource<CustomerModel>(
          this.CUSTOMER_DETAILS
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

  getPagedCustomers(event?: MatPaginator) {
    if (event !== undefined && event !== null) {
      this.pagination.skip = event.pageIndex * event.pageSize;
      this.pagination.take = event.pageSize;
    } else {
      this.pagination.take = this.pageSize;
    }
    this.getAllCustomer();
  }

  openDialog(model: CustomerModel): void {
    const dialogRef = this.dialog.open(CustomerEditComponent, {
      width: 'auto',
      data: model
    });

    dialogRef.afterClosed().subscribe(result => {
      this.getAllCustomer();
    });
  }

  openDeleteDialog(id) {
    let dialogRef = this.dialog.open(this.deleteDialog);

    dialogRef.afterClosed().subscribe(result => {
      // Note: If the user clicks outside the dialog or presses the escape key, there'll be no result
      if (result !== undefined) {
        if (result === 'yes') {
          this.deleteCustomer(id);
        } else if (result === 'no') {
          //Do nothing
        }
      }
    })
  }

  deleteCustomer(id) {
    this.customerService.deleteCustomer(id)
      .subscribe(result => {
        this.getAllCustomer();
      },
        error => {
          this.notificationService.errorMessage(error.message);
        });
  }
}
