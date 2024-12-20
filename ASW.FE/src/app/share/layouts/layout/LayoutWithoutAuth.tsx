import { Outlet } from "react-router-dom";

export function LayoutWithoutAuth() {
  return (
    <div>
      <Outlet />
    </div>

  );
}

export default LayoutWithoutAuth
