import { TimetableModel } from "./timetableModel";

export class DepartureModel {
    Id: number;
    Hour: number;
    Minutes: number[];
    TimetableId: number;
    Timetable: TimetableModel;
   
  
    constructor(id: number, hour: number,minutes:number[],timetableId:number,timetableModel:TimetableModel) {
        this.Id = id;
        this.Hour = hour;
        this.Minutes=minutes;
        this.TimetableId=timetableId;
        this.Timetable=timetableModel;
    }
  }