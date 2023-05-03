import NavBar from "@components/navbar";
import { Link } from "react-router-dom";
import Countdown from "@components/countdown";

const Header = () => {
    return (
        <header>
            <div className="header-top">
                <div className="logo-container">
                    <Link to="/" className="rw24-logo"></Link>                    
                    <div className="title">
                        <h1>Riverwest 24</h1>
                        <h2>Hour Bike Race</h2>
                        <span className="countstart">July 28-29, 2023 | 7pm - 7pm</span>
                    </div>
                </div>
                <Countdown/>
            </div>
            <NavBar/>
        </header>
    );
}

export default Header;