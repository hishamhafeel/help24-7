import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';
import { HttpClient } from '@angular/common/http';
import { PaginationBase } from 'src/app/shared/models/pagination-base.model';
import { PaginationModel } from 'src/app/shared/models/paginationModel';
import { CustomerModel } from '../models/customer.model';
import { catchError } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class CustomerService extends BaseService {

  constructor(
    private http: HttpClient
  ) {
    super();
  }

  getCustomer(pagination: PaginationBase) {
    return this.http
      .get<PaginationModel<CustomerModel>>(
        `${this.baseEndPoint}/api/Customer/list?&skip=${
        pagination.skip
        }&take=${pagination.take}&searchQuery=${pagination.searchQuery}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  updateCustomer(customerModel: CustomerModel) {
    return this.http
      .put(
        `${this.baseEndPoint}/api/Customer`,
        customerModel,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  deleteCustomer(id: number) {
    return this.http
      .delete(
        `${
        this.baseEndPoint
        }/api/Customer/${id}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }
}