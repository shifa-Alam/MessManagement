import { BaseEntity } from "./baseEntity";

export class Bazar extends BaseEntity {
  memberId: number = 0;
  amount: number = 0;
  bazarDate: any;
  memberFirstName: string = "";
  memberLastName: string = "";
}

