import { Component, OnInit } from "@angular/core";
import { AppointmentService } from "../api-services/services.api.component";
import { FormBuilder, FormGroup, FormArray } from "@angular/forms";

@Component({
    selector: 'employee-schedule',
    templateUrl: './employee.schedule.api.component.html'
})
export class ApiEmployeeScheduleComponent implements OnInit {
    public employees: EmployeeModel[];
    public scheduleFormGroup: FormGroup;
    
   
    // public scheduleForm: ScheduleForm = {
    //     scheduleId: undefined,
    //     employeeId: undefined,
    //     dateStart: undefined,
    //     dateEnd: undefined,
    //     day: undefined,
    //     scheduleTime: undefined
    // };
    // public daysForm: DaysForm = {
    //     monday: false,
    //     tuesday: false,
    //     wednesday: false,
    //     thursday: false,
    //     friday: false,
    // }

    ngOnInit() {
        this.scheduleFormGroup = this._formBuilder.group({
            scheduleId: [''],
            employeeId:[''],
            dateStart:[''],
            dateEnd:[''],
            days: this._formBuilder.group({
                monday:[''],
                tuesday:[''],
                wednesday:[''],
                thursday:[''],
                friday:[''],
                saturday:[''],
                sunday:['']
            }),
           scheduleTime: this._formBuilder.array([
                this._formBuilder.group({
                    scheduleTimeId: [''],
                    timeStart: [''],
                    timeEnd: [''],
                    scheduleId: ['']
                    
                })
            ])
        });
         
        this.GetAllEmployees();
    }

    constructor(private appointmentService: AppointmentService, private _formBuilder : FormBuilder) { }
    getScheduleTime() {
        return this.scheduleFormGroup.get('scheduleTime') as FormArray;
    }

    addStartEndTime() {
        this.getScheduleTime().push(
            this._formBuilder.group({
                scheduleTimeId: [''],
                timeStart: [''],
                timeEnd: [''],
                scheduleId: ['']
            }));   
    }

    public GetAllEmployees() {
        this.appointmentService.GetAllEmployees().subscribe(result => this.employees = result, error => console.log(error));
    }
}

interface EmployeeModel {
    employeeId: string,
    firstName: string,
    middleName: string,
    lastName: string,
    displayName: string
}

// interface ScheduleTimeModel {
//     scheduleTimeId: number,
//     timeStart: string,
//     timeEnd: string,
//     scheduleId: number
// }

// interface ScheduleForm {
//     scheduleId: number,
//     employeeId: number,
//     dateStart: string,
//     dateEnd: string,
//     day: string,
//     scheduleTime: ScheduleTimeModel[]
// }

// interface DaysForm {
//     monday: boolean,
//     tuesday: boolean,
//     wednesday: boolean,
//     thursday: boolean,
//     friday: boolean,
// }