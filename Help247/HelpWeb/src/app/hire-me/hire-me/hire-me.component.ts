import { Component, OnInit } from '@angular/core';
import { HireMeService } from '../services/hire-me.service';
import { HelperModel } from 'src/app/helper/models/helper.model';
import { PaginationBase } from 'src/app/shared/models/pagination-base.model';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { FormControl } from '@angular/forms';
import { Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';

@Component({
  selector: 'app-hire-me',
  templateUrl: './hire-me.component.html',
  styleUrls: ['./hire-me.component.scss']
})
export class HireMeComponent implements OnInit {

  helperList: Array<HelperModel>;
  pagination: PaginationBase;
  search: string = null;
  totalNoOfRecords: number = 0;
  searchQuery = new FormControl(null);
  searchTerm$ = new Subject<string>();


  constructor(
    private hireMeService: HireMeService,
    private route: ActivatedRoute,
    private toastr: ToastrService
  ) {
    this.pagination = new PaginationBase();
    this.searchTerm$.pipe(debounceTime(200))
      .pipe(distinctUntilChanged()).subscribe((data: any) => {
        if (data != "" && data) {
          this.pagination.searchQuery = data;
        }
        else {
          this.search = null;
        }
        this.getHelper();
      });
  }

  ngOnInit(): void {
    this.route.queryParamMap.subscribe(params => {
      this.search = params.get('search');
    })
    this.getHelper();

  }


  getHelper() {
    if (this.search != null) {
      this.patchSearch(this.search);
      this.pagination.searchQuery = this.search;
    }
    else if (this.searchQuery.value != null) {
      this.pagination.searchQuery = this.searchQuery.value;
    }
    this.hireMeService.getHelperList(this.pagination).subscribe(
      result => {
        this.helperList = result.details;
        this.totalNoOfRecords = result.totalRecords;
      },
      error => {
        this.toastr.error('Error', error.message);
      }
    );
  }

  patchSearch(term: string) {
    this.searchQuery.patchValue(term);
  }

}
