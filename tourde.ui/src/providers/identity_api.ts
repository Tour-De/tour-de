import { ApplicationUser } from '../models/person';
import { IdentityApiRoutes } from '../util/constants';
import axiosInstance from './api';

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