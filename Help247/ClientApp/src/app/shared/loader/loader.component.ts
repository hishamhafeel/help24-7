import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-loader',
  templateUrl: './loader.component.html',
  styleUrls: ['./loader.component.scss']
})
export class LoaderComponent implements OnInit {

  imagePath = "../../../assets/loader/main-loader.svg";

  constructor() { }

  ngOnInit() {
  }

}
