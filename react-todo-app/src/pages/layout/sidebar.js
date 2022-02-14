import { Button, Col, Container, Form, InputGroup, Row, Image } from "react-bootstrap";
import 'bootstrap/dist/css/bootstrap.min.css'
import SideBarCard from "../../components/SideBar/SideBarCard";
import * as styles from'./layout.styles.js' 

function SideBar() {
    return (
        <div >
            <Row>
                <Col>
                    <SideBarCard />
                </Col>
            </Row>
            <Row style={styles.sidebarDiv}>
                <Col>
                    <SideBarCard />
                </Col>
            </Row>
        </div>
    );
}

export default SideBar;
