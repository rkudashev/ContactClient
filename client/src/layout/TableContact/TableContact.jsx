import React from "react"
import RowTableContact from "./components/RowTableContact";

const TableContact = (props) => {
  const contacts = props.contacts;
  return(
    <table className="table table-hover">
      <thead>
        <tr>
          <th>#</th>
          <th>Имя контакта</th>
          <th>E-mail</th>
        </tr>
      </thead>
      <tbody>
        {
          contacts.map(
            contact => (
              <RowTableContact 
                key={contact.id}
                id={contact.id}
                name={contact.name}
                deleteContact={props.deleteContact}
                email={contact.email} />
            )
          )
        }
      </tbody>
    </table>
  )
};

export default TableContact;