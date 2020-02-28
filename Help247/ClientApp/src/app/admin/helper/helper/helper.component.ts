import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { PaginationBase } from 'src/app/shared/models/pagination-base.model';
import { HelperService } from '../services/helper.service';
import { HelperModel } from '../models/helper.model';
import { MatTableDataSource, MatDialog, MatPaginator } from '@angular/material';
import { HelperEditComponent } from './helper-edit/helper-edit.component';
import { NotificationService } from 'src/app/shared/services/notification.service';

@Component({
  selector: 'app-helper',
  templateUrl: './helper.component.html',
  styleUrls: ['./helper.component.scss']
})
export class HelperComponent implements OnInit {

  @ViewChild('deleteDialog', { static: false }) deleteDialog: TemplateRef<HelperComponent>;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  dataSource = new MatTableDataSource();
  HELPER_DETAILS: Array<HelperModel>;
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
    'helperCategory',
    'edit',
    'delete'
  ];


  constructor(
    private helperService: HelperService,
    private notificationService: NotificationService,
    public dialog: MatDialog
  ) {
    this.pagination = new PaginationBase();
  }


  ngOnInit() {
    this.getAllHelper();
  }

  getAllHelper() {
    this.isLoadingResults = true;
    this.helperService.getHelper(this.pagination).subscribe(
      result => {
        this.HELPER_DETAILS = result.details;
        this.dataSource = new MatTableDataSource<HelperModel>(
          this.HELPER_DETAILS
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

  getPagedHelpers(event?: MatPaginator) {
    if (event !== undefined && event !== null) {
      this.pagination.skip = event.pageIndex * event.pageSize;
      this.pagination.take = event.pageSize;
    } else {
      this.pagination.take = this.pageSize;
    }
    this.getAllHelper();
  }

  openDialog(model: HelperModel): void {
    const dialogRef = this.dialog.open(HelperEditComponent, {
      width: 'auto',
      data: model
    });

    dialogRef.afterClosed().subscribe(result => {
      this.getAllHelper();
    });
  }

  openDeleteDialog(id) {
    let dialogRef = this.dialog.open(this.deleteDialog);

    dialogRef.afterClosed().subscribe(result => {
      // Note: If the user clicks outside the dialog or presses the escape key, there'll be no result
      if (result !== undefined) {
        if (result === 'yes') {
          this.deleteHelper(id);
        } else if (result === 'no') {
          //Do nothing
        }
      }
    })
  }

  deleteHelper(id) {
    this.helperService.deleteHelper(id)
      .subscribe(result => {
        this.getAllHelper();
      },
        error => {
          this.notificationService.errorMessage(error.message);
        });
  }
}