import {
  Accordion,
  AccordionContent,
  AccordionItem,
  AccordionTrigger,
} from "@/components/ui/accordion";
import SpaceViewer from "./SpaceViewer";
import isEmpty from "@/lib/utility";

const DataViewer = (props) => {
  const data = props?.data;
  return isEmpty(data) ? (
    <div className="justify-start">
      <h3>Data not Available</h3>
    </div>
  ) : (
    <div>
      <Accordion type="Multiple" collapsible="true">
        <AccordionItem value={data?.PropertyId}>
          <AccordionTrigger>{data?.PropertyName}</AccordionTrigger>
          <AccordionContent>
            <p className="py-2">
              <span className="font-bold py-2">Highlights: </span>
              {data?.Highlights.join(", ")}
            </p>
            <p className="py-2">
              <span className="font-bold py-2">Features: </span>
              {data?.Features.join(", ")}
            </p>
            <p className="py-2">
              <span className="font-bold py-2">Transportation: </span>
              {data?.Transportation.reduce(
                (acc, transport, index) =>
                  `${acc} ${
                    transport.Line ? transport.Line : transport.Station
                  } (${transport.Distance})${
                    index == data?.Transportation.length - 1 ? "" : ","
                  }`,
                ""
              )}
            </p>
            <div className="py-2">
              <span className="font-bold py-2">Spaces: </span>
              {data?.Spaces.map((space) => {
                return (
                  <div key={space.SpaceId}>
                    <SpaceViewer space={space} />
                  </div>
                );
              })}
            </div>
          </AccordionContent>
        </AccordionItem>
      </Accordion>
    </div>
  );
};

export default DataViewer;
