import { Injectable, OnInit, Inject } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { FormBuilder, FormGroup } from "@angular/forms";

const _httpOptions = {
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
};

@Injectable()
export class AppointmentService {
    public _appointments: AppointmentModel[];
    public _appointmentForm: AppointmentForm;
    public _employeeForm: Employee;
    public _scheduleForm: Schedule;

    constructor(private _http: HttpClient, @Inject('BASE_URL') private _baseUrl: string) { }

    public getAllAppointments() {
        return this._http.get<AppointmentModel[]>(this._baseUrl + 'api/Appointments/Appointment', _httpOptions);
    }

    public GetAllEmployees() {
        return this._http.get<Employee[]>(this._baseUrl + 'api/Employees/Employee', _httpOptions);
    }

    public GetAllSchedules() {
        return this._http.get<Schedule[]>(this._baseUrl + 'api/Schedules/Schedule', _httpOptions);
    }

    public GetEmployeeById(employeeId: number){
        return this._http.get<Employee>(this._baseUrl + 'api/Employees/Employee/' + employeeId, _httpOptions);
    }

    public saveAppointment() {
        console.log("Header: " + _httpOptions.headers);
        console.log("Creating new appointment.. " + JSON.stringify(this._appointmentForm));
        this._http.post<AppointmentForm>(this._baseUrl + 'api/Appointments/Appointment', JSON.stringify(this._appointmentForm), _httpOptions).subscribe(result => result = this._appointmentForm);
    }

    public saveEmployee() {
        console.log("Header: " + _httpOptions.headers);
        console.log("Creating new employee.. " + JSON.stringify(this._employeeForm));
        this._http.post<Employee>(this._baseUrl + 'api/Employees/Employee', JSON.stringify(this._employeeForm), _httpOptions).subscribe(employee => this._employeeForm);
    }

    public saveSchedule(scheduleData: FormGroup) {
        console.log("Header: " + _httpOptions.headers);
        console.log("Creating new employee schedule.. " + JSON.stringify(scheduleData));
        this._http.post<FormGroup>(this._baseUrl + 'api/Schedules/Schedule', JSON.stringify(scheduleData), _httpOptions).subscribe(schedule => scheduleData);
    }
}



