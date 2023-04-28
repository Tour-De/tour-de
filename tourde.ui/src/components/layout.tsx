import Header from "@components/header";
import { Container } from "react-bootstrap";
import Sidebar from "@components/sidebar";
import { Outlet } from "react-router-dom";

const Layout = () => {
    return (
        <>
            <Header/>
            <Container className="content">
                <Outlet/>
                <Sidebar/>
            </Container>
        </>
    );
}

export default Layout;