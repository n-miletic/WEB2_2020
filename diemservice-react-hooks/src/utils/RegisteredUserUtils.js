export const RegisteredUserActions = {
  LOGIN: logUserIn,
  LOGOUT: logOut,
  GETLOGGEDUSER: getLoggedUser,
  EDITUSER: editUser,
  SIGNUP: signUp,
};

function signUp(values) {
  return fetch("/DiemApi/User/Register", {
    method: "post",
    body: JSON.stringify(values),
    headers: {
      "Content-Type": "application/json",
    },
  }).then((res) => {
    if (res.status !== 200) {
      return Promise.reject(res.statusText);
    }
  });
}
function editUser(token) {
  if (!token) return null;
  return fetch("/DiemApi/User/Edit", {
    headers: {
      Authorization: "Bearer " + getToken(),
    },
  }).then((res) => {
    if (res.status !== 200) {
      throw new Error(res.statusText);
    }
    return res.json();
  });
}

function getLoggedUser() {
  return loggedUserRequest(getToken()).catch((err) => {
    removeToken();
    return null;
  });
}

function logUserIn(userCredentials) {
  return logIn(userCredentials).then((token) => setToken(token));
}

function logOut() {
  removeToken();
  return Promise.resolve(null);
}

const loggedUserRequest = (token) => {
  if (!token) return Promise.reject();
  return fetch("/DiemApi/User/GetLogged", {
    headers: {
      Authorization: "Bearer " + token,
    },
  }).then((res) => {
    if (res.status !== 200) {
      throw new Error(res.statusText);
    }
    return res.json();
  });
};

function logIn(userCredentials) {
  return fetch("/DiemApi/User/SignIn", {
    method: "post",
    body: JSON.stringify(userCredentials),
    headers: {
      "Content-Type": "application/json",
    },
  }).then((res) => {
    if (res.status !== 200) {
      return Promise.reject(res.statusText);
    }
    return res.json();
  });
}

const getToken = () => {
  return localStorage.getItem("loggedUserToken");
};

const setToken = (userToken) => {
  localStorage.setItem("loggedUserToken", userToken);
};

const removeToken = () => {
  localStorage.clear();
};
