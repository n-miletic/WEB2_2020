import React, { useState } from "react";
import styles from "./LogIn.module.scss";
import useCustomForm from "../../../../../../utils/useCustomForm";
import { useLoggedUser } from "../../../../../../utils/useLoggedUser";
import { useQuery } from "react-query";
import { queryCache } from "react-query";

export default function LogIn(props) {
  const [loginErr, setLoginErr] = useState("");

  const { logUserIn } = useLoggedUser();

  const LogMeIn = (event) => {
    event.preventDefault();
    logUserIn(values)
      .then(() => {
        props.finished();
      })
      .catch((err) => {
        setLoginErr(err.message);
      });
  };

  const { values, handleChange } = useCustomForm({
    initialValues: {},
    onSubmit: LogMeIn,
  });

  const { data: User, error, isLoading } = useQuery("token", () =>
    fetch("/DiemApi/User/GetLogged", {
      headers: {
        Authorization: "Bearer " + localStorage.getItem("loggedUserToken"),
      },
    }).then((res) => {
      throw new Error("err");
    })
  );

  return (
    <form onSubmit={LogMeIn}>
      <div className={styles.field_container}>
        <label>Username</label>
        <input name="Username" onChange={handleChange} type="text" />
        <label>Password</label>
        <input name="Password" onChange={handleChange} type="password" />
        <input className={styles.button} value="Log In" type="submit" />
        <label>{loginErr}</label>
      </div>
    </form>
  );
}
