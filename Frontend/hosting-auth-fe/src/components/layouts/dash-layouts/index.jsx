import { Outlet } from "react-router-dom";
import React from "react";

function DashLayout() {

  return (
   <div className="h-full bg-white">
    <div className="h-full">
      <Outlet/>
    </div>
   </div>
  );
}

export default DashLayout;
