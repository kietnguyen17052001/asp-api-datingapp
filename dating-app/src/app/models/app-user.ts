export class AppUser {
    userId: number = 0;
    username: string = "";
    email: string = "";
}

export class UserToken {
    username: string = "";
    token: string = "";
}

export class AuthUser {
    username: string = "";
    password: string = "";
}

export class RegisterUser {
  username: string = '';
  password: string = '';
  email: string = '';
  dateOfBirth: Date = new Date();
  gender: string = '';
  city: string = '';
  knownAs: string = '';
  introduction: string = '';
  avatar: string = '';
}
