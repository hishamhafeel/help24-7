import { Component, OnInit } from '@angular/core';
import { HelpCenterService } from '../services/help-center.service';
import { PaginationBase } from 'src/app/shared/models/pagination-base.model';
import { NotificationService } from 'src/app/shared/services/notification.service';
import { HelpCenterModel, HelpCenterUpdateModel } from '../models/help-center.model';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-help-center',
  templateUrl: './help-center.component.html',
  styleUrls: ['./help-center.component.scss']
})
export class HelpCenterComponent implements OnInit {

  pagination: PaginationBase;
  helpCenterModel: Array<HelpCenterModel>;
  updateModel: HelpCenterUpdateModel;
  isLoadingResults: boolean = true;
  topics: {[key: string]: string};

  title = new FormControl('');
  description = new FormControl('');

  constructor(
    private helpCenterService: HelpCenterService,
    private notificationService: NotificationService
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
        console.log('result', result);
        this.helpCenterModel = result.details;
        console.log('model', this.helpCenterModel);
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

}
