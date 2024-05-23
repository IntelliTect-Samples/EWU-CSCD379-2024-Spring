import { format } from "date-fns";

export default class dateUtils {
  constructor() {}

  public static getFormattedDate(date: Date): string {
    return format(date, "yyyy-MM-dd");
  }

  public static getFormattedDateWithOrdianl(date: Date): string {
    return format(date, "MMMM do, yyyy");
  }
}
