import { IdentityApiRoutes } from '@util/constants';
import axiosInstance from './api';
import { ApplicationUser } from '@models/person';

/**
 *
 * @param token
 * @param user
 */
export const login = async (token: string, user: ApplicationUser) => {
  await axiosInstance.post(IdentityApiRoutes.LOGIN, user, {
    headers: { Authorization: `Bearer ${token}` },
  });
};
