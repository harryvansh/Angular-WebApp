import { Component, Inject, OnInit, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AppointmentService } from '../api-services/services.api.component';

@Component({
    selector: 'api-employees',
    templateUrl: './employee.api.component.html'
})

export class ApiEmployeeComponent implements OnInit{

    public employees:EmployeeModel[];

    constructor(private appointmentService: AppointmentService){}

    ngOnInit() {
        this.GetAllEmployees();
    }

    public GetAllEmployees(){
       this.appointmentService.GetAllEmployees().subscribe(result=> this.employees = result);
    }

}

interface EmployeeModel {
    employeeId: string,
    firstName: string,
    middleName: string,
    lastName: string,
    displayName: string
}