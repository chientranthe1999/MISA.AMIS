/**
 * format dữ liệu ngày sinh để bind vào trường input
 * Value của trường input type=date có dạng yyyy-mm-dd
 * @author: Chiến Nobi (14/04/2021)
 */
const DataFormater = {
    inputDateFormat: (dateValue) => {
        try {
            if (dateValue == null) {
                return dateValue;
            }
            var dateTime = new Date(dateValue);
            let year = dateTime.getFullYear();
            let month = dateTime.getMonth() + 1;
            // Định dạng month theo kiểu mm
            month = month < 10 ? '0' + month : month;
            let date = dateTime.getDate();
            // Định dáng date theo kiểu dd
            date = date < 10 ? '0' + date : date;
            var dateFormated = year + '-' + month + '-' + date;
            return dateFormated;
        } catch (error) {
            console.log(error);
        }
    },
};

export { DataFormater };