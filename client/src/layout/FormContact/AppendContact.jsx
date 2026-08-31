import FormContact from "./FormContact";
import axios from "axios";
import { useNavigate } from "react-router-dom";

const baseApiUrl = window.config.apiUrl;

const AppendContact = () => {
    const navigate = useNavigate();
    const url = `${baseApiUrl}/contacts`;
    
    const addContact = (contactName, contactEmail) => {
    
        const item = {
          name: contactName,
          email: contactEmail
        };
      
        axios.post(url, item)
            .then(
                () => { navigate("/"); }
            )
      };

    return (
        <div className="card">
            <div className="card-header">
                <h1>Добавить контакт</h1>
            </div>
            <div className="card-body">
                <FormContact addContact={addContact}/>
            </div>
        </div>
    );
}

export default AppendContact;