import { employeeApi } from '@/api/employeeApi';

const employee = {

    namespaced: true,

    state: {
        // Danh sách nhân viên
        employees: [],
        // Show loading indicator
        showLoading: false,

        showDeleteWarning: false,

        showSuccess: false,

        message: "",

        // lấy dữ liệu của bản ghi cần xóa
        deleteEmployee: {},
    },

    actions: {
        // Lấy dữ liệu từ API về
        getEmployees: async ({ commit }) => {
            try {
                commit('setShowLoading', true)
                var res = await employeeApi.getEmployees();
                commit('setShowLoading', false)
                commit('setEmployees', res.data);
            } catch (error) {
                console.log(error);
            }
        },

        //Xóa khách hàng
        deleteEmployee: ({ commit, dispatch, state }) => {
            try {
                commit('setShowDeleteWarning', false)
                commit('setShowLoading', true)
                employeeApi.deleteEmployee(state.deleteEmployee.employeeId).then((res) => {
                    commit('setShowLoading', false)
                    // handle the response
                    if (res.status == 200) {
                        commit("setMessage", res.data.UserMsg);
                        commit('setShowLoading', false);
                        commit('setShowSuccess', true);
                        dispatch('getEmployees');
                    }
                });
            } catch (error) {
                console.log(error);
            }
        },

    },

    mutations: {
        setEmployees: (state, employees) => { state.employees = employees; },
        setShowLoading: (state, showLoading) => { state.showLoading = showLoading; },
        setShowDeleteWarning: (state, showDeleteWarning) => { state.showDeleteWarning = showDeleteWarning; },
        setShowSuccess: (state, showSuccess) => { state.showSuccess = showSuccess; },
        setMessage: (state, message) => { state.message = message; },
        setDeleteEmployee: (state, employee) => { state.deleteEmployee = employee; },
    },

    getters: {

    },

}

export { employee }