import { Component, OnInit } from '@angular/core';
import { PaginationBase } from 'src/app/shared/models/pagination-base.model';
import { HelperService } from '../services/helper.service';
import { HelperModel } from '../models/helper.model';
import { MatTableDataSource, MatDialog } from '@angular/material';
import { HelperEditComponent } from './helper-edit/helper-edit.component';

@Component({
  selector: 'app-helper',
  templateUrl: './helper.component.html',
  styleUrls: ['./helper.component.scss']
})
export class HelperComponent implements OnInit {

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

  dataSource = new MatTableDataSource();
  HELPER_DETAILS: Array<HelperModel>;
  pagination: PaginationBase;

  constructor(
    private helperService: HelperService,
    public dialog: MatDialog
  ) {
    this.pagination = new PaginationBase();
  }


  ngOnInit() {
    this.getAllHelper();
  }

  getAllHelper() {
    this.helperService.getHelper(this.pagination).subscribe(
      result => {
        this.HELPER_DETAILS = result.details;
        this.dataSource = new MatTableDataSource<HelperModel>(
          this.HELPER_DETAILS
        );
      },
      error => {

      }
    );
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
}