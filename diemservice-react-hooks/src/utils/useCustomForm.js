import { useState, useEffect } from "react";

const useCustomForm = ({
  initialValues = null,
  customFormValidation = () => {},
  onSubmit,
}) => {
  // WHY {}
  const [values, setValues] = useState(initialValues);
  const [errors, setErrors] = useState({});
  const [serverError, setServerError] = useState("");

  useEffect(() => {
    setValues(initialValues);
  }, []);

  const handleChange = (event) => {
    const { target } = event;
    const { name, value } = target;
    event.persist(); // SET STATE JE ASINHRON, DA BISMO SE OSIGURALI
    customFormValidation({ target, name, value });
    setValues({ ...values, [name]: value });
  };

  const handleSubmit = (event) => {
    if (event) event.preventDefault();
    setErrors({ ...errors });
    onSubmit().catch((err) => {
      setServerError(err.message);
    });
  };

  return {
    values,
    errors,
    serverError,
    handleChange,
    handleSubmit,
  };
};

export default useCustomForm;
