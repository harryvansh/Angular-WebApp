import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: 'api-employees',
    templateUrl: './employee.api.component.html'
})

export class ApiEmployeeComponent implements OnInit{

    private readonly _http: HttpClient;
    private readonly _baseUrl: string;
    private employees:EmployeeModel[];

    constructor(http:HttpClient, @Inject('BASE_URL') baseUrl:string) {
        this._http = http;
        this._baseUrl = baseUrl;
    }

    ngOnInit() {
        this.GetAllEmployees();
    }

    public GetAllEmployees(){
        let options: {
            headers: {'Content-Type': 'application/json'}
        }
        this._http.get<EmployeeModel[]>(this._baseUrl + 'api/Employees/Employee', options).subscribe(result=> this.employees = result);
    }

}

interface EmployeeModel {
    employeeId: string,
    firstName: string,
    lastName: string,
    displayName: string,
    knownAs: string
}