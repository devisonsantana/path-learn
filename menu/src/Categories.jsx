import { useState } from "react";

export default function Categories({ categories, filterItems }) {
  const [active, setActive] = useState(0);
  return (
    <div className="btn-container">
      {categories.map((category, index) => {
        return (
          <button
            key={index}
            type="button"
            className={`${active === index ? "filter-btn active" : "filter-btn"}`}
            onClick={() => {
              filterItems(category);
              setActive(index);
            }}
          >
            {category}
          </button>
        );
      })}
    </div>
  );
}
