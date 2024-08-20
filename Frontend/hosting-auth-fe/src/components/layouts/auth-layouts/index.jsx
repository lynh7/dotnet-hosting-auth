import { Outlet } from "react-router-dom";
import React from "react";

function AuthLayout() {

  return (
   <div className="h-full bg-white">
    <div className="h-full">
      <Outlet/>
    </div>
   </div>
  );
}

export default AuthLayout;
