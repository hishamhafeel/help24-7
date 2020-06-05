import { Component, OnInit } from '@angular/core';
import { OwlOptions } from 'ngx-owl-carousel-o';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit {
  noOfHelpers: number;
  noOfJobs: number;
  noOfClients: number;
  noOfOnGoingJobs: number;
  customOptions: OwlOptions = {
    loop: true,
    margin: 30,
    nav: true,
    dots: false,
    items: 4,
    navText: ["<img src='../../assets/images/slider-prv.png'>", "<img src='../../assets/images/slider-nxt.png'>"],
    responsive: {
      0: {
        items: 1
      },
      600: {
        items: 1
      },
      768: {
        items: 3
      },
      1024: {
        items: 4
      }
    }
  }

  bannerOptions: OwlOptions = {
    loop: true,
    margin: 0,
    nav: true,
    dots: false,
    items: 1,
    navText: ["<img src='../../assets/images/hmbanner-prev.png'>", "<img src='../../assets/images/hmbanner-nxt.png'>"],
    responsive: {
      0: {
        items: 1,
      },
      600: {
        items: 1,
      },
      1000: {
        items: 1,
      }
    }
  }

  constructor() { }

  ngOnInit(): void {
  }

}
