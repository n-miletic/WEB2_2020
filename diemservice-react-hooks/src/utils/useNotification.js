import React, { useState, useEffect } from "react";
import Notification from "./NotificationComponent/Notification";
let props = {};
const useNotification = () => {
  console.log("usenotification called");
  const [active, setActive] = useState(false);
  const [notification, setNotification] = useState(null);

  useEffect(() => {
    console.log("useffect called");
    if (active) setNotification(<Notification {...props} />);
    return () => {
      props = {};
      setNotification(null);
    };
  }, [active, props]);
  const Notify = ({
    error = null,
    header = null,
    body = null,
    buttonText = null,
    onCloseHandler = () => {},
  }) => {
    const onClose = () => {
      console.log("closing");
      onCloseHandler();
      setActive(false);
    };
    props = { error, header, body, buttonText, onClose };
    setActive(true);
  };
  return {
    notification,
    Notify,
  };
};

export default useNotification;
