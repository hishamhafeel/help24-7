export class HelperModel {
    id: number;
    name: string;
    phoneNo: string;
    email: string;
    country: string;
    province: string;
    district: string;
    city: string;
    helperCategory: HelperCategoryModel;
    helperCategoryId: number;
}


export class HelperCategoryModel {
    id: number;
    categoryName: string;
    categoryDescription: string;
}