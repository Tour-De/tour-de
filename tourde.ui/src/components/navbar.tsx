import { Button, Container, Nav, Navbar } from "react-bootstrap"
import LoginButton from "@components/login";
import LogoutButton from "@components/logout";
import { useAuth0 } from "@auth0/auth0-react";
import { LinkContainer } from "react-router-bootstrap";

const NavBar = () => {
    const { isAuthenticated } = useAuth0();

    return (
        <Navbar collapseOnSelect className="p-3 nav-header">
            <Container>
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="me-auto">
                        <LinkContainer to="/"><Button className="btn-nav">Home</Button></LinkContainer>
                        <LinkContainer to="/leaderboards"><Button className="btn-nav">Leaderboards</Button></LinkContainer>
                        <LinkContainer to="/about"><Button className="btn-nav">About</Button></LinkContainer>
                        <LinkContainer to="/media"><Button className="btn-nav">Media</Button></LinkContainer>
                        <LinkContainer to="/join"><Button className="btn-nav">Join</Button></LinkContainer>
                        <LinkContainer to="/contact"><Button className="btn-nav">Contact</Button></LinkContainer>
                    </Nav>
                    <Nav className="gap-2">
                        {isAuthenticated ? 
                            <>
                                <LinkContainer to="/profile"><Button className="btn-nav">Profile</Button></LinkContainer>
                                <LogoutButton/>
                            </>:
                            <LoginButton/>
                        }
                    </Nav>
                </Navbar.Collapse>
            </Container>
        </Navbar>
    );
}

export default NavBar;