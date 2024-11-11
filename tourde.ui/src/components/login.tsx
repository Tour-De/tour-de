import { useAuth0 } from '@auth0/auth0-react';
import { useContext, useEffect } from 'react';
import { ApplicationUser } from '../models/person';
import { Button } from '@mui/material';
import { login } from '../providers/identity_api';
import { Link } from 'react-router-dom';
import { IdentityContext } from '../context/identityContext';

const LoginButton = () => {
  const {
    loginWithRedirect,
    logout,
    isAuthenticated,
    getAccessTokenSilently,
    user,
  } = useAuth0();
  const {roles, setRoles} = useContext(IdentityContext);

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
      const roles = await login(token, appUser);
      setRoles(roles);
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
          <Button variant={'contained'} component={Link} to={'/profile'} className="btn-nav">Profile</Button>
      ) : (
        <></>
      )}
      <Button variant={'contained'} component={Link} to={''} className="btn-nav" onClick={onClick}>
        {buttonText}
      </Button>
    </>
  );
};

export default LoginButton;