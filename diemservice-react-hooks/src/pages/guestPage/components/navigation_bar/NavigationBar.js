import React, { useState } from "react";
import styles from "./NavigationBar.module.scss";
import logoPic from "./assets/logo.png";
import userPic from "./assets/user.png";
import { Link } from "react-router-dom";

import LoginSignupPopup from "./loginSignupPopup/LoginSignupPopup";

export default function NavigationBar() {
  const [loginSignupDialog, setloginSignupDialog] = useState(false);

  const closeDialog = () => {
    setloginSignupDialog(false);
  };

  return (
    <div className={styles.navbar}>
      {console.log("Rendering guest page navigation bar")}
      <img
        alt="Can't load company"
        className={styles.company_img}
        src={logoPic}
      />
      <div className={styles.user_shortcuts}>
        <Link className={styles.link} to="/">
          HOME
        </Link>
        <Link className={styles.link} to="/">
          FLIGHTS
        </Link>
        <img
          alt="cant load user img"
          onClick={() => {
            setloginSignupDialog(true);
          }}
          className={styles.user_img}
          src={userPic}
        />
      </div>
      {loginSignupDialog && <LoginSignupPopup finished={closeDialog} />}
    </div>
  );
}
