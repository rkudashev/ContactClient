import React, { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import axios from "axios";

const baseApiUrl = window.config.apiUrl;

const ContactDetails = (props) => {
    const [contact, setContact] = useState({name: "", email: ""});
    const {id} = useParams();
    const navigate = useNavigate();

    useEffect(() => {
        const url = `${baseApiUrl}/contacts/${id}`;
        axios.get(url).then(
            response => {
                setContact(response.data);
            }
        ).catch(
            err => {
                navigate("/");
            }
        )
    }, [id, navigate]);

    const goBack = () => {
        navigate("/");
    };

    const deleteContact = async (id) => {
        const url = `${baseApiUrl}/contacts`;
        await axios.delete(`${url}/${id}`).then(() => {
            props.onUpdate();
        });

        goBack();
    };

    const updateContact = async (id) => {
        const url = `${baseApiUrl}/contacts`;
        await axios.put(`${url}/${id}`, contact).then(() => {
            props.onUpdate();
        });
        goBack();
        
    };

    return (
        <div className="container mt-5">
            <h2>Детали контакта</h2>
            <div className="mb-3">
                <label className="form-label">Имя:</label>
                <input 
                    className="form-control"
                    value={contact.name}
                    type="text"
                    onChange={(e) => { setContact({...contact, name: e.target.value}) }}
                />
            </div>
            <div className="mb-3">
                <label className="form-label">Email:</label>
                <input 
                    className="form-control"
                    value={contact.email}
                    type="email"
                    onChange={(e) => { setContact({...contact, email: e.target.value}) }}
                />
            </div>
            <button 
                className="btn btn-primary me-2" onClick={(e) => { updateContact(id); }}>
                Обновить
            </button>

            <button 
                className="btn btn-danger me-2" onClick={(e) => {deleteContact(id);}}>
                Удалить
            </button>

            <button 
                className="btn btn-secondary me-2" onClick={(e) => { goBack() }}>
                Назад
            </button>
        </div>
    );
}

export default ContactDetails;