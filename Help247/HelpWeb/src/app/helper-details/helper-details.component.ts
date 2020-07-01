import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HelperDetailsService } from './services/helper-details.service';
import { HelperModel, TicketCountModel } from '../helper/models/helper.model';
import { HelperService } from '../shared/services/helper.service';
import { OwlOptions } from 'ngx-owl-carousel-o';

@Component({
  selector: 'app-helper-details',
  templateUrl: './helper-details.component.html',
  styleUrls: ['./helper-details.component.scss']
})
export class HelperDetailsComponent implements OnInit {
  id: number;
  helperModel = new HelperModel();
  ticketCountModel = new TicketCountModel();
  imageList: Array<string> = [];

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

  constructor(
    private route: ActivatedRoute,
    private helperService: HelperService,
    private helperDetailsService: HelperDetailsService) {

  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = +params['id'];
    });
    this.getHelperDetails(this.id);
    this.getJobCount(this.id);
    this.getImages(this.id);
  }

  getHelperDetails(id: number) {
    this.helperDetailsService.getHelperDetailsById(id).subscribe(
      result => {
        this.helperModel = result;
        console.log(result);
      },
      error => {
        console.log('error', error);
      }
    );
  }

  getJobCount(id: number) {
    this.helperDetailsService.getJobCounts(id).subscribe(
      result => {
        this.ticketCountModel = result;
      },
      error => {
        console.log('error', error);
      }
    );
  }

  getImages(id){
    this.helperService.getImages(id).subscribe(
      result => {
        console.log('Images', result);
        this.imageList = [];
        let self = this;
        result.forEach(element => {
          self.imageList.push(element.imageUrl);
        });
      },
      error => {
        console.log(error);
      }
    );
  }
}
