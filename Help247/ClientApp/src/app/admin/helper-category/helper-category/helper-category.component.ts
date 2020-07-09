import { Component, OnInit, TemplateRef, ViewChild } from '@angular/core';
import { HelperCategoryService } from '../services/helper-category.service';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { PaginationBase } from 'src/app/shared/models/pagination-base.model';
import { HelperCategoryModel } from '../models/helper-category.model';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { MatPaginator, MatTableDataSource, MatDialog } from '@angular/material';
import { HelperCategoryEditComponent } from './helper-category-edit/helper-category-edit.component';
import { identity } from 'rxjs';

@Component({
  selector: 'app-helper-category',
  templateUrl: './helper-category.component.html',
  styleUrls: ['./helper-category.component.scss']
})
export class HelperCategoryComponent implements OnInit {
  @ViewChild('deleteDialog', { static: false }) deleteDialog: TemplateRef<HelperCategoryComponent>;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;

  dataSource = new MatTableDataSource();

  helperCategoryForm: FormGroup;
  HELPER_CATEGORY_DETAILS: Array<HelperCategoryModel>;
  pagination: PaginationBase;
  pageSize = 10;
  isLoadingResults: boolean = false;
  servicesProvided: { [key: string]: string };

  helperCategory: HelperCategoryModel;
  subServiceName = new FormControl('');
  description = new FormControl('');

  displayedColumns: string[] = [
    'id',
    'name',
    'title',
    // 'shortDescription',
    'edit',
    'delete'
  ];

  constructor(
    private helperCategoryService: HelperCategoryService,
    private notificationService: NotificationService,
    public dialog: MatDialog,
    private fb: FormBuilder) {
    this.pagination = new PaginationBase();

  }

  ngOnInit() {
    this.getHelperCategory();

  }


  getHelperCategory() {
    this.isLoadingResults = true;
    this.helperCategoryService.getHelperCategory(this.pagination).subscribe(
      result => {
        this.HELPER_CATEGORY_DETAILS = result.details;
        this.dataSource = new MatTableDataSource<HelperCategoryModel>(
          this.HELPER_CATEGORY_DETAILS
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

  openDialog(id: number): void {
    const dialogRef = this.dialog.open(HelperCategoryEditComponent, {
      width: '100vw',
      height: '80vh',
      data: id
    });

    dialogRef.afterClosed().subscribe(result => {
      this.getHelperCategory();
    });
  }

  openDeleteDialog(id) {
    let dialogRef = this.dialog.open(this.deleteDialog);

    dialogRef.afterClosed().subscribe(result => {
      // Note: If the user clicks outside the dialog or presses the escape key, there'll be no result
      if (result !== undefined) {
        if (result === 'yes') {
          this.deleteHelperCategory(id);
        } else if (result === 'no') {
          //Do nothing
        }
      }
    })
  }

  deleteHelperCategory(id) {
    this.helperCategoryService.deleteHelperCategory(id)
      .subscribe(result => {
        this.getHelperCategory();
      },
        error => {
          this.notificationService.errorMessage(error.message);
        });
  }


}
