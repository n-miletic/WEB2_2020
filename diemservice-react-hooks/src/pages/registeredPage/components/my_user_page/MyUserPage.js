import React from "react";
import styles from "./MyUserPage.module.scss";
import ShowMyUser from "./components/show_my_user/ShowMyUser";
import EditMyUser from "./components/edit_my_user/EditMyUser";
function MyUserPage() {
  return (
    <div className={styles.container}>
      {console.log("rendering my user page")}
      <ShowMyUser />
    </div>
  );
}

export default MyUserPage;
