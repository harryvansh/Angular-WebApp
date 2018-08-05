import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
    selector: "appointment-api",
    templateUrl: "./appointment.api.component.html"
})
export class ApiAppointmentComponent implements OnInit {
    private readonly _http: HttpClient;
    private readonly _baseUrl: string;
    private appointments: AppointmentModel[];
    

    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl:string) {
        this._http = http;
        this._baseUrl = baseUrl;
    }

    ngOnInit() {
        this.getAllAppointments();
    }
    private getAllAppointments() {
        let options: {
            headers: { 'Content-Type': 'application/json' }
        }

        this._http.get<AppointmentModel[]>(this._baseUrl + 'api/Appointments/Appointment', options).subscribe(result => this.appointments = result);

    }
}

interface AppointmentModel {
    appointmentId: number,
    customerId: number,
    employeeId: number,
    appointmentTime: Date
}

