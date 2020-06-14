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
    addressLine: string;
    postalCode: string;
    profilePicUrl: string;
    aboutMe: string;
    myService: string;
    helperCategory: HelperCategoryModel;
    // helperCategoryId: number;
}


export class HelperCategoryModel {
    id: number;
    name: string;
    title: string;
    shortDescription: string;
    longDescription: string;
    iconUrl: string;
    imageUrl: string;
}