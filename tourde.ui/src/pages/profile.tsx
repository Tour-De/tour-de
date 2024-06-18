import { IdToken, useAuth0 } from '@auth0/auth0-react';
import { useEffect, useState } from 'react';

const Profile = () => {
  const { user, isAuthenticated, getIdTokenClaims } = useAuth0();
  const [idToken, setIdToken] = useState<IdToken>();

  useEffect(() => { 
    getIdTokenClaims()
    .then(async (claims) => {
      setIdToken(claims)
      // send user data to API


    })
  }, [getIdTokenClaims]);

  if (!isAuthenticated) {
    return (
      <div>
        <h3>You are not logged in.</h3>
        <h4>Please login or signup.</h4>
      </div>
    );
  }

  // sub contains 'provider|id'
  return (
    <div className="App">
      {isAuthenticated && user && (
        <div>
          <img src={user.picture} alt={user.name} />
          <h2>Hello, {user.name}</h2>
          <pre>{JSON.stringify(user, null, 2)}</pre>
          <pre>{JSON.stringify(idToken, null, 2)}</pre>
        </div>
      )}
    </div>
  );
};

export default Profile;
