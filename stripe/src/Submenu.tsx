import { useEffect, useRef, useState } from "react";
import { useGlobalContext } from "./useGlobalContext";

function Submenu() {
  const {
    isSubmenuOpen,
    location,
    page: { page, links },
  } = useGlobalContext();
  const container = useRef<HTMLElement | null>(null);
  const [columns, setColumns] = useState("col-2");

  useEffect(() => {
    setColumns("col-2");
    if (location && container.current) {
      const submenu = container.current;
      const { center, bottom } = location;
      submenu.style.left = `${center}px`;
      submenu.style.top = `${bottom}`;
      if (links.length === 3) {
        setColumns("col-3");
      }
      if (links.length > 3) {
        setColumns("col-4");
      }
    }
  }, [location, links]);

  return (
    <aside className={`submenu ${isSubmenuOpen ? "show" : ""}`} ref={container}>
      <h4>{page}</h4>
      <div className={`submenu-center ${columns}`}>
        {links.map((link, idx) => {
          const { label, url, icon } = link;
          return (
            <a key={idx} href={url}>
              {icon}
              {label}
            </a>
          );
        })}
      </div>
    </aside>
  );
}

export default Submenu;
