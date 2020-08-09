import { useState, useEffect } from "react";
import { RegisteredUserActions } from "./RegisteredUserUtils";

const allActions = { RegisteredUser: RegisteredUserActions };

let user = null;
let subscribers = [];
let userActions = [];
export const useUserStore = (subscriber = true) => {
  const setUser = useState(user)[1];
  const [error, setError] = useState("");
  const action = (actionName, actionPayload = null) => {
    return userActions[actionName](actionPayload)
      .catch((err) => {
        setError(err);
        throw new Error(err);
      })
      .then(userActions["GETLOGGEDUSER"])
      .then((newUser) => {
        user = newUser;
        subscribers.forEach((sub) => sub(user));
      }); // ACTION THEN GET LOGGED USER
  };

  useEffect(() => {
    if (subscriber) subscribers.push(setUser);

    return () => {
      if (subscriber)
        subscribers = subscribers.filter((sub) => sub !== setUser); // KILL ME\
    };
  }, [setUser, subscriber]);

  return {
    user,
    action,
    error,
  };
};

export const initStore = () => {
  try {
    userActions = { ...allActions["RegisteredUser"] };
    allActions["RegisteredUser"]
      ["GETLOGGEDUSER"]()
      .then((newUser) => (user = newUser));
    if (user) userActions = { ...userActions, ...allActions[user.Role] };
  } catch (Error) {
    user = null;
  }
};
