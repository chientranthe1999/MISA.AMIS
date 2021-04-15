<template>
    <!-- Content -->
    <div class="content">
        <!-- Confirm Delete -->
        <BaseDeleteWarning :isShow.sync="showDeleteWarning" @agree="deleteEmployee" :message="message" />

        <BaseSuccessMessage :isShow.sync="showSuccess" :message="message" />
        <!-- Content top -->
        <div class="content__top">
            <div class="first-line d-center-flex">
                <h3 class="content__top-header">Nhân viên</h3>
                <div class="btn-add btn d-center-flex" @click="showModal"><p>Thêm</p></div>
            </div>

            <div class="second-line d-center-flex">
                <div class="svg-icon svg-icon-16 svg-s-chevron-left"></div>
                <p>Tất cả danh mục</p>
            </div>
        </div>
        <!-- Content main -->
        <div class="content__main">
            <!-- Loading Indicator -->
            <BaseLoader :isShow="isLoading" />
            <!-- Menu -->
            <div class="data-more-action" v-if="showMenu" :style="{ top: menuTop, right: menuRight }" v-click-outside="closeMenu">
                <div class="action-list">Nhân bản</div>
                <div class="action-list" @click="confirmDelete">Xóa</div>
                <div class="action-list">Ngừng sử dụng</div>
            </div>
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
                        <tr v-for="(employee, i) in employees" :key="i" @dblclick="trOnClick(employee.EmployeeId)">
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
                                    <div class="icon-swapper" @click="showFunctionMenu(employee.EmployeeId, employee.EmployeeCode, $event)">
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

        <EmployeePopupAdd :modalStatus.sync="modalStatus" :employee="selectedEmployee" ref="firstFocus" @closeAddModal="closeAddModal" />
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
                // Thanh loading
                isLoading: true,
                // Modal Thêm người dùng
                modalStatus: false,
                // Nhân viên được select
                selectedEmployee: {},
                // Menu Function
                showMenu: false,
                // List nhân viên được gọi từ Api
                employees: [],
                // Vị trí menu Top
                menuTop: 0,
                // Vị trí menu Bottom
                menuRight: 0,
                // Số lượng bản ghi trên 1 trang
                pageSize: 20,
                // offset của bản ghi
                offsetActive: 1,
                // lấy employeeId của bản ghi cần xóa
                employeeDelete: {},
                // Tiêu đề của bảng
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
                // Show Delete Warning
                showDeleteWarning: false,
                // Show Success Message
                showSuccess: false,

                message: '',
            };
        },

        methods: {
            // Hiển thị modal thêm khách hàng
            showModal() {
                this.modalStatus = true;
                // waiting for rendering and setfocus for first input
                this.$nextTick(() => {
                    this.$refs.firstFocus.$refs.firstFocus.focus();
                });
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

            // Hiển thị menu xóa, nhân bản, ngừng sử dụng
            showFunctionMenu(employeeId, employeeCode, e) {
                // Toggle menu
                this.showMenu = !this.showMenu;
                // Xác định vị trí của menu
                var menuPosition = e.currentTarget.getBoundingClientRect();
                this.menuTop = `${menuPosition.top - 114}px`;
                this.menuRight = `${window.innerWidth - menuPosition.right - 55}px`;
                // Gán employeeId
                this.employeeDelete.EmployeeId = employeeId;
                this.employeeDelete.EmployeeCode = employeeCode;
            },

            // Xóa khách hàng
            deleteEmployee() {
                this.showDeleteWarning = false;
                this.isLoading = true;
                employeeApi.deleteEmployee(this.employeeDelete.EmployeeId).then((res) => {
                    this.isLoading = false;
                    if (res.status == 200) {
                        this.message = 'Xóa dữ liệu thành công!!';
                        this.isLoading = false;
                        this.showSuccess = true;
                        this.getData();
                    }
                });
            },

            // Đóng Function Menu khi click ra ngoài
            closeMenu() {
                this.showMenu = false;
            },

            // Khi ấn vào xóa, bật menu thông báo
            confirmDelete() {
                this.closeMenu();
                this.showDeleteWarning = true;
                this.message = `Bạn có chắc muốn xóa Nhân Viên ${this.employeeDelete.EmployeeCode} không?`;
            },

            // Lấy dữ liệu từ API
            getData() {
                this.isLoading = true;
                employeeApi
                    .getEmployees()
                    .then((res) => {
                        console.log(res);
                        if (res.status == 200) {
                            this.employees = res.data;
                        }
                        this.isLoading = false;
                    })
                    .catch((e) => {
                        console.log(e);
                    });
            },

            // When close modal -> reset selected Employee to clear form
            closeAddModal(status) {
                if (status == 'success') {
                    this.message = 'Thêm dữ liệu thành công';
                    this.showSuccess = true;
                    this.getData();
                }
                this.modalStatus = false;
                this.selectedEmployee = {};
            },
        },
        components: {
            EmployeePopupAdd,
        },

        created() {
            this.getData();
        },
    };
</script>

<style lang="scss" scoped>
    @import '../../style/layout/content.scss';
</style>
