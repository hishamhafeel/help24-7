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
    // this.initHelperCategoryForm();
    this.getHelperCategory();

  }

  // initHelperCategoryForm() {
  //   this.helperCategoryForm = this.fb.group({
  //     id: [{ value: '', disabled: true }],
  //     name: ['', Validators.required],
  //     title: ['', Validators.required],
  //     shortDescription: ['', Validators.required],
  //     longDescription: ['', Validators.required],
  //     iconUrl: ['', Validators.required],
  //     imageUrl: ['', Validators.required]
  //   });
  //   // this.patchHelperCategoryForm();
  // }

  // patchHelperCategoryForm() {
  //   this.helperCategoryForm.patchValue({
  //     id: this.helperCategory.id,
  //     name: this.helperCategory.name,
  //     title: this.helperCategory.title,
  //     shortDescription: this.helperCategory.shortDescription,
  //     longDescription: this.helperCategory.longDescription,
  //     iconUrl: this.helperCategory.iconUrl,
  //     imageUrl: this.helperCategory.imageUrl,
  //     servicesProvided: this.helperCategory.servicesProvided,

  //   });
  // }

  // get id() {
  //   return this.helperCategoryForm.get('id');
  // }
  // get name() {
  //   return this.helperCategoryForm.get('name');
  // }

  // get title() {
  //   return this.helperCategoryForm.get('title');
  // }
  // get shortDescription() {
  //   return this.helperCategoryForm.get('shortDescription');
  // }
  // get longDescription() {
  //   return this.helperCategoryForm.get('longDescription');
  // }
  // get iconUrl() {
  //   return this.helperCategoryForm.get('iconUrl');
  // }
  // get imageUrl() {
  //   return this.helperCategoryForm.get('imageUrl');
  // }



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
      data: id
    });

    dialogRef.afterClosed().subscribe(result => {
      this.getHelperCategory();
    });
  }


  // saveValue(data: any) {
  //   var x = this.helperCategoryForm.value;
  //   this.helperCategory = new HelperCategoryModel();
  //   this.helperCategory = this.helperCategoryForm.value;

  //   this.servicesProvided = {};
  //   this.servicesProvided = data.servicesProvided;
  //   this.servicesProvided[this.subServiceName.value] = this.description.value;
  //   this.helperCategory.servicesProvided = this.servicesProvided;

  //   this.helperCategoryService.updateHelperCategory(this.helperCategory).subscribe(
  //     () => {
  //       this.getHelperCategory();
  //       this.subServiceName.reset();
  //       this.description.reset();
  //       this.notificationService.successMessage("Successfully updated!");
  //     },
  //     error => {
  //       this.isLoadingResults = false;
  //       this.notificationService.errorMessage(error.message);
  //     }
  //   );
  // }


}
