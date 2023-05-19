import { useAuth0 } from "@auth0/auth0-react";
import Button from "react-bootstrap/esm/Button";
import { LinkContainer } from "react-router-bootstrap";

const LoginButton = () => {
  const { loginWithRedirect } = useAuth0();

  const login = () => {
    loginWithRedirect({
      appState: {
        returnTo: window.location.pathname
      }
    });
  }

  return (
    <LinkContainer to="">
      <Button className="btn-nav" onClick={login}>Log In/Sign Up</Button>
    </LinkContainer>
  );
};



export default LoginButton;