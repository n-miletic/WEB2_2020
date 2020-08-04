import React, { useState, useEffect } from "react";
import { useQuery, queryCache } from "react-query";

const useLoggedUser = () => {
  const [userToken, setUserToken] = useState(
    localStorage.getItem("loggedUserToken")
  );
  const getLoggedUser = () => {
    return fetch("/DiemApi/User/GetLogged", {
      headers: {
        Authorization: "Bearer " + getToken(),
      },
    }).then((res) => {
      if (res.status != 200) {
        throw new Error(res.statusText);
      }
      return res.json();
    });
  };
  const { data: user, error: userError, isLoading: userLoading } = useQuery(
    "User",
    getLoggedUser,
    {
      onError: (err) => {
        console.log(err);
      },
      enabled: userToken,

      initialData: { Role: "Guest" },
    }
  );
  useEffect(() => {
    queryCache.invalidateQueries("User"); // DELUXE SELJANCURA?
    if (!userToken) {
      queryCache.setQueryData("User", { Role: "Guest" });
    }
    localStorage.setItem("loggedUserToken", userToken);
  }, [userToken]); // GOOD OR JUST REALLY STUPID?

  const logIn = (userCredentials) => {
    return fetch("/DiemApi/User/SignIn", {
      method: "post",
      body: JSON.stringify(userCredentials),
      headers: {
        "Content-Type": "application/json",
      },
    }).then((res) => {
      if (res.status != 200) {
        throw new Error(res.statusText);
      }
      return res.json();
    });
  };
  const getToken = () => {
    return userToken;
  };
  const setToken = (token) => {
    setUserToken(token);
  };

  const removeToken = () => {
    setUserToken("");
  };

  const logUserIn = (userCredentials) => {
    return logIn(userCredentials).then((token) => setToken(token));
  };
  const logOut = () => {
    removeToken();
  };

  return {
    user,
    userError,
    userLoading,
    logUserIn,
    logOut,
  };
};

export default useLoggedUser;
