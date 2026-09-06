import { useState } from "react";
import { rgbToHex } from "./utils";

export const SingleColor = ({ rgb, weight, index }) => {
  const [alert, setAlert] = useState(false);

  const className = `color ${index > 10 ? "color-light" : ""}`;
  const hexValue = rgbToHex(...rgb);

  return (
    <article
      className={className}
      style={{ background: `rgb(${rgb.join(", ")})` }}
    >
      <p className="percent-value">{weight}%</p>
      <p className="color-value">{hexValue}</p>
    </article>
  );
};
