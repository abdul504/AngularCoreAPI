import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})

export class EmployeeService {
  constructor(private _http: HttpClient) {}

    header = new HttpHeaders({
    'X-ApiKey': '4048FF1B9B1B4331A5EAFB8A14EEFAED'   
  });



  addEmployee(data: any): Observable<any> {
    return this._http.post('https://localhost:7071/api/Employees', data,{headers:this.header});
  }

  updateEmployee(id: number, data: any): Observable<any> {
    return this._http.put(`https://localhost:7071/api/Employees/${id}`, data,{headers:this.header});
  }

  getEmployeeList(): Observable<any> {
    return this._http.get('https://localhost:7071/api/Employees',{headers:this.header});
  }

  deleteEmployee(id: number): Observable<any> {
    return this._http.delete(`https://localhost:7071/api/Employees/${id}`,{headers:this.header});
  }
}
