import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { HireMeService } from '../services/hire-me.service';
import { HelperModel } from 'src/app/helper/models/helper.model';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { TicketModel } from '../models/ticket.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-open-ticket',
  templateUrl: './open-ticket.component.html',
  styleUrls: ['./open-ticket.component.scss'],
})
export class OpenTicketComponent implements OnInit {
  fromDate = new Date();
  toDate = new Date();
  openTicketForm: FormGroup;
  ticketModel: TicketModel;

  id: number;
  customerId: number;
  helperModel: HelperModel = new HelperModel();

  constructor(
    private route: ActivatedRoute,
    private router: Router,
    private hireMeService: HireMeService,
    private fb: FormBuilder,
    private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.route.params.subscribe((params) => {
      this.id = +params['id']; // (+) converts string 'id' to a number
      this.initOpenTicketForm();
      this.getHelper(this.id);
    });
    this.customerId = +localStorage.getItem('LoggedId');
  }

  initOpenTicketForm() {
    this.openTicketForm = this.fb.group({
      title: ['', [Validators.required]],
      country: ['', [Validators.required]],
      state: ['', [Validators.required]],
      city: ['', [Validators.required]],
      address: ['', [Validators.required]],
      contactNo1: ['', [Validators.required]],
      contactNo2: [''],
      otherRequirements: [''],
      helpTime: [new Date()],
      ticketStatusId: [1, [Validators.required]],
    });
  }

  get ticketForm() {
    return this.openTicketForm.controls;
  }
  getHelper(id) {
    this.hireMeService.getHelperById(id).subscribe(
      (result) => {
        this.helperModel = result;
      },
      (error) => {
        console.log('error', error);
      }
    );
  }

  async onSubmit() {
    if (this.openTicketForm.invalid) {
      this.toastr.error("Invalid ticket ", "Error")
      return;
    }
    this.ticketModel = this.openTicketForm.value;
    this.ticketModel.helpDateFrom = this.fromDate;
    this.ticketModel.helpDateTo = this.toDate;
    this.ticketModel.helperId = this.id;
    this.ticketModel.customerId = this.customerId;

    this.ticketModel.helpTime = await this.formatAMPM(
      this.openTicketForm.value.helpTime
    );

    this.hireMeService.assignTicket(this.ticketModel).subscribe(
      (result) => {
        this.toastr.success("Ticket successfully created", "Success")
        this.router.navigate(['customer']);
      },
      (error) => {
        this.toastr.error(error.Message, "Error")

      }
    );
  }

  async formatAMPM(date) {
    var hours = date.getHours();
    var minutes = date.getMinutes();
    var ampm = hours >= 12 ? 'pm' : 'am';
    hours = hours % 12;
    hours = hours ? hours : 12; // the hour '0' should be '12'
    minutes = minutes < 10 ? '0' + minutes : minutes;
    var strTime = hours + ':' + minutes + ' ' + ampm;
    return strTime;
  }
}
