import { Component, OnInit } from "@angular/core";
import { AppointmentService } from "../api-services/services.api.component";

@Component({
    selector: 'schedule-api',
    templateUrl: 'schedule.api.component.html'
})
export class ApiScheduleComponent implements OnInit {

    public schedules: Schedule[];

    constructor(private _service: AppointmentService) { }

    ngOnInit() {
        this.GetAllSchedules();
        console.log(JSON.stringify(this.schedules));
    }

    public GetAllSchedules() {
        console.log("Getting all schedule data..");
        this._service.GetAllSchedules().subscribe(results => this.schedules = results, err => console.log(err));
    }
}
