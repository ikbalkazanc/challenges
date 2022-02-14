import { Button, Col, Container, Form, InputGroup, Row,Image } from "react-bootstrap";

import 'bootstrap/dist/css/bootstrap.min.css'
import cardimage from '../../assets/img/card.jpg'
import * as styles from './header.style'


function NavbarCircle({text}) {
  return (
   <div>
       <Row className="justify-content-md-center">
           <Col>
            <img  src={cardimage} style={styles.circle}/>
            </Col>
       </Row>
       <Row className="justify-content-center">
            <Col className="justify-content-md-center">
            <p style={{textAlign: 'center'}}>{text}</p>
            </Col>
       </Row>
   </div>
  );
}

export default NavbarCircle;
