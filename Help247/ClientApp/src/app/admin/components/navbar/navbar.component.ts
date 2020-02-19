import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  getTitle(){
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
}
