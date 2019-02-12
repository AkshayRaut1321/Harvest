import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'query-columns',
  templateUrl: './query-columns.component.html',
  styleUrls: ['./query-columns.component.css']
})
export class QueryColumnsComponent implements OnInit {

  constructor() { }

  ngOnInit() {
    console.log('Init query columns');
  }

}
