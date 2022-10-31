import { AccountService } from './_services/account.service';
import { HttpClient } from '@angular/common/http';
import { AppUser} from './models/app-user';
import { Component, OnInit } from '@angular/core';
import { Member } from './models/member';
import { MemberService } from './_services/member.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  title = 'dating-app';
  name = "NDK";
  users: Member[] = [];

  constructor(private httpClient: HttpClient,
    public accountService :AccountService){
  }

  ngOnInit(): void {
    this.accountService.reLogin()
  }

}
