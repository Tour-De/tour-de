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

const App = () => {
  return (
    <BrowserRouter>
      <Routes>
        <Route element={<Layout/>}>
          <Route path="/" element={<Home/>}/>
          <Route path="profile" element={<Profile/>}/>
          <Route path="about" element={<About/>}/>
          <Route path="contact" element={<Contact/>}/>
          <Route path="join" element={<Join/>}/>
          <Route path="leaderboards" element={<Leaderboards/>}/>
          <Route path="media" element={<Media/>}/>
          <Route path="*" element={<NotFound/>}/>
        </Route>
      </Routes>
    </BrowserRouter>
  );
}

export default App;
