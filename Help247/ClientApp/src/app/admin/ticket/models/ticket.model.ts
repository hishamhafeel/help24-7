import { PaginationBase } from 'src/app/shared/models/pagination-base.model';

export class TicketModel {
    id: number;
    title: string;

    helpDateFrom: Date;
    helpDateTo: Date;
    helpTime: string;
    country: string;

    state: string;
    city: string;
    address: string;
    contactNo1: string;
    contactNo2: string;
    otherRequirements: string;
}

export class TicketPaginationModel implements PaginationBase {
    skip: number;
    take: number;
    searchQuery: string;
    orderBy: string;
    ticketStatusId: number;
    helperId: number;
    customerId: number;
    helperName: string;
    customerName: string;

    constructor() {
        this.skip = 0;
        this.take = 10;
        this.searchQuery = '';
        this.orderBy = '';
        this.ticketStatusId = 0;
        this.helperId = 0;
        this.customerId = 0;
        this.helperName = '';
        this.customerName = ''
    }
}