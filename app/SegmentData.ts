import { ISegment } from './ISegment';

export class SegmentData implements ISegment{

    constructor(public seg_id:number,
        public seg_name:string){}
}