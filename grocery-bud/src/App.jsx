import { useState, useEffect } from "react";
import Alert from "./Alert";
import List from "./List";

const getLocalStorage = () => {
  let list = localStorage.getItem("list");
  if (list) {
    return JSON.parse(list);
  } else {
    return [];
  }
};

function App() {
  const [name, setName] = useState("");
  const [list, setList] = useState(getLocalStorage());
  const [isEditing, setIsEditing] = useState(false);
  const [editID, setEditID] = useState(null);
  const [alert, setAlert] = useState({
    show: false,
    msg: "",
    type: "",
  });

  const handleSubmit = (e) => {
    e.preventDefault();
    if (!name) {
      showAlert(true, "please enter value", "danger");
    } else if (name && isEditing) {
      const updatedList = list.map((item) =>
        item.id === editID ? { ...item, title: name } : item,
      );
      showAlert(true, "value changed", "success");
      setIsEditing(false);
      setEditID(null);
      setName("");
      setList(updatedList);
    } else {
      showAlert(true, "item added to the list", "success");
      const newItem = {
        id: crypto.randomUUID(),
        title: name,
      };
      setList([...list, newItem]);
      setName("");
    }
  };

  const showAlert = (show = false, msg = "", type = "") => {
    setAlert({ show, msg, type });
  };
  const removeItem = (id) => {
    const newList = list.filter((item) => item.id !== id);
    showAlert(true, "item removed", "danger");
    setList(newList);
  };
  const editItem = (id) => {
    const especifItem = list.find((item) => item.id === id);
    setIsEditing(true);
    setEditID(id);
    setName(especifItem.title);
  };
  const clearList = () => {
    showAlert(true, "empty list", "danger");
    setList([]);
  };

  useEffect(() => {
    localStorage.setItem("list", JSON.stringify(list));
  }, [list]);
  return (
    <section className="section-center">
      <form className="grocery-form" onSubmit={handleSubmit}>
        {alert.show && <Alert {...alert} removeAlert={showAlert} list={list} />}
        <h3>grocery bud</h3>
        <div className="form-control">
          <input
            type="text"
            className="grocery"
            placeholder="e.g. eggs"
            value={name}
            onChange={(e) => setName(e.target.value)}
          />
          <button type="submit" className="submit-btn">
            {isEditing ? "edit" : "submit"}
          </button>
        </div>
      </form>
      {list.length > 0 && (
        <div className="grocery-container">
          <List items={list} removeItem={removeItem} editItem={editItem} />
          <button className="clear-btn" onClick={clearList}>
            clear items
          </button>
        </div>
      )}
    </section>
  );
}

export default App;
