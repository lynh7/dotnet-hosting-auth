import {ROUTE_PATHS} from "./constants/router.constants"
import DashboardPage from "./pages/dashboard";
import LoginPage from "./pages/login/login-page";
import React from 'react';

export const anonymousRouters = [{
    href: ROUTE_PATHS.Login,  
    component: () => <LoginPage/>,  
  },{
    href: ROUTE_PATHS.Home,  
    component: () => <DashboardPage/>,  
  }];

