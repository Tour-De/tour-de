import { Constants } from "@util/constants";
import { Person } from "@models/person";
import { Table } from "react-bootstrap";
import { useApi } from "@hooks/useApi";

const Leaderboards = () => {    
    const { loading, data, error } = useApi<Array<Person>>(Constants.GET_PEOPLE);

    if (error) {
        return <div>Error: {error.message}</div>
    }

    if (loading) {
        return <div>Loading...</div>
    }

    return (
        <Table>
            <tbody>
                {
                    data!.map((person: Person, index: number) => {
                        return (
                            <tr key={index}>
                                <td>{person.firstName}</td>
                                <td>{person.lastName}</td>
                                <td>{person.email}</td>
                                <td>{person.phone}</td>
                                <td>{person.dateOfBirth}</td>
                            </tr>
                        );
                    })
                }
            </tbody>
        </Table>
    );
}

export default Leaderboards;