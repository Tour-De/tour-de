import React from 'react';
import ReactDOM from 'react-dom/client';
import '@assets/index.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import App from './App';
import reportWebVitals from '@util/reportWebVitals';
import { AppState, Auth0Provider, User } from '@auth0/auth0-react';
import { ThemeProvider } from 'react-bootstrap';
import { PersonApiRoutes } from '@util/constants';
import { Person } from '@models/person';

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

root.render(
  <Auth0Provider
    domain={process.env.REACT_APP_AUTH0_DOMAIN!}
    onRedirectCallback={postLogin}
    clientId={process.env.REACT_APP_AUTH0_CLIENTID!}
    authorizationParams={{
      redirect_uri: window.location.origin,
      audience: 'TourDe',
      scope: 'profile email read:person',
    }}
  >
    <React.StrictMode>
      <ThemeProvider>
        <App />
      </ThemeProvider>
    </React.StrictMode>
  </Auth0Provider>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();

async function postLogin(
  appState?: AppState | undefined,
  user?: User | undefined
) {
  if (user) {
    const person = new Person(
      0,
      user.tourde_first_name,
      user.tourde_last_name,
      user.email!
    );
    await fetch(
      process.env.REACT_APP_API_BASE_URI + PersonApiRoutes.ADD_PERSON,
      {
        method: 'POST',
        headers: {
          'content-type': 'application/json;charset=UTF-8',
        },
        body: JSON.stringify(person),
      }
    );
  }
}
