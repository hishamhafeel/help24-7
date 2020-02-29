import { Component, OnInit } from '@angular/core';
declare var $: any;

@Component({
  selector: 'app-notifications',
  templateUrl: './notifications.component.html',
  styleUrls: ['./notifications.component.scss']
})
export class NotificationsComponent implements OnInit {

  time = 150;

  constructor() { }

  ngOnInit() {
  }

  successMessage(message: string) {
    $.notify(
      {
        icon: 'notifications',
        message: message
      },
      {
        type: 'success',
        timer: this.time,
        placement: {
          from: 'bottom',
          align: 'right'
        },
        template:
          '<div data-notify="container" class="col-xl-4 col-lg-4 col-11 col-sm-4 col-md-4 alert alert-{0} alert-with-icon" role="alert">' +
          '<button mat-button  type="button" aria-hidden="true" class="close mat-button" data-notify="dismiss">  <i class="material-icons">close</i></button>' +
          '<i class="material-icons" data-notify="icon">notifications</i> ' +
          '<span data-notify="title">' +
          'Success' +
          '</span> ' +
          '<span data-notify="message">' +
          message +
          '</span>' +
          '</div>'
      }
    );
  }

  errorMessage(message: string) {
    $.notify(
      {
        icon: 'error_outline',
        message: message
      },
      {
        type: 'danger',
        timer: this.time,
        placement: {
          from: 'bottom',
          align: 'right'
        },
        template:
          '<div data-notify="container" class="col-xl-4 col-lg-4 col-11 col-sm-4 col-md-4 alert alert-{0} alert-with-icon" role="alert">' +
          '<button mat-button  type="button" aria-hidden="true" class="close mat-button" data-notify="dismiss">  <i class="material-icons">close</i></button>' +
          '<i class="material-icons" data-notify="icon">error_outline</i> ' +
          '<span data-notify="title">' +
          'Failed' +
          '</span> ' +
          '<span data-notify="message">' +
          message +
          '</span>' +
          '</div>'
      }
    );
  }

  warningMessage(message: string) {
    $.notify(
      {
        icon: 'error_outline',
        message: message
      },
      {
        type: 'warning',
        timer: this.time,
        placement: {
          from: 'top',
          align: 'right'
        },
        template:
          '<div data-notify="container" class="col-xl-4 col-lg-4 col-11 col-sm-4 col-md-4 alert alert-{0} alert-with-icon" role="alert">' +
          '<button mat-button  type="button" aria-hidden="true" class="close mat-button" data-notify="dismiss">  <i class="material-icons">close</i></button>' +
          '<i class="material-icons" data-notify="icon">error_outline</i> ' +
          '<span data-notify="title">' +
          'Warning' +
          '</span> ' +
          '<span data-notify="message">' +
          message +
          '</span>' +
          '</div>'
      }
    );
  }

}
