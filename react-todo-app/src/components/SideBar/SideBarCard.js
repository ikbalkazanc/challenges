import { Button, Col, Container, Form, InputGroup, Row, Image, ListGroupItem, ListGroup, Card } from "react-bootstrap";
import navbar from "../../data/navbar"
import 'bootstrap/dist/css/bootstrap.min.css'
import cardimage from '../../assets/img/card.jpg'


function SideBarCard() {
    return (
        <Row>
            <Col>
                <Card style={{ width: '18rem' }}>
                   <img src={cardimage} style={{}}/>
                    <Card.Body>
                        <Card.Title>Card Title</Card.Title>
                        <Card.Text>
                            Some quick example text to build on the card title and make up the bulk of
                            the card's content.
                        </Card.Text>
                    </Card.Body>
                </Card>
            </Col>
        </Row>
    );
}

export default SideBarCard;
