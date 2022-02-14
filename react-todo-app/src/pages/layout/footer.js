import { Button, Col, Container, Form, InputGroup, Row,Image } from "react-bootstrap";
import 'bootstrap/dist/css/bootstrap.min.css'
import FooterDescription from '../../components/Footer/footerDescription'
import * as styles from'./layout.styles.js' 
function Footer() {
  return (
    <div  style={styles.footerColor}>
        <hr></hr>
      <Container>
      <Row >
          <Col md={2}>
          </Col>
          <Col md={3}>
             <FooterDescription/>
          </Col>
          <Col md={3}>
             <FooterDescription/>
          </Col>
          <Col md={3}>
             <FooterDescription/>
          </Col>
          <Col md={2}>
          </Col>
      </Row>
      <Row  style={styles.footer}></Row>
      </Container>
    </div>
    

  );
}

export default Footer;
