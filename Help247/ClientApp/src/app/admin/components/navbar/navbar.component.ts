import { Component, OnInit } from '@angular/core';
import { AuthService } from '../../auth/services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  constructor(
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit() {
  }

  getTitle() {
    // var titlee = this.location.prepareExternalUrl(this.location.path());
    // if(titlee.charAt(0) === '#'){
    //     titlee = titlee.slice( 1 );
    // }

    // for(var item = 0; item < this.listTitles.length; item++){
    //     if(this.listTitles[item].path === titlee){
    //         return this.listTitles[item].title;
    //     }
    // }
    return 'Dashboard';
  }

  logout() {
    this.authService.logout();
  }
}
