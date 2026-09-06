import { useState } from "react";
import Values from "values.js";
import { SingleColor } from "./SingleColor";

export default function App() {
  const initialValues = new Values("#3ae6cc").all(10);
  const [color, setColor] = useState("");
  const [error, setError] = useState(false);
  const [list, setList] = useState(initialValues);

  const handleSubmit = (e) => {
    e.preventDefault();
    try {
      let colors = new Values(color).all(10);
      setList(colors);
      setError(false);
    } catch (error) {
      setError(true);
      console.log(error);
    }
  };

  return (
    <>
      <section className="container">
        <h3>color generator</h3>
        <form onSubmit={handleSubmit}>
          <input
            type="text"
            value={color}
            onChange={(e) => setColor(e.target.value)}
            placeholder="#3ae6cc"
            className={error ? "error" : ""}
          />
          <button className="btn">submit</button>
        </form>
      </section>
      <section className="colors">
        {list.map((color, index) => (
          <SingleColor key={index} index={index} {...color} />
        ))}
      </section>
    </>
  );
}
