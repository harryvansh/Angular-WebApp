import { Component, Inject, OnInit, NgModule } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { FormBuilder, FormGroup, Validators } from '../../../../node_modules/@angular/forms';

const _httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
};
@Component({
    selector: "appointment-input-api",
    templateUrl: "./appointment.input.api.component.html"
})
export class ApiAppointmentInputComponent implements OnInit {
    public CurrentDate = new Date();
    private readonly _http: HttpClient;
    private readonly _baseUrl: string;
    private _employees: EmployeeModel[];
    public firstFormGroup: FormGroup;
    public secondFormGroup: FormGroup;
    public thirdFormGroup: FormGroup;
    private _formBuilder:FormBuilder;


    public _appointment: AppointmentForm = {
        employeeId: undefined,
        customerFirstName: undefined,
        customerMiddleName: undefined,
        customerLastName: undefined,
        appointmentTime: undefined
    };

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string, formBuilder: FormBuilder) {
        this._http = http;
        this._baseUrl = baseUrl;
        this._formBuilder = formBuilder;
    }

    ngOnInit() {
        this.firstFormGroup = this._formBuilder.group({
            firstCtrl: ['', Validators.required]
        });
        this.secondFormGroup = this._formBuilder.group({
            secondCtrl: ['', Validators.required]
        });
        this.thirdFormGroup = this._formBuilder.group({
            thirdCtrl: ['', Validators.required]
        });
        this.GetAllEmployees();
    }

    public GetAllEmployees() {
        let options: {
            headers: { 'Content-Type': 'application/json' }
        }
        this._http.get<EmployeeModel[]>(this._baseUrl + 'api/Employees/Employee', options).subscribe(result => this._employees = result);
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

