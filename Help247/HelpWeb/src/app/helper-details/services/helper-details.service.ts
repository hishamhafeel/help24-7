import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BaseService } from 'src/app/core/services/base.service';
import { catchError } from 'rxjs/operators';
import { HelperModel, TicketCountModel } from 'src/app/helper/models/helper.model';

@Injectable({
  providedIn: 'root'
})
export class HelperDetailsService extends BaseService {

  constructor(private http: HttpClient) {
    super();
  }

  getHelperDetailsById(id: number) {
    return this.http.get<HelperModel>(`${this.baseEndPoint}/api/Helper/${id}`,
      this.httpOptions)
      .pipe(catchError(this.server4xxError))
  }

  getJobCounts(id: number) {
    return this.http.get<TicketCountModel>(`${this.baseEndPoint}/api/Ticket/count?helperId=${id}`,
      this.httpOptions)
      .pipe(catchError(this.server4xxError))
  }
}
