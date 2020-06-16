import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';
import { HttpClient } from '@angular/common/http';
import { PaginationBase } from 'src/app/shared/models/pagination-base.model';
import { PaginationModel } from 'src/app/shared/models/paginationModel';
import { HelperModel } from 'src/app/helper/models/helper.model';
import { catchError } from 'rxjs/operators';
import { TicketModel } from '../models/ticket.model';

@Injectable({
  providedIn: 'root'
})
export class HireMeService extends BaseService {

  constructor(
    private http: HttpClient
  ) {
    super();
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

  getHelperById(id) {
    return this.http
      .get<HelperModel>(
        `${this.baseEndPoint}/api/Helper/${id}`,
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

  getTicketList(pagination: PaginationBase) {
    return this.http
      .get<PaginationModel<TicketModel>>(
        `${this.baseEndPoint}/api/Ticket/list?CustomerId=1&skip=${
        pagination.skip
        }&take=${pagination.take}&searchQuery=${pagination.searchQuery}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }
}
