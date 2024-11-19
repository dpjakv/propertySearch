const fetchProperties = async () => {
  let jsonResponse = await fetch("https://localhost:7190/Properties");
  jsonResponse = await jsonResponse.json();
  return jsonResponse;
};

export default fetchProperties;
