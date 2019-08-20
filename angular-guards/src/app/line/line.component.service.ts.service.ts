import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LineModel } from './lineModel';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LineService {

  constructor(private http: HttpClient) { }

  GetAll()
  {
    return this.http.get('http://localhost:52295/api/Line/GetAll');
  }

  GetLine(id:number)
  {
    return this.http.get('http://localhost:52295/api/Line/GetLine?id='+id);
  }

  AddLine(line:LineModel)
  {
    return this.http.post('http://localhost:52295/api/Line/AddLine', line);
  }

  UpdateLine(line:LineModel)
  {
    return this.http.put('http://localhost:52295/api/Line/UpdateLine',line);
  }

  DeleteLine(id:number)
  {
    return this.http.delete('http://localhost:52295/api/Line/DeleteLine?id='+id);
  }
}
