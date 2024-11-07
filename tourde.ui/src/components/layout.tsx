import { Outlet } from 'react-router-dom';
import Header from './header';
import { Container, Stack } from '@mui/material';
import Sidebar from './sidebar';

const Layout = () => {
  return (
    <>
      <Header />
      <Container className="main">
        <Stack direction={'row'}>
          <Outlet />
          <Sidebar />
        </Stack>
      </Container>
    </>
  );
};

export default Layout;