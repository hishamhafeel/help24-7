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

  @ViewChild('callAPIDialog', { static: true }) callAPIDialog: TemplateRef<any>;
  @ViewChild('deleteDialog', { static: true }) deleteDialog: TemplateRef<any>;

  pagination: PaginationBase;
  helpCenterModel: Array<HelpCenterModel>;
  updateModel: HelpCenterUpdateModel;
  isLoadingResults: boolean = true;
  topics: { [key: string]: string };
  myKey = '';
  myValue = '';
  editSubId: number;
  deleteSubId: number;

  topic: [
    {
      id: number,
      key: string,
      value: string
    }
  ]

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

        let i = 0;
        this.helpCenterModel.forEach(model => {
          let topics = Object.entries(model.topics);
          let objArr = []
          topics.forEach(function (value) {
            let tempObj = { id: 0, key: '', value: '' };
            tempObj.id = i++;
            tempObj.key = value[0];
            tempObj.value = value[1];
            objArr.push(tempObj);
          });
          console.log(objArr);
          model.topics2 = objArr;
        });
        console.log("FINAL", this.helpCenterModel);
        this.isLoadingResults = false;
      },
      error => {
        this.isLoadingResults = false;
        this.notificationService.errorMessage(error.message);
      }
    );
  }

  addValue(data, addValue: boolean) {
    this.updateModel = new HelpCenterUpdateModel();
    this.updateModel = data;

    this.topics = {};
    this.topics = data.topics;
    if(addValue){
      this.topics[this.title.value] = this.description.value;
    }
    this.updateModel.topics = JSON.stringify(this.topics);

    this.helpCenterService.updateHelpCenter(this.updateModel).subscribe(
      () => {
        this.getAllHelpCenterList();
        this.title.reset();
        this.description.reset();
        this.myKey = '';
        this.myValue = '';
        this.notificationService.successMessage("Successfully updated!");
      },
      error => {
        this.isLoadingResults = false;
        this.notificationService.errorMessage(error.message);
      }
    );
  }

  openDialog(item): void {
    this.helpCenterModel.forEach(element => {
      var r = element.topics2.find(x=>x.id == item.id);
      if(r != undefined){
        this.myKey = r.key;
        this.myValue = r.value;
      }
    });
    this.editSubId = item.id;
    
    const dialogRef = this.dialog.open(this.callAPIDialog, {
      width: '100vw'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result !== undefined) {
        if (result === 'yes') {
          this.helpCenterModel.forEach(element => {
            var r = element.topics2.find(x=>x.id == this.editSubId);
            if(r != undefined){
              delete element.topics[r.key];
              element.topics[this.myKey] = this.myValue;
              this.addValue(element, false);
            }
          });
          this.editSubId = undefined;
        } else if (result === 'no') {
          //Do nothing
        }
      }
    });
  }

  openDeleteDialog(item){
    this.deleteSubId = item.id;
    const dialogRef = this.dialog.open(this.deleteDialog, {
      width: '100vw'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result !== undefined) {
        if (result === 'yes') {
          this.helpCenterModel.forEach(element => {
            var r = element.topics2.find(x=>x.id == this.deleteSubId);
            if(r != undefined){
              delete element.topics[r.key];
              this.addValue(element, false);
            }
          });
          this.deleteSubId = undefined;
        } else if (result === 'no') {
          //Do nothing
        }
      }
    });
  }


}
