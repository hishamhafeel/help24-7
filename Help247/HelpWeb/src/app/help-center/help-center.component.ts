import { Component, OnInit } from '@angular/core';
import { HelpCenterService } from './services/help-center.service';
import { PaginationBase } from '../shared/models/pagination-base.model';
import { HelpCenterModel, HelpCenterUpdateModel } from './models/help-center.model';

@Component({
  selector: 'app-help-center',
  templateUrl: './help-center.component.html',
  styleUrls: ['./help-center.component.scss']
})
export class HelpCenterComponent implements OnInit {

  pagination: PaginationBase;
  helpCenterModel: Array<HelpCenterModel>;
  updateModel: HelpCenterUpdateModel;

  constructor(private helpCenterService: HelpCenterService) {
    this.pagination = new PaginationBase();
  }

  ngOnInit(): void {
    this.getAllHelpCenterList();
  }

  getAllHelpCenterList() {
    this.helpCenterService.getHelpCenter(this.pagination).subscribe(
      result => {
        console.log('result', result);
        this.helpCenterModel = result.details;
        console.log('model', this.helpCenterModel);
      },
      error => {
      }
    );
  }

}
