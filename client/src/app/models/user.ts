export interface User {
  email: string;
  token: string;
  roleId: number;
  userProfile: UserProfile;
}

export interface UserProfile {
  profileId: number;
  firstName: string;
  lastName: string;
}
