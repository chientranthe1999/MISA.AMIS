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

    // Xóa khách hàng
    deleteEmployee: async(employeeId) => {
        var url = baseUrl + '/' + employeeId;
        var res = await axios.delete(url);
        return res;
    },

    // Xóa nhiều khách hàng
};

export { employeeApi };