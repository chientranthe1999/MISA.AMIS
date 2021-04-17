import axios from 'axios';

// eslint-disable-next-line no-unused-vars
var baseUrl = 'https://localhost:44388/api/v1/Employees';

/**
 * Đối tượng thực thi các API với khách hàng
 * @author: Chiến Nobi (15/4/2021)
 */
const employeeApi = {
    // Lấy danh sách khách hàng
    getEmployees: async() => {
        var res = await axios.get(baseUrl);
        return res;
    },

    // Lấy phân trang khách hàng
    getEmployeesPage: async(offset, limmit) => {
        var page = {
            offset: offset,
            limmit: limmit,
        };
        var res = await axios.get(baseUrl + '/page', { params: page });
        return res;
    },

    // Check trùng mã khách hàng
    checkExistEmployeeCode: async(customerCode) => {
        var url = `${baseUrl}/by?code=${customerCode}`;
        var res = await axios.get(url);
        return res;
    },

    // Thêm mới khách hàng
    addNewEmployee: async(body) => {
        var res = await axios.post(baseUrl, body);
        return res;
    },

    // Get thông tin nhân viên by employeeId
    getEmployeeById: async(employeeId) => {
        var url = baseUrl + '/' + employeeId;
        var res = await axios.get(url);
        return res;
    },
    // Sửa thông tin khách hàng
    updateEmployee: async(employee) => {
        try {
            var url = baseUrl + '/' + employee.EmployeeId;
            var res = await axios.put(url, employee);
            return res;
        } catch (err) {
            console.log(err);
        }
    },

    // Xóa khách hàng
    deleteEmployee: async(employeeId) => {
        try {
            var url = baseUrl + '/' + employeeId;
            var res = await axios.delete(url);
            return res;
        } catch (error) {
            console.log(error);
        }
    },

    // Check trùng mã khách hàng lúc update
    checkEmployeeCodeUpdate: async(employeeCode, employeeId) => {
        try {
            var url = baseUrl + '/' + employeeCode + '/' + employeeId;
            var res = await axios.get(url);
            return res;
        } catch (error) {
            console.log(error);
        }
    },

    // Check trùng mã lúc thêm mới
    checkEmployeeCodeAdd: async(employeeCode) => {
        try {
            var url = baseUrl + '/by/' + employeeCode;
            var res = await axios.get(url);
            return res;
        } catch (error) {
            console.log(error);
        }
    },

    // Search employee
    searchEmployee: async(value) => {
        try {
            var url = baseUrl + '/search/' + value;
            var res = await axios.get(url);
            return res;
        } catch (error) {
            console.log(error);
        }
    },

    // Lấy codemax và trả về mã tự tăng
    // codeAutoIncrease: async() => {
    //     try {
    //         var url = baseUrl + '/codemax';
    //         var res = await axios.get(url);
    //         var codeMax = res.data;
    //         var prefix = codeMax.match(/[a-zA-Z]+/g)[0];
    //         var number = codeMax.match(/\d+/g)[0];
    //         var rezoNumber = numberInt.toString.le
    //         var numberStringLength = number.length;
    //         var numberInt = parseInt(number);
    //         var nextNumber = numberInt + 1;

    //     } catch (error) {
    //         console.log(error);
    //     }
    // },
};

export { employeeApi };