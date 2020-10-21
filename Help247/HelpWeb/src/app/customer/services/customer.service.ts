import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';
import { CustomerModel } from '../models/customer.model';
import { catchError } from 'rxjs/operators';
import { HttpClient } from '@angular/common/http';
import {
  FeedbackModel,
  TicketModel,
} from 'src/app/hire-me/models/ticket.model';
import { PaginationBase } from 'src/app/shared/models/pagination-base.model';
import { PaginationModel } from 'src/app/shared/models/paginationModel';

@Injectable({
  providedIn: 'root',
})
export class CustomerService extends BaseService {
  constructor(private http: HttpClient) {
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
        `${this.baseEndPoint}/api/Customer`,
        model,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  addFeedback(model: any) {
    return this.http
      .post<FeedbackModel>(
        `${this.baseEndPoint}/api/Feedback`,
        model,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  getFeedbackList(pagination: PaginationBase, customerId: number) {
    return this.http
      .get<PaginationModel<FeedbackModel>>(
        `${this.baseEndPoint}/api/Feedback/list?CustomerId=${customerId}&skip=${pagination.skip}&take=${pagination.take}&searchQuery=${pagination.searchQuery}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  updateTicket(ticket: TicketModel) {
    return this.http
      .put<TicketModel>(
        `${this.baseEndPoint}/api/Ticket/`,
        ticket,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  getFeedback(feedbackId: number) {
    return this.http
      .get<FeedbackModel>(
        `${this.baseEndPoint}/api/Feedback/${feedbackId}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }
  getLastTicket() {
    return this.http
      .get<TicketModel>(
        `${this.baseEndPoint}/api/Ticket/lastticket`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }
  deleteFeedback(feedbackId: number) {
    return this.http
      .delete(
        `${this.baseEndPoint}/api/Feedback/${feedbackId}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }
  updateFeedback(feedback: FeedbackModel) {
    return this.http
      .put<FeedbackModel>(
        `${this.baseEndPoint}/api/Feedback/`,
        feedback,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }


}
