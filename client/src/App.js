import axios from 'axios';
import React, {useState, useEffect} from "react";
import TableContact from "./layout/TableContact/TableContact";
import FormContact from "./layout/FormContact/FormContact";

const baseApiUrl = process.env.REACT_APP_API_URL;

const App = () => {
  const url = `${baseApiUrl}/ContactManagement/contacts`;

  const [contacts, setContacts] = useState([]);

  useEffect( () => {
    axios.get(url).then(
      res => setContacts(res.data)
    );
  }, []);
  
  const addContact = (contactName, contactEmail) => {
    const newId = Math.max(0, ...contacts.map(el => el.id)) + 1;

    const item = {
      id: newId,
      name: contactName,
      email: contactEmail
    };
  
    axios.post(url, item);
    setContacts([...contacts, item]);
  };

  const deleteContact = (id) => {
    axios.delete(`${url}/${id}`);
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
