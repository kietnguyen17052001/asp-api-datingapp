import { AuthUser } from './../models/app-user';
import { AccountService } from './../_services/account.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {
  authUser: AuthUser = {username: 'kiet', password: '123qwe!@#'};

  constructor(public accountService: AccountService) { }

  ngOnInit(): void {
  }

  login() {
    this.accountService.login(this.authUser)
    .subscribe(
      response => console.log(response),
      error => console.log(error)
    );
  }

}
