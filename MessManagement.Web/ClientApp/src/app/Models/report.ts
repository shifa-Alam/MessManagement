import { BaseEntity } from "./baseEntity";
import { MemberReport } from "./memberReport";

export class Report extends BaseEntity {
  totalMeal: number = 0;
  totalExpence: number = 0;
  mealRate: number = 0;
  memberReports: MemberReport[] = [];
}

