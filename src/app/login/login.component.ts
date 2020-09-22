import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  userid = '';
  password = '';
  autenticato = true;
  consentito = false;

  errorMsg = 'UserId o psw errate';
  infoMsg = ' Credenziali corrette';
  constructor() { }

  ngOnInit(): void {
  }

  gestAut() {
    //console.log(this.userid);
    if (this.userid === 'Nicola' && this.password === '123') {
      this.autenticato = true;
      this.consentito = true;
      console.log(this.autenticato);
    } else {
      this.autenticato = false;
      this.consentito = false;
      console.log(this.autenticato);
    }
  }
}
