export class HelpCenterModel {
    id: number;
    title: string;
    description: string;
    topics: {[key: string]: string};
    topics2: Array<any> = [];
}

export class HelpCenterUpdateModel{
    id: number;
    topics: string;
}