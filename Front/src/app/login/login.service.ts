import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {take} from 'rxjs/operators';
import {User} from './User';
import {Response} from './Response';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  private readonly API = 'https://localhost:5001/api/Authentication';

  constructor(
    private http: HttpClient,
    ) { }

  // tslint:disable-next-line:typedef
  post(user: User){
    console.log(user);
    return this.http.post<any>(this.API , user);
  }
}
