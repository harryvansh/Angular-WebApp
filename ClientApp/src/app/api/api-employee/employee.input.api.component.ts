import { Component, Inject} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { AppointmentService } from '../api-services/services.api.component';

@Component({
    selector: 'employee-api-input',
    templateUrl: './employee.input.api.component.html'
})
export class ApiEmployeeInputComponent {

    public _employee:EmployeeForm = {
            employeeId: 0,
            firstName: '',
            middleName: '',
            lastName: '',
            displayName: ''
    };

    constructor(private appointmentService:AppointmentService){}
    
    public saveEmployee(){
        this.appointmentService._employeeForm = this._employee;
        this.appointmentService.saveEmployee();
    }
}

interface EmployeeForm {
    employeeId: number,
    firstName: string,
    middleName: string,
    lastName: string,
    displayName: string
}