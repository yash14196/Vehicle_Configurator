import { IVariant } from './IVariant';

export class VariantData implements IVariant{
   constructor(public var_id: number, public var_name: string,
    public seg_id: number,
    public man_id: number,
    public min_qty: number,
    public base_price: number,
    public image: string){}

    
}