import { HelperModel } from 'src/app/helper/models/helper.model';

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
}