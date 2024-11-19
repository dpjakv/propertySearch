import {
  Accordion,
  AccordionContent,
  AccordionItem,
  AccordionTrigger,
} from "@/components/ui/accordion";

const SpaceViewer = (props) => {
  const space = props?.space;

  return (
    <div>
      <Accordion type="multiple" collapsible="true">
        <AccordionItem value={space.SpaceId}>
          <AccordionTrigger>{space.SpaceName}</AccordionTrigger>
          <AccordionContent className="flex flex-col grid-cols-2">
            {space.RentRoll.map((roll, index) => {
              return (
                <div key={index} className="">
                  {roll.Month}: {roll.Rent}
                </div>
              );
            })}
          </AccordionContent>
        </AccordionItem>
      </Accordion>
    </div>
  );
};

export default SpaceViewer;
