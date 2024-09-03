import React from "react";
import {
  createBrowserRouter,
  createRoutesFromElements,
  Route,
  RouterProvider,
  Navigate,
} from "react-router-dom";
import MaintenancePage from "./pages/error/maintenance/maintenance-page";
import AuthLayout from "./components/layouts/auth-layouts/index";
import { anonymousRouters, authRouters } from "./routing";
import NotFoundPage from "./pages/error/404/notfound-page";
import { ROUTE_PATHS } from "./constants/router.constants";
import DashLayout from "./components/layouts/dash-layouts";
import { useRecoilValue } from "recoil";
import { MainState } from "./states/auth.state";

function App() {
  const authState = useRecoilValue(MainState.AuthState);  

  const router = createBrowserRouter(
    createRoutesFromElements(
      <Route>
        <Route
          element={
            authState ? <Navigate to={ROUTE_PATHS.Home} /> : <AuthLayout />
          }
        >
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
        <Route
          element={
            authState ? <DashLayout /> : <Navigate to={ROUTE_PATHS.Login} />
          }
        >
          {authRouters
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
      <RouterProvider router={router} />
  );
}

export default App;
