import axios from 'axios';
import React, {useState, useEffect} from "react";
import TableContact from "./layout/TableContact/TableContact";
import FormContact from "./layout/FormContact/FormContact";
import { Route, Routes } from 'react-router-dom';
import ContactDetails from './layout/ContactDetails/ContactDetails';

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
    const item = {
      name: contactName,
      email: contactEmail
    };
  
    axios.post(url, item).then(
      res => setContacts([...contacts, res.data])
    );
  };

  const deleteContact = (id) => {
    axios.delete(`${url}/${id}`);
    setContacts(contacts.filter(item => item.id !== id));
  };
  
  return (
    <div className="container mt-5">
      <Routes>
        <Route path='/' element={
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
        } />
        <Route path='contact/:id' element={<ContactDetails/>} />
      </Routes>
    </div>
  );
}

export default App;
