import { useAuth0 } from '@auth0/auth0-react';
import { useEffect } from 'react';
import { ApplicationUser } from '../models/person';
import { Button } from '@mui/material';
import { login } from '../providers/identity_api';

const LoginButton = () => {
  const {
    loginWithRedirect,
    logout,
    isAuthenticated,
    getAccessTokenSilently,
    user,
  } = useAuth0();

  useEffect(() => {
    const userLoggedIn = async () => {
      let token = await getAccessTokenSilently();
      let appUser = new ApplicationUser(
        '',
        user!.email!,
        user!.tourde_first_name!,
        user!.tourde_last_name!,
        user!.email!
      );
      await login(token, appUser);
    };

    if (isAuthenticated && user) {
      userLoggedIn();
    }
  }, [isAuthenticated, user]);

  const onLogin = async () => {
    await loginWithRedirect({
      appState: { returnTo: window.location.pathname },
    });
  };

  const onLogout = () => {
    logout({
      logoutParams: { returnTo: window.location.origin },
    });
  };

  let buttonText = isAuthenticated ? 'Logout' : 'Log In/Sign Up';
  let onClick = isAuthenticated ? onLogout : onLogin;

  return (
    <>
      {isAuthenticated ? (
        <LinkContainer to="/profile">
          <Button className="btn-nav">Profile</Button>
        </LinkContainer>
      ) : (
        <></>
      )}
      <LinkContainer to="">
        <Button className="btn-nav" onClick={onClick}>
          {buttonText}
        </Button>
      </LinkContainer>
    </>
  );
};

export default LoginButton;