import React from "react";
import styles from "./ShowMyUser.module.scss";
import { useUserStore } from "../../../../../..//utils/userStore";

function ShowMyUser() {
  const { user } = useUserStore();
  return (
    <div className={styles.container}>
      {console.log("Rendering show my user.")}
      <div className={styles.formContainer}>
        <div className={styles.flex_between}>
          <label>Name:</label>
          <label>{user?.Name}</label>
        </div>
        <div className={styles.flex_between}>
          <label>LastName:</label>
          <label>{user?.LastName}</label>
        </div>
        <div className={styles.flex_between}>
          <label>Username:</label>
          <label>{user?.Username}</label>
        </div>
        <div className={styles.flex_between}>
          <label>Email:</label>
          <label>{user?.Email}</label>
        </div>
      </div>
    </div>
  );
}

export default ShowMyUser;
