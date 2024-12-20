export interface GetSeoPositionRequest {
  keyword: string;
  url: string;
  provider?: string;
  isGetCurrentData?:boolean;
}
