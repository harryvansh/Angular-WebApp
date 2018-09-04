import { Component, Inject, OnInit, Injectable } from '@angular/core';
import { AppointmentService } from '../api-services/services.api.component';

@Component({
    selector: 'api-employees',
    templateUrl: './employee.api.component.html'
})

export class ApiEmployeeComponent implements OnInit{

    public employees:Employee[];

    constructor(private appointmentService: AppointmentService){}

    ngOnInit() {
        this.GetAllEmployees();
    }

    public GetAllEmployees(){
       this.appointmentService.GetAllEmployees().subscribe(result=> this.employees = result);
    }

}