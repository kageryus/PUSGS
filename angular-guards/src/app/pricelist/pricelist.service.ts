import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class PricelistService {

  constructor(private http: HttpClient) { }

  GetActualPricelist()
  {
    return this.http.get('http://localhost:52295/api/Pricelist/GetActualPricelist');
  }

  AddPricelist(pricelist)
  {
    return this.http.post("http://localhost:52295/api/Pricelist/AddPricelist",pricelist);
  }
}
