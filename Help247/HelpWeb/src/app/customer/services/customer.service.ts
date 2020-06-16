import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';
import { CustomerModel } from '../models/customer.model';
import { catchError } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CustomerService extends BaseService {

  constructor(
    private http: HttpClient
  ) {
    super();
  }

  getCustomerById(id: number) {
    return this.http
      .get<CustomerModel>(
        `${this.baseEndPoint}/api/Customer/${id}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  updateCustomer(model: any) {
    return this.http
      .put<CustomerModel>(
        `${this.baseEndPoint}/api/Customer`, model, this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }
}
