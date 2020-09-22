import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-error',
  templateUrl: './error.component.html',
  styleUrls: ['./error.component.css']
})
export class ErrorComponent implements OnInit {

  errorMSG = 'Spiacenti Pagina non trovata'
  constructor() { }

  ngOnInit(): void {
  }

}
