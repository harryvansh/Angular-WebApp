import { Component, OnInit } from "@angular/core";
import { AppointmentService } from "../api-services/services.api.component";

@Component({
    selector: 'employee-schedule',
    templateUrl: './employee.schedule.api.component.html'
})
export class ApiEmployeeScheduleComponent implements OnInit {
    public employees: EmployeeModel[];
    public scheduleForm: ScheduleForm = {
        scheduleId: undefined,
        employeeId: undefined,
        dateStart: undefined,
        dateEnd: undefined,
        day: undefined,
        scheduleTime: undefined
    };
    public daysForm: DaysForm = {
        monday: false,
        tuesday: false,
        wednesday: false,
        thursday: false,
        friday: false,
    }

    ngOnInit() {
        this.GetAllEmployees();
    }

    constructor(private appointmentService: AppointmentService) { }

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

interface ScheduleTimeModel {
    scheduleTimeId: number,
    timeStart: string,
    timeEnd: string,
    scheduleId: number
}

interface ScheduleForm {
    scheduleId: number,
    employeeId: number,
    dateStart: string,
    dateEnd: string,
    day: string,
    scheduleTime: ScheduleTimeModel[]
}

interface DaysForm {
    monday: boolean,
    tuesday: boolean,
    wednesday: boolean,
    thursday: boolean,
    friday: boolean,
}