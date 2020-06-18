import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';
import { PaginationBase } from 'src/app/shared/models/pagination-base.model';
import { catchError, map } from 'rxjs/operators';
import { PaginationModel } from 'src/app/shared/models/paginationModel';
import { AdminModel, CreateAdminModel } from '../Models/create-admin.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CreateAdminService extends BaseService {

  constructor(private http: HttpClient) {
    super()
  }

  getAllAdmin(pagination: PaginationBase) {
    return this.http
      .get<PaginationModel<AdminModel>>(
        `${this.baseEndPoint}/api/Account/admin/list?&Skip=${pagination.skip}&Take=${pagination.take}&SearchQuery=${pagination.searchQuery}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  deleteAdmin(id: string) {
    return this.http
      .delete(
        `${this.baseEndPoint}/api/Account/admin?userId=${id}`,
        this.httpOptions
      )
      .pipe(catchError(this.server4xxError));
  }

  createAdmin(model: CreateAdminModel) {
    return this.http.post(`${this.baseEndPoint}/api/Account/createadmin`, model, this.httpOptions)
      .pipe(catchError(this.server4xxError));
  }


}
