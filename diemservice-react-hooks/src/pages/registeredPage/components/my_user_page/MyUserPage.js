import React, { useState } from "react";
import styles from "./MyUserPage.module.scss";
import ShowMyUser from "./components/show_my_user/ShowMyUser";
import EditMyUser from "./components/edit_my_user/EditMyUser";

const user = {
  "My Info": <ShowMyUser />,
  "Edit User": <EditMyUser />,
};
function MyUserPage() {
  const [editingUser, setEditingUser] = useState(false);

  return (
    <grid>
      <div className={styles.border}>
        <div className={styles.navitems}>
          {Object.keys(user).map((key) => (
            <label>{key}</label>
          ))}
        </div>
      </div>
      <div className="itemcontainer">
        {console.log("rendering my user page")}
        <ShowMyUser />
      </div>
    </grid>
  );
}

export default MyUserPage;
