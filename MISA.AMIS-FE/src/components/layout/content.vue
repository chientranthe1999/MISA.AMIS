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
            <div class="data-more-action" v-if="showMenu" :style="{ top: menuTop, right: menuRight }" v-click-outside="closeMenu">
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
                        <tr v-for="(employee, i) in dataBinding" :key="i" @dblclick="trOnClick(employee.EmployeeId)">
                            <td style="width: 150px; min-width: 150px">{{ employee.EmployeeCode }}</td>
                            <td style="width: 250px; min-width: 250px">{{ employee.EmployeeName }}</td>
                            <td style="width: 150px; min-width: 150px">{{ employee.EmployeePosition }}</td>
                            <td style="width: 250px; min-width: 250px">{{ employee.EmployeeDepartment }}</td>
                            <td style="width: 150px; min-width: 150px">{{ employee.EmployeeAccountNumber }}</td>
                            <td style="width: 250px; min-width: 250px">{{ employee.BankName }}</td>
                            <td style="width: 180px; min-width: 180px">{{ employee.StateAccount }}</td>
                            <td class="last-col" style="width: 100px; min-width: 100px">
                                <div class="d-center-flex user-action">
                                    <p @click="trOnClick(employee.EmployeeId)">Sửa</p>
                                    <div class="icon-swapper" @click="showFunctionMenu">
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
    import EmployeePopupAdd from '../popup/EmployeePopupAdd';
    import { employeeApi } from '@/api/employeeApi';
    import { DataFormater } from '@/helper/formatData';

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

                // Số lượng bản ghi trên 1 trang
                pageSize: 20,
                // offset của bản ghi
                offsetActive: 1,
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
                        this.selectedEmployee.DateOfBirth = DataFormater.inputDateFormat(this.selectedEmployee.DateOfBirth);
                        this.selectedEmployee.IdentityDate = DataFormater.inputDateFormat(this.selectedEmployee.IdentityDate);
                        this.showModal();
                    })
                    .catch((e) => {
                        console.log(e);
                    });
            },

            showFunctionMenu(e) {
                this.showMenu = !this.showMenu;
                var menuPosition = e.currentTarget.getBoundingClientRect();
                this.menuTop = `${menuPosition.top - 114}px`;
                this.menuRight = `${window.innerWidth - menuPosition.right - 55}px`;
                console.log(e.target);
            },

            closeMenu() {
                this.showMenu = false;
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
