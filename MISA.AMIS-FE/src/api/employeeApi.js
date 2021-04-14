import axios from 'axios';

// eslint-disable-next-line no-unused-vars
var baseUrl = 'https://localhost:44388/api/v1/Employees';

/**
 * Đối tượng thực thi các API với khách hàng
 */
const employeeApi = {
    // Lấy danh sách khách hàng
    getCustomers: async() => {
        var res = await axios.get(baseUrl);
        return res;
    },

    // Lấy phân trang khách hàng
    getCustomersPage: async(offset, limmit) => {
        var page = {
            offset: offset,
            limmit: limmit,
        };
        var res = await axios.get(baseUrl + '/page', { params: page });
        return res;
    },

    // Check trùng mã khách hàng
    checkExistCustomerCode: async(customerCode) => {
        var url = `${baseUrl}/by?code=${customerCode}`;
        var res = await axios.get(url);
        return res;
    },

    // Thêm mới khách hàng
    addNewCustomer: async(body) => {
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

    // Xóa nhiều khách hàng
};

export { employeeApi };