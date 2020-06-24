import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { HelperCategoryModel } from 'src/app/helper/models/helper-category.model';
import { HelperService } from 'src/app/shared/services/helper.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-sub-service',
  templateUrl: './sub-service.component.html',
  styleUrls: ['./sub-service.component.scss']
})
export class SubServiceComponent implements OnInit {

  helperCategoryId: number;
  helperCategory = new HelperCategoryModel();
  constructor(
    private route: ActivatedRoute,
    private helperCategoryService: HelperService,
    private toastr: ToastrService) {

  }

  ngOnInit(): void {
    this.route.paramMap.subscribe(params => {
      this.helperCategoryId = +params.get('id');
    });

    this.getHelperCategory(this.helperCategoryId);
  }

  getHelperCategory(id: number) {
    this.helperCategoryService.getHelperCategoryById(id).subscribe(result => {
      this.helperCategory = result;
    },
      error => {
        this.toastr.error('Error', error.message)
      }
    )
  }
}
