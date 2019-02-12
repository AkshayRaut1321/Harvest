import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'newquery',
  templateUrl: './newquery.component.html',
  styleUrls: ['./newquery.component.css']
})
export class NewqueryComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    console.log('Init new query');
  }

}
