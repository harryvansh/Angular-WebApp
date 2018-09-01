import { Component, OnInit } from "@angular/core";
import { AppointmentService } from "../api-services/services.api.component";
import { FormBuilder, FormGroup, FormArray, Validators } from "@angular/forms";

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
            scheduleId: [0],
            employeeId:['',Validators.required],
            dateStart:['',Validators.required],
            dateEnd:['',Validators.required],
            days: this._formBuilder.group({
                monday:[false],
                tuesday:[false],
                wednesday:[false],
                thursday:[false],
                friday:[false],
                saturday:[false],
                sunday:[false]
            }),
           scheduleTime: this._formBuilder.array([
                this._formBuilder.group({
                    scheduleTimeId: [0],
                    timeStart: [''],
                    timeEnd: [''],
                    scheduleId: [0]
                    
                })
            ])
        });
         
        this.GetAllEmployees();
    }

    constructor(private appointmentService: AppointmentService, private _formBuilder : FormBuilder) { }
    getScheduleTime() {
        return this.scheduleFormGroup.get('scheduleTime') as FormArray;
    }

    public addStartEndTime() {
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

    public saveSchedule() {
        // this.appointmentService._scheduleForm = this.scheduleFormGroup;
        this.appointmentService.saveSchedule(this.scheduleFormGroup.getRawValue());
    }
}

interface EmployeeModel {
    employeeId: string,
    firstName: string,
    middleName: string,
    lastName: string,
    displayName: string
}