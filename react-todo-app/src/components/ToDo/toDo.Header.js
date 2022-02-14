import { Col, Container, Stack, InputGroup, Row, Image, ListGroupItem, ListGroup, Card, Button, Form } from "react-bootstrap";
import 'bootstrap/dist/css/bootstrap.min.css'
import cardimage from '../../assets/img/card.jpg'
import { useState } from "react";
import { useDispatch } from "react-redux";
import * as actions from "../../redux/actionsTypes"



function ToDoHeader({ props }) {
    const [title, setTitle] = useState("");
    const dispatch = useDispatch();
    const add = () => {
        dispatch({ type: actions.ADD_NEW_ITEM, payload: title })
        setTitle('')
    }

    return (
        <div>
            <Row>
                <Stack direction='horizontal'>
                    <Form.Control className="me-auto" onChange={(item) => setTitle(item.target.value)} value={title} placeholder="Add your item here..." />
                    <div className="vr" style={{ margin: '10px' }} />
                    <Button onClick={add} variant="primary">Ekle</Button>
                </Stack>
            </Row>

        </div>
    );
}

export default ToDoHeader;
