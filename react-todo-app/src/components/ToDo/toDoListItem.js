import { Col, Container, Stack, InputGroup, Row, Image, Alert, ListGroupItem, ListGroup, Card, Button, Form } from "react-bootstrap";
import 'bootstrap/dist/css/bootstrap.min.css'

import { useDispatch } from "react-redux";
import * as actions from "../../redux/actionsTypes"



function ToDoListItem({ todo, index }) {
    const dispatch = useDispatch();
    
    const switchState = () => {
        dispatch({ type: actions.COMPLETE_ITEM, payload: todo.id })
    }
    const removeItem = () => {
        dispatch({ type: actions.REMOVE_ITEM, payload: todo.id })
    }
        return (
        <Alert key={index} variant={todo.isComplated ? 'success' : 'warning'} style={{ margin: '0px 0px 0px 0px' }}>
            <Stack direction="horizontal" gap={3}>
                <div >
                  <h4>
                        {index+1}. {todo.title} (id:{ todo.id})
                        
                        </h4>
                </div>
                <span className="ms-auto"></span>
                <div className="vr" />
                <Button onClick={() => {switchState()}} variant="primary">{todo.isComplated ? 'Geri Al' : 'Tamamla'}</Button>
                <Button  onClick={() => {removeItem()}} variant="danger">Sil</Button>
            </Stack>
        </Alert>


    );
}

export default ToDoListItem;
