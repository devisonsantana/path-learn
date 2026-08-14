import { useState } from "react";
import Menu from "./Menu";
import items from "./data";

export default function App() {
  const [menuItems, setMenuItems] = useState(items);
  return (
    <main>
      <section className="menu section">
        <div className="title">
          <h2>our menu</h2>
          <div className="underline" />
        </div>
        <Menu items={menuItems} />
      </section>
    </main>
  );
}
