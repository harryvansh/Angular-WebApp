import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSelectModule, MatButtonModule, MatInputModule, MatCheckboxModule, MatNativeDateModule, MatDatepickerModule } from '@angular/material';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ApiAppointmentComponent } from './api/api-appointment/appointment.api.component';
import { ApiHomeComponent } from './api/api-home/home.api.component';
import { ApiNavComponent } from './api/api-nav/nav.api.component';
import { RouterConfigLoader } from '../../node_modules/@angular/router/src/router_config_loader';
import { AppointmentComponent } from './Appointment/appointment.component';
import { ApiEmployeeComponent } from './api/api-employee/employee.api.component';
import { ApiEmployeeInputComponent } from './api/api-employee/employee.input.api.component';
import { ApiAppointmentInputComponent } from './api/api-appointment/appointment.input.api.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ApiHomeComponent,
    ApiAppointmentComponent,
    ApiNavComponent,
    AppointmentComponent,
    ApiEmployeeComponent,
    ApiEmployeeInputComponent,
    ApiAppointmentInputComponent

  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    MatSelectModule, MatButtonModule, MatInputModule, MatCheckboxModule, MatDatepickerModule, MatNativeDateModule,
    RouterModule.forRoot([
      {
        path: '',
        component: HomeComponent,
        pathMatch: 'full'
      },
      {
        path: 'appointment',
        component: AppointmentComponent,
        children: [
          { path: '', component: ApiEmployeeComponent, outlet: 'api' },
          { path: 'appointments', component: ApiAppointmentComponent, outlet: 'api' },
          { path: 'employees', component: ApiEmployeeComponent, outlet: 'api' },
          { path: 'employee-input', component: ApiEmployeeInputComponent, outlet: 'api' },
          { path: 'appointment-input', component: ApiAppointmentInputComponent, outlet: 'api' }
        ]
      }
    ]),
    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
