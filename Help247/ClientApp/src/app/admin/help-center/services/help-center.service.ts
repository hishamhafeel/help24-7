import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';
import { HttpClient } from '@angular/common/http';
import { PaginationBase } from 'src/app/shared/models/pagination-base.model';
import { PaginationModel } from 'src/app/shared/models/paginationModel';
import { catchError } from 'rxjs/operators';
import { HelpCenterModel, HelpCenterUpdateModel } from '../models/help-center.model';

@Injectable({
  providedIn: 'root'
})
export class HelpCenterService extends BaseService {

  constructor(
    private http: HttpClient
  ) {
    super();
  }

  getHelpCenter(pagination: PaginationBase) {
    return this.http
      .get<PaginationModel<HelpCenterModel>>(
        `${this.baseEndPoint}/api/HelpCentre/List?&skip=${
        pagination.skip
        }&take=${pagination.take}&searchQuery=${pagination.searchQuery}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  updateHelpCenter(model: HelpCenterUpdateModel) {
    return this.http
      .put(
        `${this.baseEndPoint}/api/HelpCentre`,
        model,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }
}
