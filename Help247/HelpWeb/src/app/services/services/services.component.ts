import { Component, OnInit } from '@angular/core';
import { HelperService } from 'src/app/shared/services/helper.service';
import { HelperCategoryModel } from 'src/app/helper/models/helper-category.model';
import { PaginationBase } from 'src/app/shared/models/pagination-base.model';

@Component({
  selector: 'app-services',
  templateUrl: './services.component.html',
  styleUrls: ['./services.component.scss']
})
export class ServicesComponent implements OnInit {
  
  helperCategoryList: Array<HelperCategoryModel>
  pagination: PaginationBase;

  constructor(private helperService: HelperService) {
    this.pagination = new PaginationBase();
   }

  ngOnInit(): void {
    this.getHelperCategory()
  }

  getHelperCategory() {
    this.helperService.getHelperCategoryList(this.pagination).subscribe(
      result => {
        console.log('result', result);
        this.helperCategoryList = result.details;
      },
      error => {
        console.log('error', error);
      }
    );
  }

}
