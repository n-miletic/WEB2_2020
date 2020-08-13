import React from "react";
import NavigationBar from "./components/navigation_bar/NavigationBar";
import { BrowserRouter, Route } from "react-router-dom";
import MyUserPage from "./components/my_user_page/MyUserPage";

export default function RegisteredPage(props) {
  return (
    <div>
      <BrowserRouter>
        <NavigationBar />
        <Route exact path="/MyUser">
          <MyUserPage />
        </Route>
      </BrowserRouter>
    </div>
  );
}
