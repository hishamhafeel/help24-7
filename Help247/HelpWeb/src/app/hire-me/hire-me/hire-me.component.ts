import { Component, OnInit } from '@angular/core';
import { HireMeService } from '../services/hire-me.service';
import { HelperModel } from 'src/app/helper/models/helper.model';
import { PaginationBase } from 'src/app/shared/models/pagination-base.model';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-hire-me',
  templateUrl: './hire-me.component.html',
  styleUrls: ['./hire-me.component.scss']
})
export class HireMeComponent implements OnInit {
  
  helperList: Array<HelperModel>;
  pagination: PaginationBase;

  constructor(
    private hireMeService: HireMeService
  ) {
    this.pagination = new PaginationBase();
   }

  ngOnInit(): void {
    this.getHelper();
  }


  getHelper() {
    this.hireMeService.getHelperList(this.pagination).subscribe(
      result => {
        console.log('result', result);
        this.helperList = result.details;
      },
      error => {
        console.log('error', error);
      }
    );
  }

}
