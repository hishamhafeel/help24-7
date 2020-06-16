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
    profilePic: string;
    aboutMe: string;
    myService: string;
    helperCategoryId: number;
    helperCategory: HelperCategoryModel;
    userId: string;
}