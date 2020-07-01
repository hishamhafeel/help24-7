export class HelperCategoryModel {
    id: number;
    name: string;
    longDescription: string;
    title: string;
    shortDescription: string;
    iconUrl: string;
    imageUrl: string;
    subServices: Array<SubServiceModel>;

    constructor() {
        this.subServices = new Array<SubServiceModel>();
    }
}

export class SubServiceModel {
    id: number;
    name: string;
    description: string
    helperCategoryId: number;
}