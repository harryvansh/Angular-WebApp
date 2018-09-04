import { Component, Inject, OnInit, NgModule } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AppointmentService } from '../api-services/services.api.component';

@Component({
    selector: "appointment-input-api",
    templateUrl: "./appointment.input.api.component.html"
})
export class ApiAppointmentInputComponent implements OnInit {
    private _employees: Employee[];
    public firstFormGroup: FormGroup;
    public secondFormGroup: FormGroup;
    public thirdFormGroup: FormGroup;


    public _appointment: AppointmentForm = {
        employeeId: undefined,
        customerFirstName: undefined,
        customerMiddleName: undefined,
        customerLastName: undefined,
        appointmentTime: undefined
    };

    constructor(private appointmentService: AppointmentService, private _formBuilder: FormBuilder) {}

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
        this.appointmentService.GetAllEmployees().subscribe(result => this._employees = result);
    }

    public saveAppointment() {
        this.appointmentService._appointmentForm = this._appointment;
        this.appointmentService.saveAppointment();
        }

}