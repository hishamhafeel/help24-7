import { Component, OnInit } from '@angular/core';
import { OwlOptions } from 'ngx-owl-carousel-o';
import { HelperModel } from '../helper/models/helper.model';
import { HelperService } from '../shared/services/helper.service';
import { PaginationBase } from '../shared/models/pagination-base.model';
import { HelperCategoryModel } from '../helper/models/helper-category.model';
import { FormControl } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {

  helperList: Array<HelperModel>;
  helperCategoryList: Array<HelperCategoryModel>;
  pagination: PaginationBase;

  searchTerm = new FormControl(null);
  noOfHelpers: number;
  noOfJobs: number;
  noOfClients: number;
  noOfOnGoingJobs: number;
  customOptions: OwlOptions = {
    loop: true,
    margin: 30,
    nav: true,
    dots: false,
    items: 4,
    navText: ["<img src='assets/images/slider-prv.png'>", "<img src='assets/images/slider-nxt.png'>"],
    responsive: {
      0: {
        items: 1
      },
      600: {
        items: 1
      },
      768: {
        items: 3
      },
      1024: {
        items: 4
      }
    }
  }

  bannerOptions: OwlOptions = {
    loop: true,
    margin: 0,
    nav: true,
    dots: false,
    items: 1,
    navText: ["<img src='assets/images/hmbanner-prev.png'>", "<img src='assets/images/hmbanner-nxt.png'>"],
    responsive: {
      0: {
        items: 1,
      },
      600: {
        items: 1,
      },
      1000: {
        items: 1,
      }
    }
  }

  constructor(
    private helperService: HelperService,
    private router: Router
  ) {
    this.pagination = new PaginationBase();
  }

  ngOnInit(): void {
    this.getHelper();
    this.getHelperCategory();
  }

  getHelper() {
    this.helperService.getHelperList(this.pagination).subscribe(
      result => {
        console.log('result', result);
        this.helperList = result.details;
      },
      error => {
        console.log('error', error);
      }
    );
  }

  getHelperCategory() {
    this.pagination.take = 8;
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

  searchHelper() {
    this.router.navigate(['/hire-me'], { queryParams: { search: this.searchTerm.value } });
  }

}
