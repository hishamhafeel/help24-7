import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HelperRoutingModule } from './helper-routing.module';
import { HelperComponent } from './helper.component';
import { ModalModule } from 'ngx-bootstrap/modal';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgxStarRatingModule } from 'ngx-star-rating';
import { FileUploadModule } from 'ng2-file-upload';
import { ValidatorService } from '../auth/services/validator.service';



@NgModule({
  declarations: [HelperComponent],
  imports: [
    CommonModule,
    HelperRoutingModule,
    ModalModule.forRoot(),
    FormsModule,
    ReactiveFormsModule,
    NgxStarRatingModule,
    FileUploadModule
  ],
  providers: [ValidatorService]
})
export class HelperModule { }
