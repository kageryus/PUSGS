import { DepartureModel } from './departureModel';
import { LineModel } from '../line/lineModel';

export enum DayType
{
    WorkDay, Saturday,Sunday
}

export class TimetableModel{
    Id: number;
    Departures: DepartureModel[];
    LineId: number;
    Line: LineModel;
    DayType: DayType;
    

    
    
    constructor(id: number,departures:DepartureModel[],lineId:number,line:LineModel, dayType:DayType ){
        this.Id = id;
        this.Departures = name;
       
        this.LineId = lineId;
        this.DayType = dayType;
        this.Line = line;
      
    }
}