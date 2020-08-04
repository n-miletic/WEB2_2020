import React from "react";
import NavigationBar from "./components/navigation_bar/NavigationBar";
import { BrowserRouter } from "react-router-dom";

export default function RegisteredPage() {
  return (
    <div>
      <BrowserRouter>
        <NavigationBar />
      </BrowserRouter>
    </div>
  );
}
