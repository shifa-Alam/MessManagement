import { BaseEntity } from "./baseEntity";

export class Meal extends BaseEntity {
  memberId: number = 0;
  quantity: number = 0;
  mealDate: any;
  memberFirstName: string = "";
  memberLastName?: string = "";
}

