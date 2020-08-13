import React from "react";
import styles from "./NavigationBar.module.scss";
import logoPic from "./assets/logo.png";
import { Link } from "react-router-dom";
import { useUserStore } from "../../../../utils/userStore";

export default function NavigationBar() {
  const { user, action } = useUserStore({ susbscriptions: ["Username"] });
  return (
    <div className={styles.navbar}>
      {console.log("Rendering registered page navigation bar")}
      <img alt="retardiran si" className={styles.company_img} src={logoPic} />
      <div className={styles.user_shortcuts}>
        <Link className={styles.link} to="/">
          HOME
        </Link>
        <Link className={styles.link} to="/">
          FLIGHTS
        </Link>
        <Link className={styles.link} to="/MyUser">
          {user.Username}
        </Link>
        <span className={styles.link} onClick={() => action("LOGOUT")}>
          LOG OUT
        </span>
      </div>
    </div>
  );
}
