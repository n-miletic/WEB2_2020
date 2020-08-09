import React from "react";
import styles from "./ShowMyUser.module.scss";
import { useUserStore } from "../../../../../..//utils/userStore";

function ShowMyUser() {
  const { user, action } = useUserStore();
  return (
    <div className={styles.container}>
      {console.log("Rendering show my user.")}
      <div className={styles.formContainer}>
        <label>Name:</label>
        <label>{user?.Name}</label>
        <label>LastName:</label>
        <label>{user?.LastName}</label>
        <label>Username:</label>
        <label>{user?.Username}</label>
        <label>Email:</label>
        <label>{user?.Email}</label>
      </div>
    </div>
  );
}

export default ShowMyUser;
