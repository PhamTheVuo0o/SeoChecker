import { useState } from 'react';
import { CoreService } from "@ShareServices";
import { useMutation } from '@tanstack/react-query';
import {
    GetSeoPositionResponse,
  } from "@ShareModels";

export function useGetSeoPosition() {
    const [ouput, setOuput] = useState<GetSeoPositionResponse | null>(null);
    const { mutate, isSuccess, isError, isPending } = useMutation({
        mutationFn: CoreService.GetSeoPosition,
        onSuccess: (data) => {
            if (data.isSuccess && data.data) {
                setOuput(data);
            }
            return data;
        },
    });

    return {
        GetSeoPosition: mutate,
        isSuccess,
        isError,
        isPending,
        ouput
    };
}
