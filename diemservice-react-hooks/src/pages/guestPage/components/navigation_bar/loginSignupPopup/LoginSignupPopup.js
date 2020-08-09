import React, { useState } from "react";
import styles from "./LoginSignupPopup.module.scss";

import LogIn from "./LogIn/LogIn";
import SignUp from "./SignUp/SignUp";

export default function LoginSignupPopup(props) {
  const [selectedoption, setSelectedOption] = useState("LOGIN");
  return (
    <React.Fragment>
      <div className={styles.gray_overlay}></div>
      <div className={styles.log_sign_navbar}>
        <div selectedoption={selectedoption} className={styles.selected}>
          <span onClick={() => setSelectedOption("LOGIN")}>LOG IN</span>
          <span onClick={() => setSelectedOption("SIGNUP")}>SIGN UP</span>
        </div>

        <div className={styles.log_sign_div}>
          {
            {
              LOGIN: <LogIn finished={props.finished} />,
              SIGNUP: <SignUp finished={props.finished} />,
            }[selectedoption]
          }
        </div>
      </div>
    </React.Fragment>
  );
}
