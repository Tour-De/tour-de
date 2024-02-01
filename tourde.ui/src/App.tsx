import { BrowserRouter, Route, Routes } from 'react-router-dom';
import '@assets/App.css';
import Profile from '@pages/profile';
import Home from '@pages/home';
import NotFound from '@pages/notFound';
import About from '@pages/about';
import Contact from '@pages/contact';
import Join from '@pages/join';
import Leaderboards from '@pages/leaderboards';
import Media from '@pages/media';
import Layout from '@components/layout';
import { Auth0Provider } from '@auth0/auth0-react';

const App = () => {  
  return (    
      <BrowserRouter>
        <Auth0Provider
          domain={process.env.REACT_APP_AUTH0_DOMAIN!}
          clientId={process.env.REACT_APP_AUTH0_CLIENTID!}
          authorizationParams={{
            redirect_uri: window.location.origin,
            audience: 'TourDe',
            scope: 'profile email read:person',
          }}
        >
          <Routes>
            <Route element={<Layout />}>
              <Route path="/" element={<Home />} />
              <Route path="profile" element={<Profile />} />
              <Route path="about" element={<About />} />
              <Route path="contact" element={<Contact />} />
              <Route path="join" element={<Join />} />
              <Route path="leaderboards" element={<Leaderboards />} />
              <Route path="media" element={<Media />} />
              <Route path="*" element={<NotFound />} />
            </Route>
          </Routes>
        </Auth0Provider>
      </BrowserRouter>    
  );
};

export default App;
