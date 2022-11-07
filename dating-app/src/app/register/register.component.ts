import { AccountService } from './../_services/account.service';
import { HttpClient } from '@angular/common/http';
import { RegisterUser } from './../models/app-user';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerUser: RegisterUser = new RegisterUser();

  constructor(private accountService: AccountService, httpClient: HttpClient) { }

  ngOnInit(): void {
  }

  register() {
    this.accountService.register(this.registerUser).subscribe();
  }

}
