import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LineModel } from '../line/lineModel';
import { DayType, TimetableModel } from './timetableModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TimetableService {

  constructor(private http:HttpClient) { }

  GetTimetables()
  {
    return this.http.get('http://localhost:52295/api/Timetable/GetTimetables');
  }

  GetTimetable(line:LineModel, dayType: DayType)
  {
    return this.http.put('http://localhost:52295/api/Timetable/GetTimetable?day='+dayType, line);        
  }

  AddTimetable(timetable:TimetableModel)
  {
    return this.http.post('http://localhost:52295/api/Timetable/AddTimetable', timetable);
  }

  UpdateTimetable(timetable:TimetableModel)
  {
    return this.http.put('http://localhost:52295/api/Timetable/UpdateTimetable',timetable);
  }

  DeleteTimetable(id:number)
  {
    return this.http.delete('http://localhost:52295/api/Timetable/DeleteTimetable?id='+id);
  }
}
