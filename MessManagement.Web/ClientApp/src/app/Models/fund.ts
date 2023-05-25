import { BaseEntity } from "./baseEntity";

export class Fund extends BaseEntity {
  memberId: number = 0;
  purpose: string = "";
  amount: number = 0;
  fundDate: any;
  isDeduction: boolean = false;
  memberFirstName: string = "";
  memberLastName?: string = "";
}

