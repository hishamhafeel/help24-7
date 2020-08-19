import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';
import { HttpClient } from '@angular/common/http';
import { PaginationBase } from 'src/app/shared/models/pagination-base.model';
import { PaginationModel } from 'src/app/shared/models/paginationModel';
import { HelperModel } from 'src/app/helper/models/helper.model';
import { catchError } from 'rxjs/operators';
import { TicketModel } from '../models/ticket.model';
import { HelperCategoryDropDownModel, HelperPagination } from '../models/helperCategory.model';

@Injectable({
  providedIn: 'root'
})
export class HireMeService extends BaseService {

  constructor(
    private http: HttpClient
  ) {
    super();
  }

  getHelperList(pagination: HelperPagination) {
    return this.http
      .get<PaginationModel<HelperModel>>(
        `${this.baseEndPoint}/api/Helper/list?&skip=${
        pagination.skip
        }&take=${pagination.take}&searchQuery=${pagination.searchQuery
        }&HelperCategoryId=${pagination.helperCategoryId}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  getHelperById(id) {
    return this.http
      .get<HelperModel>(
        `${this.baseEndPoint}/api/Helper/${id}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  getHelperCategory() {
    return this.http
      .get<Array<HelperCategoryDropDownModel>>(
        `${this.baseEndPoint}/api/HelperCategory/categories/`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  assignTicket(model: any) {
    return this.http
      .post(
        `${this.baseEndPoint}/api/Ticket/assign`,
        model,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  getTicketListCustomer(pagination: PaginationBase, customerId: number) {
    return this.http
      .get<PaginationModel<TicketModel>>(
        `${this.baseEndPoint}/api/Ticket/list?CustomerId=${customerId}&skip=${
        pagination.skip
        }&take=${pagination.take}&searchQuery=${pagination.searchQuery}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  getTicketListHelper(pagination: PaginationBase, helperId: number) {
    return this.http
      .get<PaginationModel<TicketModel>>(
        `${this.baseEndPoint}/api/Ticket/list?HelperId=${helperId}&skip=${
        pagination.skip
        }&take=${pagination.take}&searchQuery=${pagination.searchQuery}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  getTicketById(id: number) {
    return this.http
      .get<TicketModel>(
        `${this.baseEndPoint}/api/Ticket/${id}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  approveTicket(id: number) {
    return this.http
      .put<TicketModel>(
        `${this.baseEndPoint}/api/Ticket/approve?id=${id}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  completeTicket(id: number) {
    return this.http
      .put<TicketModel>(
        `${this.baseEndPoint}/api/Ticket/complete?id=${id}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }
}
