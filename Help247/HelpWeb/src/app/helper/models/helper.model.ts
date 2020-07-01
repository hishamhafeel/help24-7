import { HelperCategoryModel } from './helper-category.model';

export class HelperModel {
    id: number;
    firstName: string;
    lastName: string;
    phoneNo: string;
    mobileNo: string;
    email: string;
    country: string;
    state: string;
    city: string;
    postalCode: string;
    addressLine: string;
    experience: number;
    profilePicUrl: string;
    aboutMe: string;
    myService: string;
    helperCategoryId: number;
    helperCategory: HelperCategoryModel;
    userId: string;
    createdOn: Date;
    image: ImageModel;

    constructor() {
        this.image = new ImageModel();
        this.helperCategory = new HelperCategoryModel();
    }
}

export class TicketCountModel {
    helperId: number;
    completedJobs: number;
    acceptedJobs: number;
    pendingJobs: number;
    rejectedJobs: number;
}

export class ImageModel {
    id: number;
    imageUrl: string;
    email: string;
    imageType: string;
    subServiceId: number;
    helperId: number;
    customerId: number;
}