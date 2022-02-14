import { Button, Col, Container, Form, InputGroup, Row,Image } from "react-bootstrap";
import navbar from "../../data/navbar"
import 'bootstrap/dist/css/bootstrap.min.css'


function Nav() {
  return (
    <Row>
      {navbar.map((item,key) => {

          return (<Col key={key}>
          {item} 
          </Col>)
      })}
    </Row>
  );
}

export default Nav;
