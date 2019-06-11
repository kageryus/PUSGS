import { Timetable } from "./timetable";


export class Line{
    Id: number;
    name: string;
    timeTableId: number;
    timeTable: Timetable;
}