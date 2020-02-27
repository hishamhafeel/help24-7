import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';
import { PaginationBase } from 'src/app/shared/models/pagination-base.model';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { PaginationModel } from 'src/app/shared/models/paginationModel';
import { HelperModel, HelperCategoryModel } from '../models/helper.model';

@Injectable({
  providedIn: 'root'
})
export class HelperService extends BaseService {

  constructor(
    private http: HttpClient
  ) {
    super();
  }

  getHelper(pagination: PaginationBase) {
    return this.http
      .get<PaginationModel<HelperModel>>(
        `${this.baseEndPoint}/api/Helper/HelperList?&skip=${
        pagination.skip
        }&take=${pagination.take}&searchQuery=${pagination.searchQuery}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  getHelperCategoryList() {
    return this.http
      .get<Array<HelperCategoryModel>>(
        `${this.baseEndPoint}/api/Helper/HelperCategoryList`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  updateHelper(helperModel: HelperModel) {
    return this.http
      .put(
        `${this.baseEndPoint}/api/Helper`,
        helperModel,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  deleteHelper(id: number) {
    return this.http
      .delete(
        `${
          this.baseEndPoint
        }/api/Helper/${id}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }
}