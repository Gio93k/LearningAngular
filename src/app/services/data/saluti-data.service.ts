import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SalutiDataService {

  constructor() { }

  getSalutiSrv() {
    console.log("Saluti data service");
  }
}
