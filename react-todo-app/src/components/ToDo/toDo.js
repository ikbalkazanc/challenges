import { Card } from "react-bootstrap";
import 'bootstrap/dist/css/bootstrap.min.css'
import ToDoHeader from "./toDo.Header";
import { connect } from "react-redux";

import ToDoListItem from "./toDoListItem";


const mapStateToProps = function (state) {
    return { todos: state.ToDoApp.todoItems,changes:state.ToDoApp.changes }
}

function ToDo({ todos,changes }) {
    return (
        <div>
            <Card
                bg={'light'} 
                text={'sadasd'}
                style={{ width: '100%' }}
                className="mb-2"
            >
                <Card.Header><ToDoHeader /></Card.Header>
                {todos.map((val, i) => {
                    
                    return (
                      <ToDoListItem todo={val}  index={i}/>
                    )
                })}
            </Card>
        </div>
    );
}

export default connect(mapStateToProps)(ToDo);
