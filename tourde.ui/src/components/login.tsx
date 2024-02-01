import { useAuth0 } from '@auth0/auth0-react';
import { Person } from '@models/person';
import { PersonApiRoutes } from '@util/constants';
import { useEffect } from 'react';
import Button from 'react-bootstrap/esm/Button';
import { LinkContainer } from 'react-router-bootstrap';

const LoginButton = () => {
  const { loginWithRedirect, logout, user, isAuthenticated } = useAuth0()

  const onLogin = async () => {
    await loginWithRedirect({
      appState: { returnTo: window.location.pathname }
    })
  }

  const onLogout = () => {
    logout({ 
      logoutParams: { returnTo: window.location.origin } 
    })
  }

  let buttonText = isAuthenticated ? 'Logout' : 'Log In/Sign Up'
  let onClick = isAuthenticated ? onLogout : onLogin

  return (
    <>
      {isAuthenticated ? 
        <LinkContainer to="/profile">
          <Button className="btn-nav">Profile</Button>
        </LinkContainer> :
        <></>
      }
      <LinkContainer to="">
        <Button className="btn-nav" onClick={onClick}>
          {buttonText}
        </Button>
      </LinkContainer>
    </>
  )
}

export default LoginButton