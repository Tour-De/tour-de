import { useAuth0 } from "@auth0/auth0-react";
import { useState, useEffect } from "react";

export interface ApiResult<T> {
  loading: boolean,
  data: T | undefined,
  error: any | undefined,
}

/**
 * Hook for making API requests returning JSON data. Add Auth0 token to header.
 * @param url 
 * @returns 
 */
export function useApi<T>(url: string, method: string = "GET"): ApiResult<T> {
  const [loading, setLoading] = useState(true);
  const [data, setData] = useState<T>();
  const [error, setError] = useState<any>();
  const {getAccessTokenSilently}  = useAuth0();
  const fullUrl = process.env.REACT_APP_API_BASE_URI + url;

  const fetchApi = () => {
    getAccessTokenSilently()
    .then(access_token => 
        fetch(fullUrl, {
            method: method, 
            headers: {
                'Authorization': `Bearer ${access_token}`,
                'Content-Type': 'application/json'
            }
        })
      )
      .then((response: Response) => response.json())
      .then((json: T) => {
        setLoading(false);
        setData(json);
      })
      .catch((err: any) => {
        setError(err);
      });    
  };

  useEffect(() => {
    fetchApi();
  }, [/* empty dependencies to only run when parent component mounts */]);

  return { loading, data, error };
};