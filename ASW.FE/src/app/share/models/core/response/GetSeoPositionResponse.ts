import { BaseResponse } from '@ShareModels'
export interface GetSeoPositionResponse extends BaseResponse<SeoPosition[]> { }

export interface SeoPosition {
    provider: string;
    positions: number[];
  }
