export interface IUser{
    UserId: number;
    Name : string;
    Contact : string;
    Email : string;
    Password : string;
    RoleId : number;
    ProfilePic: string;
    IsActive : boolean;
    IsSubscribed : boolean;
    IsApproved : number;
}