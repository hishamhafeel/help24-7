export class HelperCategoryModel {
    id: number;
    name: string;
    longDescription: string;
    title: string;
    shortDescription: string;
    iconUrl: string;
    imageUrl: string;
    servicesProvided: { [key: string]: string };
}

export class SubServiceModel {
    title: string;
    description: string;
}