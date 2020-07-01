import { Component, OnInit, ViewChild, TemplateRef } from '@angular/core';
import { HelpCenterService } from '../services/help-center.service';
import { PaginationBase } from 'src/app/shared/models/pagination-base.model';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { HelpCenterModel, HelpCenterUpdateModel } from '../models/help-center.model';
import { FormControl } from '@angular/forms';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-help-center',
  templateUrl: './help-center.component.html',
  styleUrls: ['./help-center.component.scss']
})
export class HelpCenterComponent implements OnInit {

  @ViewChild('callAPIDialog', {static: true}) callAPIDialog: TemplateRef<any>;

  pagination: PaginationBase;
  helpCenterModel: Array<HelpCenterModel>;
  updateModel: HelpCenterUpdateModel;
  isLoadingResults: boolean = true;
  topics: {[key: string]: string};

  title = new FormControl('');
  description = new FormControl('');

  isEdit: boolean = false;
  editTitle = new FormControl('');
  editDescription = new FormControl('');

  constructor(
    private helpCenterService: HelpCenterService,
    private notificationService: NotificationService,
    public dialog: MatDialog
  ) {
    this.pagination = new PaginationBase();
  }

  ngOnInit() {
    this.getAllHelpCenterList();
  }

  getAllHelpCenterList() {
    this.isLoadingResults = true;
    this.helpCenterService.getHelpCenter(this.pagination).subscribe(
      result => {
        this.helpCenterModel = result.details;
        this.isLoadingResults = false;
      },
      error => {
        this.isLoadingResults = false;
        this.notificationService.errorMessage(error.message);
      }
    );
  }

  addValue(data){
    this.updateModel = new HelpCenterUpdateModel();
    this.updateModel = data;

    this.topics = {};
    this.topics = data.topics;
    this.topics[this.title.value] = this.description.value;
    this.updateModel.topics = JSON.stringify(this.topics);

    this.helpCenterService.updateHelpCenter(this.updateModel).subscribe(
      () => {
        this.getAllHelpCenterList();
        this.title.reset();
        this.description.reset();
        this.notificationService.successMessage("Successfully updated!");
      },
      error => {
        this.isLoadingResults = false;
        this.notificationService.errorMessage(error.message);
      }
    );
  }

  openDialog(item, key): void {
    console.log(item);
    var obj = this.helpCenterModel.find(x=>x.id == item.id);
    var test = this.getKeyByValue(obj.topics, key);
    console.log(test);
    const dialogRef = this.dialog.open(this.callAPIDialog, {
      width: '100vw'
    });

    dialogRef.afterClosed().subscribe(result => {
      // this.getAllHelpCenterList();
    });
  }

  getKeyByValue(object, value) {
    return Object.keys(object).find(key => object[JSON.stringify(key)] === value);
  }

}
