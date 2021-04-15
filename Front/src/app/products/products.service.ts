import {EventEmitter, Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {Product} from '../models/Product/Product';
import {take} from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  private readonly API = 'https://localhost:5001/api/Product';


  constructor(private http: HttpClient) { }

  // tslint:disable-next-line:typedef
  list(){
    return this.http.get<Product[]>(this.API);
  }
  // tslint:disable-next-line:typedef
  create(product: Product){
     return this.http.post(this.API , product).pipe(take(1));
  }
  // tslint:disable-next-line:typedef
  update(product: any){
     return this.http.put(this.API + '/' + product.id, product).pipe(take(1));
  }
  // tslint:disable-next-line:typedef
  getOne(product: number){
    return this.http.get<Product>(this.API + '/' + product).pipe(take(1));
  }
  // tslint:disable-next-line:typedef
  delete(product: number){
    return this.http.delete(this.API + '/' + product);
  }
}
