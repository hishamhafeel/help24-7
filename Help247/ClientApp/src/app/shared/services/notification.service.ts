import { Injectable } from '@angular/core';
import { NotificationsComponent } from '../notifications/notifications.component';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  notificationComponent = new NotificationsComponent();

  constructor() { }

  successMessage(message: string) {
    this.notificationComponent.successMessage(message);
  }

  errorMessage(message: string) {
    this.notificationComponent.errorMessage(message);
  }

  warningMessage(message: string) {
    this.notificationComponent.warningMessage(message);
  }
}
