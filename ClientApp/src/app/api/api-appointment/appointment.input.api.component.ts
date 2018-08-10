import { Component, Inject, OnInit, NgModule } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

const _httpOptions = {
    headers : new HttpHeaders({
        'Content-Type' : 'application/json'
    })
};
@Component({
    selector: "appointment-input-api",
    templateUrl: "./appointment.input.api.component.html"
})
export class ApiAppointmentInputComponent implements OnInit {
    private readonly _http: HttpClient;
    private readonly _baseUrl: string;
    private _employees:EmployeeModel[];
    public _appointment:AppointmentForm = {
        employeeId: 0,
        customerFirstName: '',
        customerMiddleName: '',
        customerLastName: '',
        appointmentTime: new Date('')
    };

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl:string) {
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
        this._http.get<EmployeeModel[]>(this._baseUrl + 'api/Employees/Employee', options).subscribe(result=> this._employees = result);
    }

    public saveAppointment() {
        console.log("Header: " + _httpOptions.headers);
        console.log("Creating new appointment.. " + JSON.stringify(this._appointment));
        this._http.post<AppointmentForm>(this._baseUrl + 'api/Appointments/Appointment', JSON.stringify(this._appointment), _httpOptions).subscribe(result => result = this._appointment);
    }

}

interface AppointmentForm {
    employeeId: number,
    customerFirstName: string,
    customerMiddleName: string,
    customerLastName: string,
    appointmentTime: Date
}

interface EmployeeModel {
    employeeId: string,
    firstName: string,
    lastName: string,
    displayName: string,
    knownAs: string
}

