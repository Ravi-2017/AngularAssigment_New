import { Injectable } from '@angular/core';
import { HttpClient, HttpEvent, HttpRequest  } from '@angular/common/http';
import { environment } from '../environment';
@Injectable({
  providedIn: 'root'
})
export class EmployeeserviceService {
  baseUrl = environment.API + 'api/Employee/';
  constructor(private http: HttpClient) { }
  getEmployee() {
    return this.http.get<any>(this.baseUrl + `GetEmployeeData`);
  }
  getEmployeebyId(id:any) {
    return this.http.get<any>(this.baseUrl + `GetEmployeeDatabyId/${id}`);
  }
  saveEmployeeData(employee: any) {
    return this.http.post(this.baseUrl + 'SaveEmployeeData', employee);
   }
}
