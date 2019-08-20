import { StationModel } from 'src/app/station/stationModel';

export class LineModel{
    Id: number;
    LineName: string;    
    Stations: StationModel[] = [];
    //Version: number;
    
    
    constructor( id: number,  linename:string,stations: StationModel[], col:string, ver? : number ){
        this.Id = id;
        this.LineName = linename;
        this.Stations = stations;        
        //this.Version = ver;
      
    }
}