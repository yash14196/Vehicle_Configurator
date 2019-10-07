import { IConfiguration } from './IConfiguration';

export class ConfigurationData implements IConfiguration{
    constructor (public conf_id: number, public var_id: number,
    public type: string,
    public configurable: string,
    public description: string){}

}