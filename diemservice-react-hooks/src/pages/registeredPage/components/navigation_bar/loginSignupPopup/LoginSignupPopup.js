import React, { createContext, useState, useContext, useEffect } from "react";
import "./LoginSignupPopup.scss";

import LogIn from "./LogIn/LogIn";
import SignUp from "./SignUp/SignUp";

export default function LoginSignupPopup(props) {
  const [selectedOption, setSelectedOption] = useState("LOGIN");
  useEffect(() => {}, [selectedOption]);
  return (
    <React.Fragment>
      <div className="gray-overlay"></div>
      <div className="log-sign-navbar">
        <div selectedOption={selectedOption} className="selected">
          <span onClick={() => setSelectedOption("LOGIN")}>LOG IN</span>
          <span onClick={() => setSelectedOption("SIGNUP")}>SIGN UP</span>
        </div>

        <div className="log-sign-div">
          {
            {
              LOGIN: <LogIn finished={props.finished} />,
              SIGNUP: <SignUp finished={props.finished} />,
            }[selectedOption]
          }
        </div>
      </div>
    </React.Fragment>
  );
}
