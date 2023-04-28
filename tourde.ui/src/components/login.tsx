import { useAuth0 } from "@auth0/auth0-react";
import Button from "react-bootstrap/esm/Button";
import { LinkContainer } from "react-router-bootstrap";

const LoginButton = () => {
  const { loginWithRedirect } = useAuth0();

  return (
    <LinkContainer to="">
      <Button onClick={() => loginWithRedirect()}>Log In/Sign Up</Button>
    </LinkContainer>
  );
};

export default LoginButton;