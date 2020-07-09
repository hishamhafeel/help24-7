import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HelperCategoryRoutingModule } from './helper-category-routing.module';
import { HelperCategoryComponent } from './helper-category/helper-category.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { HelperCategoryEditComponent } from './helper-category/helper-category-edit/helper-category-edit.component';
import { FileUploadModule } from "ng2-file-upload";



@NgModule({
  declarations: [HelperCategoryComponent, HelperCategoryEditComponent],
  imports: [
    CommonModule,
    HelperCategoryRoutingModule,
    SharedModule,
    FileUploadModule
  ],
  entryComponents: [HelperCategoryEditComponent]
})
export class HelperCategoryModule { }
