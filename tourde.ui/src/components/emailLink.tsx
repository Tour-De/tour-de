interface EmailLinkProps {
  /**
   * The email address to link to.
   */
  emailAddress: string;

  /**
   * Optional text to display instead of email address.
   */
  text?: string | null;
}

/**
 * Automatically builds the HREF and populates the text.
 * @param props
 * @returns
 */
const EmailLink = (props: EmailLinkProps) => {
  return (
    <a href={`mailto:${props.emailAddress}`}>
      {props.text ?? props.emailAddress}
    </a>
  );
};

export default EmailLink;
