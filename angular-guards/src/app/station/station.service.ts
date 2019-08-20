import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { StationModel } from './stationModel';

@Injectable({
  providedIn: 'root'
})
export class StationService {

  constructor(private http:HttpClient) { }

  GetStations()
  {
    return this.http.get('http://localhost:52295/api/Station/GetStations');
  }

  UpdateStation(station:StationModel)
  {
    return this.http.put('http://localhost:52295/api/Station/UpdateStation',station);
  }

  AddStation(station:StationModel)
  {
    return this.http.post('http://localhost:52295/api/Station/AddStation',station);
  }

  AddStationToLine(id:number, station:StationModel)
  {
    return this.http.post("http://localhost:52295/api/Station/AddStationToLine?id="+id,station);
  }

  DeleteStation(id:number)
  {
    return this.http.delete("http://localhost:52295/api/Station/DeleteStation?id="+id);
  }
}
