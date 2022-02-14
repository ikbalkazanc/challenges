import { Button, Col, Container, Form, InputGroup, Row, Image, Navbar } from "react-bootstrap";
import circles from '../../data/navcircles'
import 'bootstrap/dist/css/bootstrap.min.css'
import NavbarCircle from "./navBarCircle";



function NavbarSlider() {
    return (
        <div>
            <Row>
                {circles.map((item) => {
                    return (
                        <Col>
                            <NavbarCircle text={item} />
                        </Col>
                    )
                })}
                
            </Row>
        </div>
    );
}

export default NavbarSlider;
