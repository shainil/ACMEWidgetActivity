import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders } from '@angular/common/http';
import {Observable, throwError} from 'rxjs';
import { Employee } from 'src/app/shared/employee';

@Injectable({
  providedIn: 'root'
})
export class SharedService {

  readonly apiUrl = "https://localhost:44343/api";

  constructor(private http:HttpClient) { }

 // Http Options
 httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
}  

// HttpClient API get() method => Fetch employees list
  getEmployees(): Observable<Employee> {
    return this.http.get<Employee>(this.apiUrl + '/Employee')    
  }

  // HttpClient API post() method => Create Employee
  addEmployee(employee:any): Observable<Employee> {
    return this.http.post<Employee>(this.apiUrl + '/Employee', JSON.stringify(employee), this.httpOptions)
  }

}
