import React from "react";
import styles from "./Notification.module.scss";
const Notification = (props) => {
  console.log(props);
  let header = "Notification";
  let body = "A Notification has occured.";
  let buttonText = "Okay.";

  if (props.error) {
    header = "An error has occured";
    body = props.error;
  }

  if (props?.header) header = props.header;
  if (props?.body) body = props?.body;
  if (props?.buttonText) buttonText = props?.buttonText;

  return (
    <React.Fragment>
      <div onClick={props.onClose} className={styles.background} />

      <div className={styles.notification_body}>
        <h2>{header}</h2>
        <p>{body}</p>
        <div className={styles.notification_actions}>
          <button type="button" onClick={props.onClose}>
            {buttonText}
          </button>
        </div>
      </div>
    </React.Fragment>
  );
};

export default Notification;
