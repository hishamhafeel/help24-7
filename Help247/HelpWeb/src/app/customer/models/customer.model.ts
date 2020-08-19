import { ImageModel } from 'src/app/helper/models/helper.model';

export class CustomerModel {
    id: number;
    name: string;
    phoneNo: string;
    email: string;
    country: string;
    state: string;
    city: string;
    addressLine: string;
    postalCode: string;
    userId: string;
    image: ImageModel;
    profilePicUrl: string;
    editedOn: Date;

    constructor() {
        this.image = new ImageModel();
    }
}