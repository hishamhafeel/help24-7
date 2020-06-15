import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HireMeService } from '../services/hire-me.service';
import { HelperModel } from 'src/app/helper/models/helper.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { TicketModel } from '../models/ticket.model';

@Component({
  selector: 'app-open-ticket',
  templateUrl: './open-ticket.component.html',
  styleUrls: ['./open-ticket.component.scss']
})
export class OpenTicketComponent implements OnInit {

  fromDate = new Date();
  toDate = new Date();
  openTicketForm: FormGroup;
  ticketModel: TicketModel;

  id: number;
  helperModel: HelperModel;

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private hireMeService: HireMeService,
    private fb: FormBuilder
  ) {
    
  }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.id = +params['id']; // (+) converts string 'id' to a number
      this.initOpenTicketForm()
      this.getHelper(this.id);
    });
  }

  initOpenTicketForm(){
    this.openTicketForm = this.fb.group({
      state: ['Hambantota', [Validators.required]],
      city: ['Ambalantota', [Validators.required]],
      address: ['311/1/A Malay Colony, Ambalantota', [Validators.required]],
      contactNo1: ['+94552226589', [Validators.required]],
      contactNo2: ['+94772256634', [Validators.required]],
      otherRequirements: ['All other requirements', [Validators.required]],
      ticketStatusId: [1, [Validators.required]],
      customerId: [3, [Validators.required]]
    });
  }

  getHelper(id) {
    this.hireMeService.getHelperById(id).subscribe(
      result => {
        this.helperModel = result;
      },
      error => {
        console.log('error', error);
      }
    );
  }

  onSubmit(){
    if (this.openTicketForm.invalid) {
      return;
    }
    this.ticketModel = this.openTicketForm.value;
    this.ticketModel.helpDateFrom = this.fromDate;
    this.ticketModel.helpDateTo = this.toDate;
    this.ticketModel.helperId = this.id;

    this.hireMeService.assignTicket(this.ticketModel).subscribe(
      result => {
        console.log('result', result);
        this.router.navigate(['customer']);
      },
      error => {
        console.log('error', error);
      }
    );
  }

}
