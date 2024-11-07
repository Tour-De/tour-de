import Header from '@components/header';
import Sidebar from '@components/sidebar';
import { Container, Stack } from 'react-bootstrap';
import { Outlet } from 'react-router-dom';

const Layout = () => {
  return (
    <>
      <Header />
      <Container fluid className="main">
        <Stack direction="horizontal">
          <Outlet />
          <Sidebar />
        </Stack>
      </Container>
    </>
  );
};

export default Layout;
