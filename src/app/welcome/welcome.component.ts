import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { SalutiDataService } from '../services/data/saluti-data.service';

@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css']
})
export class WelcomeComponent implements OnInit {
  saluti = 'Benvenuti nel sito ';
  titolo2 = 'Seleziona gli articoli da acquistare:'

  utente = ''
  constructor(private route: ActivatedRoute, private salutiSrv: SalutiDataService) { }

  ngOnInit(): void {
    this.utente = this.route.snapshot.params['userid']
  }

  getSaluti() {
    console.log(this.salutiSrv.getSalutiSrv());
    this.salutiSrv.getSalutiSrv().subscribe(response => this.handleResponse(response));
  }

  handleResponse(response) {
    console.log(response);
  }
}
