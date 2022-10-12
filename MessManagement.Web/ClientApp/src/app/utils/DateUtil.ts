export class DateUtil {

    static ConvertToActualDate(dateString: string) {
        var date = new Date(dateString), mnth = ("0" + (date.getMonth() + 1)).slice(-2), day = ("0" + date.getDate()).slice(-2);
        return [date.getFullYear(), mnth, day].join("-");
    }


}