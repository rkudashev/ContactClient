import axios from 'axios';
import React, {useState} from "react";
import TableContact from "./layout/TableContact/TableContact";
import FormContact from "./layout/FormContact/FormContact";

const baseApiUrl = process.env.REACT_APP_API_URL;

const App = () => {
  const url = `${baseApiUrl}/ContactManagement/contacts`;

  axios.get(url).then(
    res => {console.log(res.data)}
  )

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
  
  const addContact = (contactName, contactEmail) => {
    const newId = Math.max(0, ...contacts.map(el => el.id)) + 1;

    const item = {
      id: newId,
      name: contactName,
      email: contactEmail
    };
  
    setContacts([...contacts, item]);
  };

  const deleteContact = (id) => {
    setContacts(contacts.filter(item => item.id !== id));
  };
  
  return (
    <div className="container mt-5">
      <div className="card">
        <div className="card-header">
          <h1>Список контактов</h1>
        </div>

        <div className="card-body">
          <TableContact contacts={contacts}
                        deleteContact={deleteContact}/>
          <FormContact addContact={addContact}/>
        </div>
      </div>
    </div>
  );
}

export default App;
