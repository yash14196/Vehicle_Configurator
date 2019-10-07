import { IManufacturer } from './IManufacturer';

export class ManufacturerData implements IManufacturer{

    constructor(public man_id:number,
        public man_name:string){}
}