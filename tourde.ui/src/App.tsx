import { BrowserRouter, Route, Routes } from 'react-router-dom';
import './App.css'
import { Auth0Provider } from '@auth0/auth0-react';
import Layout from './components/layout';
import About from './pages/about';
import Contact from './pages/contact';
import Home from './pages/home';
import Join from './pages/join';
import Leaderboards from './pages/leaderboards';
import Media from './pages/media';
import NotFound from './pages/notFound';
import Profile from './pages/profile';

function App() {
  return (    
    <BrowserRouter>
      <Auth0Provider
        domain={import.meta.env.VITE_AUTH0_DOMAIN!}
        clientId={import.meta.env.VITE_AUTH0_CLIENTID!}
        authorizationParams={{
          redirect_uri: window.location.origin,
          audience: 'TourDe',
          scope: 'profile email',
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
}

export default App
