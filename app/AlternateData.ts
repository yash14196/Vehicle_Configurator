import { IAlternate } from './IAlternate';

export class AlternateData implements IAlternate{
    constructor( public alt_id: number,public conf_id: number,
    public alt_desp: string,
    public alt_price: number){}

    
}