import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RouterModule } from '@angular/router';
import { LayoutModule } from './layout/layout.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { TokenInterceptor } from './auth/token-inteceptor';
import { Cloudinary } from 'cloudinary-core/cloudinary-core-shrinkwrap';
import { CloudinaryModule } from '@cloudinary/angular-5.x';
import { ToastrModule } from 'ngx-toastr';

const cloudConfig = {
  cloud_name: 'help247',
  upload_preset: 'ml_default',
  cname: 'help247.images.com',
  api_key: '176682769125134',
  api_secret: 'o1nvVw327R-fr-0-0ynZLKOOZgw',

};

const cloudinaryLib = {
  Cloudinary: Cloudinary
};

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    RouterModule,
    LayoutModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CloudinaryModule.forRoot(cloudinaryLib, cloudConfig),
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
    })
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: TokenInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
