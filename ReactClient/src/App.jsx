import { useEffect, useState } from "react";
import Header from "./components/Header";
import DataViewer from "./components/DataViewer";
import isEmpty from "./lib/utility";
import fetchProperties from "./services/propertyService";

function App() {
  const [jsonResponse, setJsonResponse] = useState({});

  useEffect(() => {
    // API Call
    async function fetchData() {
      let response = await fetchProperties();
      setJsonResponse(response);
    }

    fetchData();
  }, []);

  return (
    <>
      <div className="w-full justify-center">
        <Header />
        <div className="w-9/12 px-5">
          {isEmpty(jsonResponse) ? (
            <div>Data Loading</div>
          ) : (
            jsonResponse.map((property) => {
              return (
                <div key={property.PropertyId}>
                  <DataViewer data={property} />{" "}
                </div>
              );
            })
          )}
        </div>
      </div>
    </>
  );
}

export default App;
