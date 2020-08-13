const GetChangedProperties = (obj1, obj2) => {
  let retVal = [];
  if (obj1 === obj2) return retVal;
  Object.entries(obj1).forEach((s) => {
    if (obj2[s[0]])
      if (obj2[s[0]] !== s[1]) retVal.push(s[0]);
      else retVal.push(s[0]);
  });
  return retVal;
};

const IfSubscribedPropChanged = (changedProperties, SubscribedProperties) => {
  return SubscribedProperties.some((prop) => changedProperties.includes(prop));
};

export const ShouldPublish = (oldValue, newValue, subscribed) => {
  if (subscribed.length === 0) return true;
  const changed = GetChangedProperties(oldValue, newValue);
  return IfSubscribedPropChanged(changed, subscribed);
};
