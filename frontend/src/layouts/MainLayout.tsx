import { Outlet } from "react-router-dom";

const MainLayout = () => {
  return (
    <div className="w-full min-h-screen bg-blue-600/50">
      <Outlet />
    </div>
  );
};

export default MainLayout;
