import { StrictMode } from "react";
import { createRoot } from "react-dom/client";
import "./index.css";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { BrowserRouter as Router } from "react-router-dom";
import AppRoutes from "./AppRoutes";

const client = new QueryClient();

createRoot(document.getElementById("root")!).render(
  <StrictMode>
    <Router>
      <QueryClientProvider client={client}>
        <AppRoutes />
      </QueryClientProvider>
    </Router>
  </StrictMode>
);
