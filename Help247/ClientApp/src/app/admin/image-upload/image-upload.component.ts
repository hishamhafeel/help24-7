import { Component, OnInit, NgZone, Input } from '@angular/core';
import { FileUploader, FileUploaderOptions, ParsedResponseHeaders } from 'ng2-file-upload';
import { Cloudinary } from '@cloudinary/angular-5.x';
import { HttpClient } from '@angular/common/http';
import { NotificationService } from 'src/app/shared/services/notification.service';



@Component({
  selector: 'app-image-upload',
  templateUrl: './image-upload.component.html',
  styleUrls: ['./image-upload.component.scss']
})
export class ImageUploadComponent implements OnInit {
  @Input()
  responses: Array<any>;

  isUploaded: boolean = false;
  private uploader: FileUploader;
  private url: string;
  public_id: string;

  constructor(
    private cloudinary: Cloudinary,
    private notificationService: NotificationService
  ) {
    this.responses = [];
  }

  ngOnInit(): void {
    // Create the file uploader, wire it to upload to your account
    const uploaderOptions: FileUploaderOptions = {
      url: `https://api.cloudinary.com/v1_1/${this.cloudinary.config().cloud_name}/upload`,
      autoUpload: true,
      isHTML5: true,
      removeAfterUpload: true,
      headers: [
        {
          name: 'X-Requested-With',
          value: 'XMLHttpRequest'
        }
      ]
    };
    this.uploader = new FileUploader(uploaderOptions);

    this.uploader.onBuildItemForm = (fileItem: any, form: FormData): any => {

      this.generateFileName();

      // Add Cloudinary's unsigned upload preset to the upload form
      form.append('upload_preset', this.cloudinary.config().upload_preset);
      form.append('folder', 'angular_sample');
      form.append('file', fileItem);
      form.append('public_id', this.public_id);

      // Use default "withCredentials" value for CORS requests
      fileItem.withCredentials = false;
      return { fileItem, form };
    };

    this.uploader.onErrorItem = (item: any, response: string, status: number, headers: ParsedResponseHeaders) =>
      this.notificationService.errorMessage("Image upload failed");

    // Update model on completion of uploading a file
    this.uploader.onCompleteItem = (item: any, response: string, status: number, headers: ParsedResponseHeaders) => {
      this.url = JSON.parse(response).url;
      this.isUploaded = true;
    }


  }

  generateFileName() {
    this.public_id = `img_${Date.now()}`;
  }

}