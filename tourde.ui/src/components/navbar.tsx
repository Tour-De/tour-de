import { Button, Container, Nav, Navbar } from "react-bootstrap"
import LoginButton from "@components/login";
import LogoutButton from "@components/logout";
import { useAuth0 } from "@auth0/auth0-react";
import { LinkContainer } from "react-router-bootstrap";

const NavBar = () => {
    const { isAuthenticated } = useAuth0();

    return (
        <Navbar collapseOnSelect className="p-3">
            <Container>
                <Navbar.Collapse id="basic-navbar-nav">
                    <Nav className="me-auto">
                        <LinkContainer to="/"><Button>Home</Button></LinkContainer>
                        <LinkContainer to="/leaderboards"><Button>Leaderboards</Button></LinkContainer>
                        <LinkContainer to="/about"><Button>About</Button></LinkContainer>
                        <LinkContainer to="/media"><Button>Media</Button></LinkContainer>
                        <LinkContainer to="/join"><Button>Join</Button></LinkContainer>
                        <LinkContainer to="/contact"><Button>Contact</Button></LinkContainer>
                    </Nav>
                    <Nav className="gap-2">
                        {isAuthenticated ? 
                            <>
                                <LinkContainer to="/profile"><Button>Profile</Button></LinkContainer>
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