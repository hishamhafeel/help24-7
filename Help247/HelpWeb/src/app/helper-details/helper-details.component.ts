import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HelperDetailsService } from './services/helper-details.service';
import { HelperModel, TicketCountModel } from '../helper/models/helper.model';

@Component({
  selector: 'app-helper-details',
  templateUrl: './helper-details.component.html',
  styleUrls: ['./helper-details.component.scss']
})
export class HelperDetailsComponent implements OnInit {
  id: number;
  helperModel = new HelperModel();
  ticketCountModel = new TicketCountModel();

  constructor(
    private route: ActivatedRoute,
    private helperDetailsService: HelperDetailsService) {

  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = +params['id'];
    });
    this.getHelperDetails(this.id);
    this.getJobCount(this.id);
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
}
