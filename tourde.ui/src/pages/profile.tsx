import { useAuth0 } from "@auth0/auth0-react";
import LoginButton from "@components/login";

const Profile = () => {
  const { user, isAuthenticated } = useAuth0();

  if (!isAuthenticated) {
    return (
      <div>
        <h3>You are not logged in.</h3>
        <LoginButton/>
      </div>
    );
  }

  return (
    <div className="App">
      {isAuthenticated && user &&
      <div>
          <img src={user.picture} alt={user.name} />
          <h2>Hello, {user.name}</h2>
      </div> }
    </div>
  );
};

export default Profile;