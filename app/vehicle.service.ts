import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IRegistration } from './IRegistration';
import { Observable, Subject, Subscriber } from 'rxjs';
import { ISegment } from './ISegment';
import { IManufacturer } from './IManufacturer';
import { IVariant } from './IVariant';
import { IConfiguration } from './IConfiguration';
import { IAlternate } from './IAlternate';



@Injectable({
  providedIn: 'root'
})
export class VehicleService {

  logyesno = false;
  altArray:[];
  i:number=0;
  constructor( private http : HttpClient) { }
  private subject=new Subject<any>();
  addAltId(alt)
  {
  console.log(alt);
    this.altArray=alt;
    //this.altArray=id;
    //this.subject.next(altarray);
  }
  
  getaltdesp()
  {
    return this.altArray;
  }
  getAltId():Observable<any>
  {
    return this.subject.asObservable();
  }


  addRegistrationDetails (reg:IRegistration) : Observable<IRegistration[]>{
    return this.http.post<IRegistration[]>('http://localhost:50152/VehicleService.svc/AddRegistrationDetails',reg);
  }

  checkCredentials (reg:IRegistration) : Observable<string>{
    return this.http.get<string>("http://localhost:50152/VehicleService.svc/GetCredentials/"+reg.login_id+"/"+reg.password);
  }

  getAllSegment() : Observable<ISegment[]>
  {
    return this.http.get<ISegment[]> ("http://localhost:50152/VehicleService.svc/GetAllSegment");
  }

  getManufacturerBySegId(seg_id : number) : Observable<IManufacturer[]>
  {
   // console.log(seg_id);
    return this.http.get<IManufacturer[]>("http://localhost:50152/VehicleService.svc/GetManufacturerBySegId/"+seg_id);
  } 

  getVariantBySegIdnManId(man_id : number):Observable<IVariant[]>
  {
    console.log(man_id);
    return this.http.get<IVariant[]>('http://localhost:50152/VehicleService.svc/GetVariantBySegIdnManId/'+man_id);
  }

  getDefaultFeatureByVarId( varid : string):Observable<IConfiguration[]>{
    return this.http.get<IConfiguration[]>('http://localhost:50152/VehicleService.svc/GetDefaultFeature/'+varid);
  }

  getStandardFeatureByVarId(varid : string):Observable<IConfiguration[]>{
    return this.http.get<IConfiguration[]>('http://localhost:50152/VehicleService.svc/GetStandardFeature/'+varid);
  }

  getInteriorFeatureByVarId(varid : string):Observable<IConfiguration[]>{
    return this.http.get<IConfiguration[]>('http://localhost:50152/VehicleService.svc/GetInteriorFeature/'+varid);
  }

  getExteriorFeatureByVarId(varid : string):Observable<IConfiguration[]>{
    return this.http.get<IConfiguration[]>('http://localhost:50152/VehicleService.svc/GetExteriorFeature/'+varid);
  }

  getVariantByVarId(varid : string):Observable<IVariant[]>{
    return this.http.get<IVariant[]>('http://localhost:50152/VehicleService.svc/GetVariantByVarId/'+varid);
  }

  getStandardConfigurableByVarId(varid : string):Observable<IConfiguration[]>{
    return this.http.get<IConfiguration[]>('http://localhost:50152/VehicleService.svc/GetStandardConfigurableByVarId/'+varid);
  }

  getInteriorConfigurableByVarId(varid : string):Observable<IConfiguration[]>{
    return this.http.get<IConfiguration[]>('http://localhost:50152/VehicleService.svc/GetInteriorConfigurableByVarId/'+varid);
  }

  getExteriorConfigurableByVarId(varid : string):Observable<IConfiguration[]>{
    return this.http.get<IConfiguration[]>('http://localhost:50152/VehicleService.svc/GetExteriorConfigurableByVarId/'+varid);
  }

  getAltDespByConfId(confid : string):Observable<IAlternate[]>{
    return this.http.get<IAlternate[]>('http://localhost:50152/VehicleService.svc/GetAltDespByConfId/'+confid);
  }

  getAltDespByAltId(altid : string):Observable<IAlternate[]>{
    return this.http.get<IAlternate[]>('http://localhost:50152/VehicleService.svc/GetAlternateConfigurationByAltId/'+altid);
  }

  userlogindone(yn)
  {
    this.logyesno = yn;
  }

  userloginchk():boolean{
    return this.logyesno;
  }
  
}
