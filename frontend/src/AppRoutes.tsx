import { Routes, Route } from "react-router-dom";
import Index from "./pages/Index";
import MainLayout from "./layouts/MainLayout";

const AppRoutes = () => {
  return (
    <Routes>
      <Route path="/" element={<MainLayout />}>
        <Route index element={<Index />} />
      </Route>
    </Routes>
  );
};

export default AppRoutes;
