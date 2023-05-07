import EmailLink from "@components/emailLink";

const Contact = () => {
    return (
        <div>
            <h2>Contact Us</h2>
            <table border={1}>
                <tbody>
                    <tr>
                        <td>General Info</td>
                        <td><EmailLink emailAddress='riverwest24@gmail.com'/></td>
                    </tr>
                    <tr>
                        <td>Bonus Checkpoints</td>
                        <td><EmailLink emailAddress='bonus@riverwest24.com'/></td>
                    </tr>
                    <tr>
                        <td>Registration/Scoring</td>
                        <td><EmailLink emailAddress='register@riverwest24.com'/></td>
                    </tr>
                    <tr>
                        <td>Volunteer Organizater</td>
                        <td><EmailLink emailAddress='volunteer@riverwest24.com'/></td>
                    </tr>
                    <tr>
                        <td>Neighborhood Concerns/Day of Contact</td>
                        <td><EmailLink emailAddress='community@riverwest24.com'/></td>
                    </tr>
                    <tr>
                        <td>Webmaster</td>
                        <td><EmailLink emailAddress='webmaster@riverwest24.com'/></td>
                    </tr>
                    <tr>
                        <td>Instagram</td>
                        <td><a href='http://www.instagram.com/riverwest24' target="_blank" rel="noopener noreferrer">@riverwest24</a></td>
                    </tr>
                    <tr>
                        <td>Facebook</td>
                        <td><a href='http://www.facebook.com/riverwest24' target="_blank" rel="noopener noreferrer">riverwest24</a></td>
                    </tr>
                </tbody>
            </table>
        </div>
    );
}

export default Contact;