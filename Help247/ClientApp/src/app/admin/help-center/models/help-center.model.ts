export class HelpCenterModel {
    id: number;
    title: string;
    description: string;
    topics: {[key: string]: string};
}

export class HelpCenterUpdateModel{
    id: number;
    topics: string;
}