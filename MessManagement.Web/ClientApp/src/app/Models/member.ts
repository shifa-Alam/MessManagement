import { BaseEntity } from "./baseEntity";

export class Member  extends BaseEntity{
  firstName: string = '';
  lastName?: string = '';
  mobileNumber: string = '';
  emergencyContact: string = '';
  email: string = '';
  image: string = '';
  homeDistrict?: string = '';
}

