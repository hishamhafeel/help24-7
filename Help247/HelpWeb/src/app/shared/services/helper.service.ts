import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';
import { HttpClient } from '@angular/common/http';
import { catchError } from 'rxjs/operators';
import { PaginationBase } from '../models/pagination-base.model';
import { PaginationModel } from '../models/paginationModel';
import { HelperCategoryModel } from 'src/app/helper/models/helper-category.model';
import { HelperModel } from 'src/app/helper/models/helper.model';
import { SkillModel } from 'src/app/helper/models/skills.model';
import { JobsCountModel } from 'src/app/helper/models/jobs.model';
import { FeedbackModel } from 'src/app/hire-me/models/ticket.model';

@Injectable({
  providedIn: 'root'
})
export class HelperService extends BaseService {

  constructor(
    private http: HttpClient
  ) {
    super();
  }

  getHelperById(id: number) {
    return this.http
      .get<HelperModel>(
        `${this.baseEndPoint}/api/Helper/${id}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  updateHelper(model: any) {
    return this.http
      .put<HelperModel>(
        `${this.baseEndPoint}/api/Helper`, model, this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  getSkill(id: number) {
    return this.http
      .get<SkillModel>(
        `${this.baseEndPoint}/api/Skill/${id}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  addSkill(model: any) {
    return this.http
      .post<SkillModel>(
        `${this.baseEndPoint}/api/Skill`, model, this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  getHelperCategoryList(pagination: PaginationBase) {
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

  getJobCount(id: number) {
    return this.http
      .get<JobsCountModel>(
        `${this.baseEndPoint}/api/Ticket/count?&helperId=${id}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  getFeedbackByHelperId(id: number) {
    return this.http
      .get<Array<FeedbackModel>>(
        `${this.baseEndPoint}/api/Feedback/helperpublic?&id=${id}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }
}
