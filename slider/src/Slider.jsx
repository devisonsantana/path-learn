import { FiChevronLeft, FiChevronRight } from "react-icons/fi";
import { Card } from "./Card";

export function Slider({ people, index, setIndex }) {
  return (
    <div className="section-center">
      {people.map((person, personIndex) => {
        const { id, image, name, quote, title } = person;
        let position = "nextSlide";
        if (personIndex === index) {
          position = "activeSlide";
        }
        if (
          personIndex === index - 1 ||
          (index === 0 && personIndex === people.length - 1)
        ) {
          position = "lastSlide";
        }
        return <Card key={id} person={person} position={position} />;
      })}
      <button className="prev" onClick={() => setIndex(index - 1)}>
        <FiChevronLeft />
      </button>
      <button className="next" onClick={() => setIndex(index + 1)}>
        <FiChevronRight />
      </button>
    </div>
  );
}
