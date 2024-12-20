import {
  GetSeoPositionRequest,
  GetSeoPositionResponse,
} from "@ShareModels";
import { BaseServices } from "@ShareServices";
import { API_URL } from '@ShareConstants';

const basePath: string = '/';

export const GetSeoPosition = async (body: GetSeoPositionRequest) => {
  return BaseServices.post<GetSeoPositionResponse>(
    `${API_URL.Core}${basePath}GetSeoPosition`, body
  );
};

export const CoreService = {
  GetSeoPosition,
};

export default CoreService;