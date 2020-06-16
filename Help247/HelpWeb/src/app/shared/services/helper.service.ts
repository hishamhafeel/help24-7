import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { PaginationBase } from '../models/pagination-base.model';
import { PaginationModel } from '../models/paginationModel';
import { HelperCategoryModel } from 'src/app/helper/models/helper-category.model';
import { HelperModel } from 'src/app/helper/models/helper.model';

@Injectable({
  providedIn: 'root'
})
export class HelperService extends BaseService {

  constructor(
    private http: HttpClient
  ) {
    super();
  }

  getHelperById(id: number) {
    return this.http
      .get<HelperModel>(
        `${this.baseEndPoint}/api/Helper/${id}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  updateHelper(model: any) {
    return this.http
      .put<HelperModel>(
        `${this.baseEndPoint}/api/Helper`, model, this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
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

  getHelperList(pagination: PaginationBase) {
    return this.http
      .get<PaginationModel<HelperModel>>(
        `${this.baseEndPoint}/api/Helper/list?&skip=${
        pagination.skip
        }&take=${pagination.take}&searchQuery=${pagination.searchQuery}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }
}
