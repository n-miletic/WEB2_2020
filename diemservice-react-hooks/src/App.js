import React from "react";
import "./App.css";
import { useUserStore } from "./utils/userStore";
import GuestPage from "./pages/guestPage/GuestPage";
import RegisteredPage from "./pages/registeredPage/RegisteredPage";

const Pages = {
  RegisteredUser: <RegisteredPage />,
  Guest: <GuestPage />,
};
function App() {
  const { user } = useUserStore();
  console.log(user);
  if (user) return Pages[user.Role];

  return Pages["Guest"];
}

export default App;
