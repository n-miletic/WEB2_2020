import React, { Fragment, useState } from "react";
import "./NavigationBar.scss";
import logoPic from "./assets/logo.png";
import userPic from "./assets/user.png";
import { Link } from "react-router-dom";
import { useQuery } from "react-query";

import LoginSignupPopup from "./loginSignupPopup/LoginSignupPopup";

export default function NavigationBar() {
  const [loginSignupDialog, setloginSignupDialog] = useState(false);

  const closeDialog = () => {
    setloginSignupDialog(false);
  };

  return (
    <div className="navbar">
      <img className="company-img" src={logoPic} />
      <div className="user-shortcuts">
        <Link className="link" to>
          HOME
        </Link>
        <Link className="link" to>
          FLIGHTS
        </Link>
        <img
          onClick={() => {
            setloginSignupDialog(true);
          }}
          className="user-img"
          src={userPic}
        />
      </div>
      {loginSignupDialog && <LoginSignupPopup finished={closeDialog} />}
    </div>
  );
}
