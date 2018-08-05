import { Component, Inject, OnInit } from '@angular/core';
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
    public _appointment:AppointmentForm = {
        employeeId: 1,
        customerFirstName: 'Dylan',
        customerMiddleName: 'Anthony',
        customerLastName: 'Brigham',
        appointmentTime: new Date('2018-09-10 15:30:00')
    };

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl:string) {
        this._http = http;
        this._baseUrl = baseUrl;
    }

    ngOnInit() {
        
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

