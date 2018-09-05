import { Component, OnInit } from "@angular/core";
import { AppointmentService } from "../api-services/services.api.component";

@Component({
    selector: 'schedule-api',
    templateUrl: 'schedule.api.component.html'
})
export class ApiScheduleComponent implements OnInit {

    public schedules: Schedule[];
    public employees: Employee[];

    constructor(private _service: AppointmentService) { }

    ngOnInit() {
        this.GetAllSchedules();
        this.GetAllEmployees();
    }

    public GetAllSchedules() {
        this._service.GetAllSchedules().subscribe(results => this.schedules = results, err => console.log(err));
    }

    public GetAllEmployees() {
        this._service.GetAllEmployees().subscribe(result => this.employees = result, err => console.log(err));
    }

}
