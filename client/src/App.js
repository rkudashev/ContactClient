import React, {useState} from "react";
import TableContact from "./layout/TableContact/TableContact";



const App = () => {
  const [contacts, setContacts] = useState(
    [
      {id: 1, name: "Yasya1", email: "pac1@nigga.com"},
      {id: 2, name: "Yasya2", email: "pac2@nigga.com"},
      {id: 3, name: "Yasya3", email: "pac3@nigga.com"},
      {id: 4, name: "Yasya4", email: "pac4@nigga.com"},
      {id: 5, name: "Yasya5", email: "pac5@nigga.com"},
      {id: 6, name: "Yasya6", email: "pac6@nigga.com"},
    ]
  );
  
  const addContact = () => {
    const item = {
      id: 2,//contacts[-1].id + 1,
      name: "Varlam",
      email: "varlam@pec.ng"
    };
  
    setContacts([...contacts, item]);
    console.log(contacts);
  };
  
  return (
    <div className="container mt-5">
      <div className="card">
        <div className="card-header">
          <h1>Список контактов</h1>
        </div>

        <div className="card-body">
          <TableContact contacts={contacts}/>
          <div>
            <button className="btn btn-primary"
                    onClick={() => {addContact()}}>
              Добавить контакт
            </button>
          </div>
        </div>
      </div>
    </div>
  );
}

export default App;
