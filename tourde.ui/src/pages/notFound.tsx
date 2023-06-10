import { Link } from 'react-router-dom';

const NotFound = () => {
  return (
    <div>
      <h2>Not found.</h2>
      <Link to="/">Go to the home page</Link>
    </div>
  );
};

export default NotFound;
