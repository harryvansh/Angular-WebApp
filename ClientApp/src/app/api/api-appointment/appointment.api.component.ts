import { Component, Inject, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppointmentService } from '../api-services/services.api.component';

@Component({
    selector: "appointment-api",
    templateUrl: "./appointment.api.component.html"
})
export class ApiAppointmentComponent implements OnInit {
    private appointments: AppointmentModel[];

    constructor(private appointmentService: AppointmentService) {};

    ngOnInit() {
        this.getAllAppointments();
    }
    private getAllAppointments() {
        this.appointmentService.getAllAppointments().subscribe(result => this.appointments = result);
    }
}