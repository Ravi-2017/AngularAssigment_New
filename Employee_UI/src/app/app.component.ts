import { Component, OnInit } from '@angular/core';
import { EmployeeserviceService } from './employeeservice.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'] 
})
export class AppComponent implements OnInit {
   
  title = 'employee';
  employee:any;
  employees: any[] = [];
  constructor(private _emploueeService: EmployeeserviceService) {


  }
  newEmployee()
  {
    this.employee={ empID:0,empName:"",empAddress:""};
  }
  ngOnInit() {
   this. newEmployee();
    this._emploueeService.getEmployee().subscribe((res) => {
      console.log(res);
      this.employees = res;
    });
  }
  getEmployeeDataById()
  {
    console.log(this.employee.empID);
    this._emploueeService.getEmployeebyId(this.employee.empID).subscribe((res) => {
      if(res)
      this.employee = res;
    else
    window.alert("Employee Id Not found!!");
    });
  }
  save()
  {
    const emp  ={EmpID:this.employee.empID,EmpName:this.employee.empName,EmpAddress:this.employee.empAddress};
    console.log(emp);
    this._emploueeService.saveEmployeeData(emp).subscribe((res) => {
      this.employee.empID=res;
      window.alert("Employee Data update!!");
    });    
  }
}
