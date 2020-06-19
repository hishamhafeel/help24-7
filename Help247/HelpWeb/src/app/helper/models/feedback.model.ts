import { HelperModel } from './helper.model';
import { TicketModel } from 'src/app/hire-me/models/ticket.model';
import { CustomerModel } from 'src/app/customer/models/customer.model';

export class FeedbackModel {
    id: number;
    description: string;
    rating: number;
    createdOn: Date;
    helperId: number;
    helper: HelperModel;
    customerId: number;
    customer: CustomerModel;
    ticketId: number
    ticket: TicketModel;
}