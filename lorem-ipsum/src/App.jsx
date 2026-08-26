import { useState } from "react";
import data from "./data";

export default function App() {
  const [count, setCount] = useState(1);
  const [text, setText] = useState([]);

  const handleChange = (e) => {
    setCount(() => {
      let amount = parseInt(e.target.value);
      if (amount > data.length) {
        return data.length;
      }
      if (amount <= 0) {
        return 1;
      }
      return amount;
    });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    setText(data.slice(0, count));
  };

  return (
    <section className="section-center">
      <h3>tired of boring lorem ipsum?</h3>
      <form className="lorem-form" onSubmit={handleSubmit}>
        <label htmlFor="amount">paragraphs:</label>
        <input
          type="number"
          name="amount"
          id="amount"
          value={count}
          onChange={handleChange}
        />
        <button type="submit" className="btn">
          generate
        </button>
      </form>
      <article className="lorem-text">
        {text.map((paragraph, index) => (
          <p key={index}>{paragraph}</p>
        ))}
      </article>
    </section>
  );
}
