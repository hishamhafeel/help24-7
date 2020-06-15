import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from 'src/app/core/services/base.service';
import { PaginationBase } from 'src/app/shared/models/pagination-base.model';
import { PaginationModel } from 'src/app/shared/models/paginationModel';
import { TicketModel, TicketPaginationModel } from '../models/ticket.model';
import { catchError } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class TicketService extends BaseService {

  constructor(
    private http: HttpClient
  ) {
    super();
  }

  getTicket(pagination: TicketPaginationModel) {
    return this.http
      .get<PaginationModel<TicketModel>>(
        `${this.baseEndPoint}/api/Ticket/list?&skip=${
        pagination.skip
        }&take=${pagination.take}&searchQuery=${
        pagination.searchQuery}&ticketStatusId=${
        pagination.ticketStatusId}&helperId=${
        pagination.helperId}&customerId=${
        pagination.customerId}&helperName=${
        pagination.helperName}&customerName=${
        pagination.customerName}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

}
