import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ImageUploadRoutingModule } from './image-upload-routing.module';
import { ImageUploadComponent } from './image-upload.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { FileUploadModule } from "ng2-file-upload";


@NgModule({
  declarations: [ImageUploadComponent],
  imports: [
    CommonModule,
    ImageUploadRoutingModule,
    SharedModule,
    FileUploadModule
  ]
})
export class ImageUploadModule { }
