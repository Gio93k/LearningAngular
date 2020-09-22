import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit {
  saluti = 'Benvenuti nel sito ';
  titolo2 = 'Seleziona gli articoli da acquistare:'
  constructor() { }

  ngOnInit(): void {
  }

}
