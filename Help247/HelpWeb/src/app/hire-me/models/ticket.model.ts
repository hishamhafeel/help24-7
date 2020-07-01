import { HelperModel } from 'src/app/helper/models/helper.model';
import { CustomerModel } from 'src/app/customer/models/customer.model';

export class TicketModel {
    id: number;
    title: string;
    helpTime: string;
    country: string;
    helpDateFrom: Date;
    helpDateTo: Date;
    state: string;
    city: string;
    address: string;
    contactNo1: string;
    contactNo2: string;
    otherRequirements: string;
    ticketStatusId: number;
    helperId: number;
    customerId: number;
    helper: HelperModel;
    customer: CustomerModel;
    createdOn: Date;
    hasFeedback: boolean;

    constructor() {
        this.helper = new HelperModel();
        this.customer = new CustomerModel();
    }
}

export class FeedbackModel {
    id: number;
    description: string;
    rating: number;
    helperId: number;
    customerId: number;
    ticketId: number;
    createdOn: Date;
    helper: HelperModel;
}