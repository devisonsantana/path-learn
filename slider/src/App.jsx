import { useEffect, useState } from "react";
import { Slider } from "./Slider";
import data from "./data";

export default function App() {
  const [people, setPeople] = useState(data);
  const [index, setIndex] = useState(0);

  useEffect(() => {
    const lastIndex = people.length - 1;
    if (index < 0) {
      setIndex(lastIndex);
    }
    if (index > lastIndex) {
      setIndex(0);
    }
  }, [index, people]);

  useEffect(() => {
    let slide = setInterval(() => {
      setIndex(index + 1);
    }, 5000);
    return () => clearInterval(slide);
  }, [index]);

  return (
    <section className="section">
      <div className="title">
        <h2>
          <span>/</span>
          reviews
        </h2>
      </div>
      <Slider people={people} index={index} setIndex={setIndex} />
    </section>
  );
}
