import { Injectable } from '@angular/core';
import { NotificationsComponent } from '../notifications/notifications.component';

@Injectable({
  providedIn: 'root'
})
export class NotificationService {

  notificationComponent = new NotificationsComponent();

  constructor() { }

  errorMessage() {
    this.notificationComponent.showNotification();
  }
}
