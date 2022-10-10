import { HttpClient } from '@angular/common/http';
import { AppUser } from './models/app-user';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{

  title = 'dating-app';
  name = "NDK";
  users: AppUser[] = [];

  constructor(private httpClient: HttpClient){

  }

  ngOnInit(): void {
    this.httpClient.get<AppUser[]>("https://localhost:7031/api/Auth/get")
    .subscribe(res => this.users = res,
      error => console.log(error))  
  }
  
}
