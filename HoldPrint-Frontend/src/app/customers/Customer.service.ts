import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Customer } from '../models/Customer';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  baseUrl = `${environment.MeanUrl}/api/customer`;

  constructor(private http: HttpClient) { }

  getAll(): Observable<Customer[]>{
    return this.http.get<Customer[]>(`${this.baseUrl}`);
  }

  getById(id: number): Observable<Customer>{
    return this.http.get<Customer>(`${this.baseUrl}/${id}`)
  }

  post(customer: Customer){
    return this.http.post(`${this.baseUrl}`, customer)
  }

  put(customer: Customer){
    return this.http.put(`${this.baseUrl}/${customer.id}`, customer)
  }

  delete(id: number){
    return this.http.delete(`${this.baseUrl}/${id}`)
  }

}
