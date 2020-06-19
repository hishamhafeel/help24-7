export class HelperCategoryModel {
    id: number;
    name: string;
    longDescription: string;
    title: string;
    shortDescription: string;
    iconUrl: string;
    imageUrl: string;
    subServices: SubServiceModel[];
}

export class SubServiceModel {
    id: number;
    name: string;
    description: string;

    helperCategoryId: number;
}