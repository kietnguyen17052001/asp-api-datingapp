import { UserToken, AuthUser } from './../models/app-user';
import { HttpClient, HttpHeaders, HttpParamsOptions } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map, Observable, pipe } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl: string = "https://localhost:7031/api/Auth/";
  httpOption = {

  };
  headers = new HttpHeaders({
      "Content-Type": "application/json"
    })
  private currentUser = new BehaviorSubject<UserToken | null>(null);
  currentUser$ = this.currentUser.asObservable();
  constructor(private httpClient:HttpClient) {}
  login (authUser: AuthUser) : Observable<any>{
    return this.httpClient.post(`${this.baseUrl}login`, authUser, {
      responseType: 'text',
      headers: this.headers
    })
    .pipe(
      map((token) => {
        if (token) {
          const userToken: UserToken = {username: authUser.username, token: token}
          this.currentUser.next(userToken)
          localStorage.setItem('userToken', JSON.stringify(userToken))
        }
      })
    )
  }

  logout() {
    this.currentUser.next(null)
    localStorage.setItem('userToken', '')
  }

  reLogin() {
    const storageAccount = localStorage.getItem('userToken');
    if (storageAccount) {
      const logged = JSON.parse(storageAccount);
      this.currentUser.next(logged);
    }
  }

  register() {}
}
