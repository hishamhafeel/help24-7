import { Component, OnInit, TemplateRef, ViewChild, AfterViewInit, ElementRef } from '@angular/core';
import { MatPaginator, MatTableDataSource, MatDialog } from '@angular/material';
import { PaginationBase } from 'src/app/shared/models/pagination-base.model';
import { AdminModel, CreateAdminModel } from '../Models/create-admin.model';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { CreateAdminService } from '../services/create-admin.service';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ValidatorService } from '../../auth/services/validator.service';

@Component({
  selector: 'app-create-admin',
  templateUrl: './create-admin.component.html',
  styleUrls: ['./create-admin.component.scss']
})
export class CreateAdminComponent implements OnInit {
  @ViewChild('deleteDialog', { static: false }) deleteDialog: TemplateRef<CreateAdminComponent>;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  adminForm: FormGroup;
  dataSource = new MatTableDataSource();
  createAdminModel = new CreateAdminModel();
  ADMIN_DETAILS: Array<AdminModel>;
  pagination: PaginationBase;
  pageSize = 10;
  isLoadingResults: boolean = false;
  isBlocked: boolean = false;


  displayedColumns: string[] = [
    'id',
    'userName',
    'email',
    'createdOn',
    'delete'
  ];

  constructor(
    private notificationService: NotificationService,
    public dialog: MatDialog,
    private createAdminService: CreateAdminService,
    private fb: FormBuilder,
    public validatorService: ValidatorService) {
    this.pagination = new PaginationBase();

  }



  ngOnInit() {
    this.initAdminForm();
    this.getAllAdmins();
  }

  initAdminForm() {
    this.adminForm = this.fb.group({
      id: [{ value: '', disabled: true }],
      userName: [
        '',
        {
          Validators: [Validators.required],
          asyncValidators: [this.validatorService.checkUsername.bind(this.validatorService)],
          updateOn: 'blur'
        }
      ],
      email: ['',
        {
          Validators: [Validators.required, Validators.email],
          asyncValidators: [this.validatorService.checkEmail.bind(this.validatorService)],
          updateOn: 'blur'
        }
      ],
      password: ['', Validators.required],

    });
  }

  get userName() {
    return this.adminForm.get('userName');
  }

  get email() {
    return this.adminForm.get('email');
  }
  get password() {
    return this.adminForm.get('password');
  }
  get f() {
    return this.adminForm.controls;
  }


  getAllAdmins() {
    this.isLoadingResults = true;
    this.createAdminService.getAllAdmin(this.pagination).subscribe(
      result => {
        this.ADMIN_DETAILS = result.details;
        this.dataSource = new MatTableDataSource<AdminModel>(
          this.ADMIN_DETAILS
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

  getPagedAdmins(event?: MatPaginator) {
    if (event !== undefined && event !== null) {
      this.pagination.skip = event.pageIndex * event.pageSize;
      this.pagination.take = event.pageSize;
    } else {
      this.pagination.take = this.pageSize;
    }
    this.getAllAdmins();
  }

  openDeleteDialog(userId) {
    let dialogRef = this.dialog.open(this.deleteDialog);

    dialogRef.afterClosed().subscribe(result => {
      // Note: If the user clicks outside the dialog or presses the escape key, there'll be no result
      if (result !== undefined) {
        if (result === 'yes') {
          this.deleteAdmin(userId);
        } else if (result === 'no') {
          //Do nothing
        }
      }
    })
  }

  deleteAdmin(id: string) {
    this.createAdminService.deleteAdmin(id)
      .subscribe(result => {
        this.getAllAdmins();
      },
        error => {
          this.notificationService.errorMessage(error.message);
        });
  }

  createAdmin() {
    this.isBlocked = true;
    this.createAdminModel = this.adminForm.value;

    this.createAdminService.createAdmin(this.createAdminModel).subscribe(
      () => {
        this.notificationService.successMessage("Successfully created Admin");
      },
      error => {
        this.isBlocked = false;
        this.notificationService.errorMessage(error.message);
      }
    );
  }

}
