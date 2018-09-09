interface Days {
    monday: boolean,
    tuesday: boolean,
    wednesday: boolean,
    thursday: boolean,
    friday: boolean,
    saturday: boolean,
    sunday: boolean
}

interface ScheduleTimeModel {
    scheduleTimeId: number,
    timeStart: string,
    timeEnd: string,
    isAvailable: boolean,
    scheduleId: number
}

interface Schedule {
    scheduleId: number,
    employeeId: number,
    dateStart: string,
    dateEnd: string,
    days: Days,
    scheduleTime: ScheduleTimeModel[]
}