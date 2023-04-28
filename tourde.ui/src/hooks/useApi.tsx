import { useAuth0 } from "@auth0/auth0-react";
import { useState, useEffect } from "react";

/**
 * Hook for making API requests returning JSON data. Add Auth0 token to header.
 * @param url 
 * @returns 
 */
const useApi = (url: string) => {
  const [loading, setLoading] = useState(true);
  const [data, setData] = useState(null);
  const { getAccessTokenSilently }  = useAuth0();

  const fetchApi = () => {
    getAccessTokenSilently()
    .then(access_token => {
        fetch(url, {
            method: 'GET', 
            headers: {
                'Authorization': `Bearer ${access_token}`,
                'Content-Type': 'application/json'
            }
        })
        .then((response: Response) => response.json())
        .then((json) => {
          setLoading(false);
          setData(json);
        });
    })
    
  };

  useEffect(() => {
    fetchApi();
  }, [/* empty dependencies to only run when parent component mounts */]);

  return { loading, data };
};

export default useApi;