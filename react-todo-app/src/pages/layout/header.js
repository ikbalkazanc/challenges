import { Button, Col, Container, Form, InputGroup, Row,Image } from "react-bootstrap";
import 'bootstrap/dist/css/bootstrap.min.css'
import logo from '../../assets/img/Trendyol_online.png';
import Nav from "../../components/Header/navBar";
import NavBarSlider from "../../components/Header/navBarSlider"
import * as styles from'./layout.styles.js' 

function Header({ number }) {
  return (

    <div>
      <Container>
      <Row>
        <div style={styles.headerEmpty}></div>
      </Row>
      <Row >
        <Col md={1} >
        <img style={styles.headerImage} src={logo} alt="Logo" />
        </Col>
        <Col md={1}></Col>
        <Col md={6} >
          <InputGroup>
            <Form.Control placeholder="Search" />
          </InputGroup>
        </Col>
        <Col md={1}></Col>
        <Col md={3  } >
          

        <Button style={styles.headerButton} variant="primary">Giriş Yasp </Button>
        <Button style={styles.headerButton}  variant="danger">Favoriler</Button>
        <Button style={styles.headerButton}  variant="warning">Sepetim</Button>

        </Col>
      </Row>
      <Row style={styles.headerNav}>
        <Nav/>
      </Row>
      
      </Container>
      <hr></hr>
      <Container>
      <Row style={styles.headerNav}>
        <NavBarSlider/>
      </Row>
      </Container>
    </div>
    

  );
}

export default Header;
