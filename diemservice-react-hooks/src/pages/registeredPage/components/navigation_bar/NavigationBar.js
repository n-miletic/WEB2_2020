import React, { Fragment, useState } from "react";
import "./NavigationBar.scss";
import logoPic from "./assets/logo.png";
import userPic from "./assets/user.png";
import { Link } from "react-router-dom";
import { useQuery } from "react-query";
import useLoggedUser from "../../../../utils/useLoggedUser";

export default function NavigationBar() {
  const { user, logOut } = useLoggedUser();
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
        <Link className="link" to>
          {user.Username}
        </Link>
        <Link className="link" onClick={logOut}>
          LOG OUT
        </Link>
      </div>
    </div>
  );
}
