import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {take} from 'rxjs/operators';
import {User} from '../models/User/User';
import {Response} from '../models/User/Response';

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
    return this.http.post<any>(this.API , user);
  }
}
