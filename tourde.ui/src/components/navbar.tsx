import { AppBar, Box, Button, Container, Toolbar } from "@mui/material";
import { Link } from "react-router-dom";
import LoginButton from "./login";

const NavBar = () => {

  return (
    <AppBar position={'static'}>
      <Container maxWidth={'xl'}>
        <Toolbar disableGutters>
          <Box sx={{ flexGrow: 1}}>
            <Button variant={'contained'} component={Link} to={'/'}>Home</Button>
            <Button variant={'contained'} component={Link} to={'/leaderboards'}>Leaderboards</Button>
            <Button variant={'contained'} component={Link} to={'/about'}>About</Button>
            <Button variant={'contained'} component={Link} to={'/media'}>Media</Button>
            <Button variant={'contained'} component={Link} to={'/join'}>Join</Button>
            <Button variant={'contained'} component={Link} to={'/contact'}>Contact</Button>
            <LoginButton/>
          </Box>
        </Toolbar>
      </Container>
    </AppBar>
  );
};

export default NavBar