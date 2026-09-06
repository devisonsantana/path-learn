import { Copy } from "lucide-react";
import { useEffect, useState } from "react";
import { rgbToHex } from "./utils";

export const SingleColor = ({ rgb, weight, index }) => {
  const [alert, setAlert] = useState(false);

  const className = `color ${index > 10 ? "color-light" : ""}`;
  const hexValue = rgbToHex(...rgb);

  const copyToClipboard = () => {
    navigator.clipboard.writeText(hexValue);
    setAlert(true);
  };

  useEffect(() => {
    const timeout = setTimeout(() => {
      setAlert(false);
    }, 3000);
    return () => clearTimeout(timeout);
  }, [alert]);

  return (
    <article
      className={className}
      style={{ background: `rgb(${rgb.join(", ")})` }}
    >
      <p className="percent-value">{weight}%</p>
      <p className="color-value">{hexValue}</p>

      <Copy className="copy-icon" size={18} onClick={copyToClipboard} />

      {alert && <p className="alert">copied to clipboard</p>}
    </article>
  );
};
