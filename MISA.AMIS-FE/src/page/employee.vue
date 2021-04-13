<template>
    <div>
        <Sidebar />
        <div class="right-swapper">
            <Header />
            <Content :dataBinding="this.employeeList" :isLoading="this.isLoading" :rowTitle="this.rowTitle" :reload="this.reload" />
        </div>
        <!-- <BaseSuccessMessage /> -->
    </div>
</template>

<script>
    import { employeeApi } from '@/api/employeeApi';

    export default {
        name: 'Employee',
        data() {
            return {
                employeeList: [],

                isLoading: true,

                rowTitle: [
                    { titleCode: 'EmployeeCode', title: 'Mã nhân viên' },
                    { titleCode: 'EmployeeName', title: 'Tên nhân viên' },
                    { titleCode: 'EmployeePosition', title: 'Chức danh' },
                    { titleCode: 'EmployeeDepartment', title: 'Tên đơn vị' },
                    { titleCode: 'EmployeeAccountNumber', title: 'Số tài khoản' },
                    { titleCode: 'BankName', title: 'Tên ngân hàng' },
                    { titleCode: 'StateAccount', title: 'Trạng thái' },
                    { titleCode: 'Function', title: 'Chức năng' },
                ],

                picker: '',
            };
        },

        // Lấy dữ liệu khi component được tạo thành công (render ra DOM ảo)
        created() {
            this.getData();
        },

        methods: {
            /**
             * Reload lại dữ liệu khi nhấn nút reload
             * @version: 1.0
             * @author: Chiến Nobi
             */
            reload() {
                this.employeeList = [];
                this.isLoading = true;
                this.getData();
            },

            /**
             * Lấy dữ liệu từ api
             */
            getData() {
                employeeApi
                    .getCustomers()
                    .then((res) => {
                        this.employeeList = res.data;
                        this.isLoading = false;
                    })
                    .catch((e) => {
                        console.log(e);
                    });
            },
        },
    };
</script>

<style lang="scss">
    .right-swapper {
        float: left;
        width: calc(100% - 180px);
    }
</style>
