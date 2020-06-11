import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { PaginationBase } from '../models/pagination-base.model';
import { PaginationModel } from '../models/paginationModel';
import { HelperCategoryModel } from 'src/app/helper/models/helper-category.model';

@Injectable({
  providedIn: 'root'
})
export class HelperService extends BaseService {

  constructor(
    private http: HttpClient
  ) {
    super();
  }

  getHelperCategoryList(pagination: PaginationBase) {
    return this.http
      .get<PaginationModel<HelperCategoryModel>>(
        `${this.baseEndPoint}/api/HelperCategory/list?&skip=${
        pagination.skip
        }&take=${pagination.take}&searchQuery=${pagination.searchQuery}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }
}
