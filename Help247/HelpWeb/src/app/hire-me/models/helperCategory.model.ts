import { PaginationBase } from 'src/app/shared/models/pagination-base.model';

export class HelperCategoryDropDownModel {
    Id: number;
    Name: string;
}

export class HelperPagination extends PaginationBase {
    helperCategoryId: number;

    constructor() {
        super();
        this.helperCategoryId = 0;
        this.take = 12;
    }

}