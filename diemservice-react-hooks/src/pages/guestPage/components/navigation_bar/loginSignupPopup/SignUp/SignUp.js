import React, { useState } from "react";
import styles from "./SignUp.module.scss";
import useCustomForm from "../../../../../../utils/useCustomForm";
import { useUserStore } from "../../../../../../utils/userStore";
import { useHistory } from "react-router-dom";
import useNotification from "../../../../../../utils/useNotification";

export default function SignUp(props) {
  const { Notify, notification } = useNotification();
  const { action, error } = useUserStore(false);
  const [formDisabled, setFormDisabled] = useState(false);
  const SignMeUp = (event) => {
    event.preventDefault();
    setFormDisabled(true);
    action("SIGNUP", values)
      .then(() => {
        Notify({
          body: `An activation email has been sent to ${values.Email}.`,
          header: `Activate email`,
          onCloseHandler: props.finished,
        });
      })
      .catch();
  };

  const { values, handleChange } = useCustomForm({
    initialValues: {},
    onSubmit: () => {},
  });
  return (
    <React.Fragment>
      <form onSubmit={SignMeUp}>
        <div className={styles.field_container}>
          <label>Username</label>
          <input name="Username" onChange={handleChange} type="text" required />
          <label>Name</label>
          <input name="Name" onChange={handleChange} type="text" required />
          <label>Last Name</label>
          <input name="LastName" onChange={handleChange} type="text" required />
          <label>Address</label>
          <input name="Address" onChange={handleChange} type="text" required />
          <label>Phone number</label>
          <input
            name="PhoneNumber"
            onChange={handleChange}
            type="text"
            required
          />
          <label>Email</label>
          <input name="Email" onChange={handleChange} type="text" required />
          <label>Password</label>
          <input name="Pass" onChange={handleChange} type="text" required />
          <label>Repeat password</label>
          <input
            name="RepeatPass"
            onChange={handleChange}
            type="text"
            required
          />
          <input
            className={styles.button}
            value="Sign Up"
            disabled={formDisabled}
            type="submit"
            required
          />
          <label>{error}</label>
        </div>
      </form>

      {notification}
    </React.Fragment>
  );
}
