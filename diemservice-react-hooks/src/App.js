import React, { useState, useEffect } from "react";
import "./App.css";
import useLoggedUser from "./utils/useLoggedUser";
import GuestPage from "./pages/guestPage/GuestPage";
import RegisteredPage from "./pages/registeredPage/RegisteredPage";

const Pages = {
  RegisteredUser: <RegisteredPage />,
  Guest: <GuestPage />,
};
function App() {
  const { user } = useLoggedUser();
  console.log(user.Role);
  if (user) return Pages[user.Role];

  return <h3>{console.log(user)}Error</h3>;
}

export default App;
