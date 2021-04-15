import axios from 'axios';

var baseUrl = 'https://localhost:44388/api/v1/Departments';

/**
 * Đối tượng thực thi các Api
 */
const departmentApi = {
    getDepartment: async() => {
        var res = await axios.get(baseUrl);
        return res;
    },
};

export { departmentApi };