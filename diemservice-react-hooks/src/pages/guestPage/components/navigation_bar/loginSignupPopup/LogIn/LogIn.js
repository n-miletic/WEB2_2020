import React from "react";
import styles from "./LogIn.module.scss";
import useCustomForm from "../../../../../../utils/useCustomForm";
import { useUserStore } from "../../../../../../utils/userStore";
import { useHistory } from "react-router-dom";

export default function LogIn(props) {
  const { action, error } = useUserStore({ subscriber: false });
  const history = useHistory();

  const LogMeIn = (event) => {
    console.log(event.target);
    event.preventDefault();

    action("LOGIN", values)
      .then(() => history.push("/"))
      .catch();
  };
  const { values, handleChange } = useCustomForm({
    initialValues: {},
    onSubmit: LogMeIn,
  });

  return (
    <form onSubmit={LogMeIn}>
      <div className={styles.field_container}>
        <label>Username</label>
        <input name="Username" onChange={handleChange} type="text" />
        <label>Password</label>
        <input name="Password" onChange={handleChange} type="password" />
        <input className={styles.button} value="Log In" type="submit" />
        <label>{error}</label>
      </div>
    </form>
  );
}
