import { Button, Col, Container, Form, InputGroup, Row, Image } from "react-bootstrap";
import 'bootstrap/dist/css/bootstrap.min.css'

import SideBar from "./layout/sidebar";
import ToDo from "../components/ToDo/toDo";

function MainPage() {
    return (
        <div>
            <Row>
                <Col md={9}>
                    <ToDo/>
                </Col>
                <Col md={3}>
                    <SideBar />
                </Col>
            </Row>
        </div>
    );
}

export default MainPage;
