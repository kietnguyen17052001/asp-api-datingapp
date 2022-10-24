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
    headers: new HttpHeaders({
      "Content-Type": "application/json"
    })
  };

  private currentUser = new BehaviorSubject<UserToken | null>(null);
  currentUser$ = this.currentUser.asObservable();
  constructor(private httpClient:HttpClient) {}
  login (authUser: AuthUser) : Observable<any>{
    return this.httpClient.post<any>(`${this.baseUrl}login`, authUser, this.httpOption)
    .pipe(
      map((response: UserToken) => {
        this.currentUser.next(response)
        localStorage.setItem('userToken', JSON.stringify(response))
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
