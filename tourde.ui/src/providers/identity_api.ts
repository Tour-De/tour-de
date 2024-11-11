import { ApplicationUser } from '../models/person';
import { IdentityApiRoutes } from '../util/constants';
import axiosInstance from './api';

/**
 *
 * @param token
 * @param user
 */
export const login = async (token: string, user: ApplicationUser): Promise<string[]> => {
  const response = await axiosInstance.post<string[]>(IdentityApiRoutes.LOGIN, user, {
    headers: { Authorization: `Bearer ${token}` },
  });

  return response.data;
};