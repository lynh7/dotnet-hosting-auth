import React from "react";
import {
  createBrowserRouter,
  createRoutesFromElements,
  Route,
  RouterProvider,
} from "react-router-dom";
import MaintenancePage from "./pages/error/maintenance/maintenance-page";
import AuthLayout from "./components/layouts/auth-layouts/index";
import DashboardPage from "./pages/dashboard/index";
import { anonymousRouters } from "./routing";
import NotFoundPage from "./pages/error/404/notfound-page";
import { ROUTE_PATHS } from "./constants/router.constants";

function App() {
  const authState = false;

  const router = createBrowserRouter(
    createRoutesFromElements(
      <Route>
        <Route element={authState ? <DashboardPage /> : <AuthLayout />}>
          {anonymousRouters
            .filter((p) => p.component)
            .map(({ href, component: Component }) => (
              <Route
                key={href}
                path={href}
                element={
                  <React.Suspense fallback={<div>Loading...</div>}>
                    <Component />
                  </React.Suspense>
                }
              />
            ))}
        </Route>
        <Route path={ROUTE_PATHS.NotFound} element={<NotFoundPage />} />
      </Route>
    )
  );

  return process.env.REACT_APP_MAINTENANCE_MODE === "true" ? (
    <MaintenancePage />
  ) : (
    <RouterProvider router={router}/>
  );
}

export default App;
