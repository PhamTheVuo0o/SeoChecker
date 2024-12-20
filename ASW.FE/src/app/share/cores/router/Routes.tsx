import {LayoutWithoutAuth} from "@ShareLayouts";
import { createBrowserRouter, RouteObject } from "react-router-dom";
import {RouterAppEnum} from '@ShareEnums'
import {Home} from '@Pages'

export const routes: RouteObject[] = [
    {
        path: RouterAppEnum.Base,
        element: <LayoutWithoutAuth />,
        children:[
            {path: RouterAppEnum.Home, element: <Home />},
        ]
    }
];

export const Router = createBrowserRouter(routes);