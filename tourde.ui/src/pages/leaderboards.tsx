import { LeaderboardApiRoutes } from '@util/constants';
import { Person } from '@models/person';
import { Table } from 'react-bootstrap';
import { useFetch } from 'use-http';

const Leaderboards = () => {
  const urlBuilder = new URL(process.env.REACT_APP_API_BASE_URI!);
  urlBuilder.pathname = LeaderboardApiRoutes.GET_LEADERBOARD;
  const options = { method: 'GET' };
  const {
    loading,
    error,
    data = [],
  } = useFetch<Array<Person>>(urlBuilder.toString(), options, []);

  if (error) {
    return <div>Error: {error.message}</div>;
  }

  if (loading) {
    return <div>Loading...</div>;
  }

  return (
    <Table>
      <tbody>
        {data.map((person: Person, index: number) => {
          return (
            <tr key={index}>
              <td>{person.firstName}</td>
              <td>{person.lastName}</td>
              <td>{person.email}</td>
              <td>{person.phone}</td>
              <td>{person.dateOfBirth}</td>
            </tr>
          );
        })}
      </tbody>
    </Table>
  );
};

export default Leaderboards;
