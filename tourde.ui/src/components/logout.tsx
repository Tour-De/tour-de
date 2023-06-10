import { useAuth0 } from '@auth0/auth0-react';
import { Button } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';

const LogoutButton = () => {
  const { logout } = useAuth0();

  return (
    <LinkContainer to="">
      <Button
        className="btn-nav"
        onClick={() =>
          logout({ logoutParams: { returnTo: window.location.origin } })
        }
      >
        Log Out
      </Button>
    </LinkContainer>
  );
};

export default LogoutButton;
