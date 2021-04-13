<template>
    <!-- Content -->
    <div class="content">
        <!-- Content top -->
        <div class="content__top">
            <div class="first-line d-center-flex">
                <h3 class="content__top-header">Nhân viên</h3>
                <div class="btn-add btn" @click="showModal">Thêm</div>
            </div>

            <div class="second-line d-center-flex">
                <div class="svg-icon svg-icon-16 svg-s-chevron-left"></div>
                <p>Tất cả danh mục</p>
            </div>
        </div>
        <!-- Content main -->
        <div class="content__main">
            <!-- Menu -->
            <div class="data-more-action" v-if="showMenu" :style="{ top: menuTop, right: menuRight }">
                <div class="action-list">Nhân bản</div>
                <div class="action-list">Xóa</div>
                <div class="action-list">Ngừng sử dụng</div>
            </div>
            <BaseLoader :isShow="isLoading" />
            <!-- Search box -->
            <div class="content-search-box d-center-flex search-box">
                <input type="text" placeholder="Tìm theo mã, tên nhân viên" />
                <div class="search-icon">
                    <div class="svg-icon svg-search svg-icon-16"></div>
                </div>
            </div>
            <!-- Table -->
            <div class="main-table">
                <table>
                    <thead class="fixed-header">
                        <tr>
                            <th v-for="item in rowTitle" :key="item.titleCode" :fieldname="item.titleCode">
                                {{ item.title }}
                            </th>
                        </tr>
                    </thead>

                    <tbody>
                        <tr v-for="employee in dataBinding" :key="employee.EmployeeId" @dblclick="trOnClick(employee.EmployeeId)">
                            <td>{{ employee.EmployeeCode }}</td>
                            <td>{{ employee.EmployeeName }}</td>
                            <td>{{ employee.EmployeePosition }}</td>
                            <td>{{ employee.EmployeeDepartment }}</td>
                            <td>{{ employee.EmployeeAccountNumber }}</td>
                            <td>{{ employee.BankName }}</td>
                            <td>{{ employee.StateAccount }}</td>
                            <td class="last-col">
                                <div class="d-center-flex user-action">
                                    <p>Sửa</p>
                                    <div class="icon-swapper" @click="test">
                                        <div class="svg-icon svg-icon-16 svg-s-arrow-blue-down"></div>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
        </div>
        <!-- Content bottom -->
        <div class="content__bottom">
            <div class="text-left">Tổng số: <b>115</b> Bản ghi</div>

            <div class="text-right d-center-flex">
                <div class="number-perpage d-center-flex">
                    <div class="input-number">
                        <input type="text" readonly value="20 bản ghi trên trang" />
                    </div>
                    <div class="more-option">
                        <div class="svg-icon svg-icon-16 svg-s-arrow-down"></div>
                    </div>
                </div>

                <div class="pagination d-center-flex">
                    <div class="pre">Trước</div>
                    <div class="page-number">1</div>
                    <div class="page-number">2</div>
                    <div class="page-number">3</div>
                    <div class="page-number">4</div>
                    <div class="next">Sau</div>
                </div>
            </div>
        </div>

        <EmployeePopupAdd :modalStatus="modalStatus" :employee="selectedEmployee" @closeModal="hideModal" />
    </div>
    <!-- End content -->
</template>

<script>
    import { formatDate } from '@/helper/formatTable.js';
    import EmployeePopupAdd from '../popup/EmployeePopupAdd';
    import { employeeApi } from '@/api/employeeApi';

    export default {
        name: 'Content',

        data() {
            return {
                dataList: '',
                modalStatus: false,
                selectedEmployee: {},

                showMenu: false,

                menuTop: 0,

                menuRight: 0,
            };
        },

        props: {
            dataBinding: Array,
            rowTitle: Array,
            isLoading: Boolean,
            reload: Function,
        },

        methods: {
            /**
             * Các hàm helper
             */
            formatDate,

            /**
             * Ẩn modal thêm khách hàng
             */
            hideModal() {
                this.modalStatus = false;
                this.selectedEmployee = {};
            },

            /**
             * Hiển thị modal Thêm khách hàng
             */
            showModal() {
                this.modalStatus = true;
            },

            /**
             * Khi click vào tr -> Hiển thị thông tin chi tiết khách hàng
             */
            trOnClick(employeeId) {
                employeeApi
                    .getEmployeeById(employeeId)
                    .then((res) => {
                        this.selectedEmployee = res.data;
                        console.log(this.selectedEmployee);
                        this.showModal();
                    })
                    .catch((e) => {
                        console.log(e);
                    });
            },

            test(e) {
                this.showMenu = !this.showMenu;
                var menuPosition = e.currentTarget.getBoundingClientRect();
                this.menuTop = `${menuPosition.top - 114}px`;
                this.menuRight = `${window.innerWidth - menuPosition.right - 55}px`;
            },
        },
        components: {
            EmployeePopupAdd,
        },
    };
</script>

<style lang="scss" scoped>
    @import '../../style/layout/content.scss';
</style>
