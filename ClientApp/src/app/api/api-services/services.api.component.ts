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
    public _employees: EmployeeModel[];
    public _appointmentForm: AppointmentForm;
    public _employeeForm:EmployeeForm;
    public _scheduleForm:FormGroup;

    constructor(private _http: HttpClient, @Inject('BASE_URL') private _baseUrl: string) {}

    public getAllAppointments() {
        return this._http.get<AppointmentModel[]>(this._baseUrl + 'api/Appointments/Appointment', _httpOptions);
    }

    public GetAllEmployees() {
        return this._http.get<EmployeeModel[]>(this._baseUrl + 'api/Employees/Employee', _httpOptions);
    }

    public saveAppointment() {
        console.log("Header: " + _httpOptions.headers);
        console.log("Creating new appointment.. " + JSON.stringify(this._appointmentForm));
        this._http.post<AppointmentForm>(this._baseUrl + 'api/Appointments/Appointment', JSON.stringify(this._appointmentForm), _httpOptions).subscribe(result => result = this._appointmentForm);
    }

    public saveEmployee()
    {
        console.log("Header: " + _httpOptions.headers);
        console.log("Creating new employee.. " + JSON.stringify(this._employeeForm));
        this._http.post<EmployeeForm>(this._baseUrl + 'api/Employees/Employee', JSON.stringify(this._employeeForm), _httpOptions).subscribe(employee=>this._employeeForm);
    }

    public saveSchedule(scheduleData:FormGroup){
        console.log("Header: " + _httpOptions.headers);
        console.log("Creating new employee schedule.. "+ JSON.stringify(scheduleData));
        this._http.post<FormGroup>(this._baseUrl + 'api/Schedules/Schedule', JSON.stringify(scheduleData), _httpOptions).subscribe(schedule=>scheduleData);
    }
}

interface AppointmentModel {
    appointmentId: number,
    customerId: number,
    employeeId: number,
    appointmentTime: Date
}

interface AppointmentForm {
    employeeId: number,
    customerFirstName: string,
    customerMiddleName: string,
    customerLastName: string,
    appointmentTime: Date
}

interface EmployeeModel {
    employeeId: string,
    firstName: string,
    middleName: string,
    lastName: string,
    displayName: string
}

interface EmployeeForm {
    employeeId: number,
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