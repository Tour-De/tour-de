const NavBar = () => {

  return (
    <Navbar collapseOnSelect className="p-3 nav-header" expand={'md'}>
      <Container>
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            <LinkContainer to="/">
              <Button className="btn-nav">Home</Button>
            </LinkContainer>
            <LinkContainer to="/leaderboards">
              <Button className="btn-nav">Leaderboards</Button>
            </LinkContainer>
            <LinkContainer to="/about">
              <Button className="btn-nav">About</Button>
            </LinkContainer>
            <LinkContainer to="/media">
              <Button className="btn-nav">Media</Button>
            </LinkContainer>
            <LinkContainer to="/join">
              <Button className="btn-nav">Join</Button>
            </LinkContainer>
            <LinkContainer to="/contact">
              <Button className="btn-nav">Contact</Button>
            </LinkContainer>
          </Nav>
          <Nav className="gap-2">
            <LoginButton />
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
};

export default NavBar