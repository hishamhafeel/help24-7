export class TicketModel {
    id: number;
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
}