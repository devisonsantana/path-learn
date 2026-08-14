import { useState } from "react";

export default function Categories({ filterItems }) {
  const [active, setActive] = useState(0);
  return (
    <div className="btn-container">
      <button
        className={`filter-btn ${active === 0 && "active"}`}
        onClick={() => {
          filterItems("all");
          setActive(0);
        }}
      >
        all
      </button>
      <button
        className={`filter-btn ${active === 1 && "active"}`}
        onClick={() => {
          filterItems("breakfast");
          setActive(1);
        }}
      >
        breakfast
      </button>
      <button
        className={`filter-btn ${active === 2 && "active"}`}
        onClick={() => {
          filterItems("lunch");
          setActive(2);
        }}
      >
        lunch
      </button>
      <button
        className={`filter-btn ${active === 3 && "active"}`}
        onClick={() => {
          filterItems("shakes");
          setActive(3);
        }}
      >
        shakes
      </button>
    </div>
  );
}
