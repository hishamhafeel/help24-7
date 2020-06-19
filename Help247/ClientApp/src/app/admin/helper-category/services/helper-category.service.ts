import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from 'src/app/core/services/base.service';
import { PaginationBase } from 'src/app/shared/models/pagination-base.model';
import { PaginationModel } from 'src/app/shared/models/paginationModel';
import { HelperCategoryModel, SubServiceModel } from '../models/helper-category.model';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class HelperCategoryService extends BaseService {

  constructor(
    private http: HttpClient
  ) {
    super();
  }

  getHelperCategory(pagination: PaginationBase) {
    return this.http
      .get<PaginationModel<HelperCategoryModel>>(
        `${this.baseEndPoint}/api/HelperCategory/list?&skip=${
        pagination.skip
        }&take=${pagination.take}&searchQuery=${pagination.searchQuery}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  getHelperCategoryById(id: number) {
    return this.http
      .get<HelperCategoryModel>(
        `${this.baseEndPoint}/api/HelperCategory/${id}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  postSubService(model: SubServiceModel) {
    return this.http
      .post(
        `${this.baseEndPoint}/api/HelperCategory/subservice`, model,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  updateSubService(model: SubServiceModel) {
    return this.http
      .put(
        `${this.baseEndPoint}/api/HelperCategory/subservice`, model,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  deleteSubService(id) {
    return this.http
      .delete(
        `${this.baseEndPoint}/api/HelperCategory/subservice?id=${id}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  updateHelperCategory(model: HelperCategoryModel) {
    return this.http
      .put(
        `${this.baseEndPoint}/api/HelperCategory`,
        model,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }
}

