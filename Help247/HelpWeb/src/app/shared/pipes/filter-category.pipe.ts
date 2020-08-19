import { PipeTransform, Pipe } from '@angular/core';
import { HelperCategoryModel } from 'src/app/helper/models/helper-category.model';

@Pipe({
    name: 'filterCategory',
    pure: false
})
export class FilterCategoryPipe implements PipeTransform {
    transform(values: HelperCategoryModel[], checkBoxArr?: any[]): HelperCategoryModel[] {
        return values = values.filter(a => {
            return checkBoxArr.length ? checkBoxArr.indexOf(a.name) != -1 : values;
        })

    }

}