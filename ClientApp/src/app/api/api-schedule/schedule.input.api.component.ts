import { Component, OnInit } from "@angular/core";
import { AppointmentService } from "../api-services/services.api.component";
import { FormBuilder, FormGroup, FormArray, Validators } from "@angular/forms";

@Component({
    selector: 'scheduleInput-api',
    templateUrl: './schedule.input.api.component.html'
})
export class ApiInputScheduleComponent implements OnInit {
    public employees: Employee[];
    public scheduleFormGroup: FormGroup;
   
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
                scheduleTimeId: ['0'],
                timeStart: [''],
                timeEnd: [''],
                scheduleId: ['0']
            }));   
    }

    public GetAllEmployees() {
        this.appointmentService.GetAllEmployees().subscribe(result => this.employees = result, error => console.log(error));
    }

    public saveSchedule() {
        this.appointmentService.saveSchedule(this.scheduleFormGroup.getRawValue());
    }
}