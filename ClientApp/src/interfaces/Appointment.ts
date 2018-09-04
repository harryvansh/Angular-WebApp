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