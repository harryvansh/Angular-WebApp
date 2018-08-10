import { Component, Inject} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const _httpOptions = {
    headers : new HttpHeaders({
        'Content-Type' : 'application/json'
    })
};

@Component({
    selector: 'employee-api-input',
    templateUrl: './employee.input.api.component.html'
})
export class ApiEmployeeInputComponent {
    private readonly _http: HttpClient;
    private readonly _baseUrl: string;
    public _employee:EmployeeForm = {
            employeeId: 0,
            firstName: '',
            lastName: '',
            displayName: '',
            knownAs: ''
    };

    constructor( http: HttpClient, @Inject('BASE_URL') baseUrl: string ){
        this._baseUrl = baseUrl;
        this._http = http;
    }
    
    public saveEmployee()
    {
        console.log("Header: " + _httpOptions.headers);
        console.log("Creating new employee.. " + JSON.stringify(this._employee));
        this._http.post<EmployeeForm>(this._baseUrl + 'api/Employees/Employee', JSON.stringify(this._employee), _httpOptions).subscribe(employee=>this._employee);
    }
}

interface EmployeeForm {
    employeeId: number,
    firstName: string,
    lastName: string,
    displayName: string,
    knownAs: string
}