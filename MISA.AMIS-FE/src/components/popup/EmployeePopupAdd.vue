<template>
    <transition name="fade">
        <div class="employee-popup" id="employee-popup" v-if="modalStatus">
            <BaseErrorPopUp :isShow.sync="showError" :message="errorMessage" />
            <BaseLoader :isShow="showLoading" />
            <div class="popup__content">
                <!-- Popup header -->
                <div class="popup__content-header d-center-flex">
                    <div class="header-right d-flex">
                        <p class="header-title">Thông tin nhân viên</p>
                        <div class="type-choose d-center-flex">
                            <!-- Checkbox -->
                            <label for="customer">
                                <input type="checkbox" id="customer" value="0" />
                                <span class="square"></span>
                                <span>Là khách hàng</span>
                            </label>
                            <label for="provider">
                                <input type="checkbox" id="provider" value="1" />
                                <span class="square"></span>
                                <span>Là nhà cung cấp</span>
                            </label>
                        </div>
                    </div>
                    <!-- Close and help button -->
                    <div class="header-left d-flex">
                        <div class="svg-icon svg-help" title="Giúp"></div>
                        <div class="svg-icon svg-close" title="Đóng" @click="deleteErrorWhenClose"></div>
                    </div>
                </div>

                <!-- The rest of the popup -->
                <div class="popup__content-down">
                    <!-- Input -->
                    <div class="popup__content-input">
                        <!-- Input top -->
                        <div class="top d-flex">
                            <div class="input-section-left input-section">
                                <div class="d-center-flex c-grid-col">
                                    <div class="input-swapper v-col-4">
                                        <div class="input-label">Mã <span>*</span></div>
                                        <input
                                            type="text"
                                            name="Mã khách hàng"
                                            tabindex="1"
                                            v-model="employee.EmployeeCode"
                                            ref="firstFocus"
                                            @blur="donotEmpty"
                                            @focus="deleteErrorWhenFocus"
                                        />
                                    </div>
                                    <div class="input-swapper v-col-6">
                                        <div class="input-label">Tên <span>*</span></div>
                                        <input
                                            type="text"
                                            name="Tên"
                                            tabindex="1"
                                            v-model="employee.EmployeeName"
                                            @blur="donotEmpty"
                                            @focus="deleteErrorWhenFocus"
                                            ref="name"
                                        />
                                    </div>
                                </div>

                                <!-- Dropdown Lựa chọn đơn vị -->
                                <div class="input-swapper">
                                    <div class="input-label">Đơn vị <span>*</span></div>
                                    <div class="input-suggest">
                                        <input
                                            type="text"
                                            name="Đơn vị"
                                            tabindex="1"
                                            v-model="departmentName"
                                            @blur="donotEmpty"
                                            @focus="deleteErrorWhenFocus"
                                            ref="position"
                                        />
                                        <div class="show-more" @click="showDepartment = !showDepartment">
                                            <div class="svg-icon svg-s-arrow-down svg-icon-16"></div>
                                        </div>

                                        <div class="input-suggest-data" v-if="showDepartment">
                                            <div
                                                class="data-list"
                                                v-for="(department, i) in listDepartment"
                                                :key="i"
                                                @click="
                                                    changeDepartment(department.DepartmentName, department.DepartmentId)
                                                "
                                            >
                                                {{ department.DepartmentName }}
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <!-- End Dropdown -->

                                <div class="input-swapper">
                                    <div class="input-label">Chức danh</div>
                                    <input type="text" name="" tabindex="1" v-model="employee.EmployeePosition" />
                                </div>
                            </div>
                            <div class="input-section-right input-section">
                                <!-- Input ngày sinh -->
                                <div class="d-center-flex c-grid-col">
                                    <div class="input-swapper v-col-4 cs-calender">
                                        <div class="input-label">Ngày sinh</div>
                                        <div class="cs-calender-input" v-click-outside="closeBirthdayCalender">
                                            <input type="date" name="" tabindex="1" v-model="employee.DateOfBirth" />
                                            <div
                                                class="calender-icon"
                                                @click="showDateOfBirthCalender = !showDateOfBirthCalender"
                                            >
                                                <div class="svg-icon svg-calender"></div>
                                            </div>

                                            <BaseDatePicker
                                                :dateTime.sync="employee.DateOfBirth"
                                                :isShow.sync="showDateOfBirthCalender"
                                            />
                                        </div>
                                    </div>
                                    <!-- Giới tính -->
                                    <div class="input-swapper v-col-6 gender-swapper">
                                        <div class="input-label">Giới tính</div>
                                        <div class="d-center-flex gender">
                                            <label for="female">
                                                <input
                                                    type="radio"
                                                    name="gender"
                                                    id="female"
                                                    value="0"
                                                    v-model="employee.Gender"
                                                    tabindex="1"
                                                />
                                                <span class="circle"></span>
                                                <span class="input-lable">Nam</span>
                                            </label>
                                            <label for="male">
                                                <input
                                                    type="radio"
                                                    name="gender"
                                                    id="male"
                                                    value="1"
                                                    v-model="employee.Gender"
                                                    tabindex="1"
                                                />
                                                <span class="circle"></span>
                                                <span class="input-lable">Nữ</span>
                                            </label>
                                        </div>
                                    </div>
                                </div>
                                <!-- end giới tính section -->
                                <div class="d-center-flex c-grid-col">
                                    <div class="input-swapper v-col-6">
                                        <div class="input-label">Số CMND</div>
                                        <input type="text" name="" tabindex="1" v-model="employee.IdentityNumber" />
                                    </div>
                                    <!-- Input Ngày cấp chứng minh thư nhân dân -->
                                    <div class="input-swapper v-col-4 cs-calender">
                                        <div class="input-label">Ngày cấp</div>
                                        <div class="cs-calender-input">
                                            <input type="date" name="" tabindex="1" v-model="employee.IdentityDate" />
                                            <div
                                                class="calender-icon"
                                                @click="showIndentityDateCalender = !showIndentityDateCalender"
                                                tabindex="1"
                                            >
                                                <div class="svg-icon svg-calender"></div>
                                            </div>

                                            <BaseDatePicker
                                                :dateTime.sync="employee.IdentityDate"
                                                :isShow.sync="showIndentityDateCalender"
                                            />
                                        </div>
                                    </div>
                                </div>
                                <div class="input-swapper">
                                    <div class="input-label">Nơi cấp</div>
                                    <input type="text" name="" tabindex="1" v-model="employee.IdentityPlace" />
                                </div>
                            </div>
                        </div>
                        <!-- Input bottom  -->
                        <div class="bottom">
                            <div class="tab-input">
                                <div class="tab-input__title">
                                    <div class="title-list active">Liên hệ</div>
                                    <div class="title-list">Tài khoản ngân hàng</div>
                                </div>
                                <div class="tab-input__content">
                                    <div class="input-swapper">
                                        <div class="input-label">Địa chỉ</div>
                                        <input type="text" name="" tabindex="1" v-model="employee.Address" />
                                    </div>

                                    <div class="c-grid-col">
                                        <div class="input-swapper">
                                            <div class="input-label v-col-1-4">ĐT di động</div>
                                            <input type="text" name="" tabindex="1" v-model="employee.PhoneNumber" />
                                        </div>
                                        <div class="input-swapper">
                                            <div class="input-label v-col-1-4">ĐT cố định</div>
                                            <input type="text" name="" v-model="employee.TeleNumber" />
                                        </div>
                                        <div class="input-swapper">
                                            <div class="input-label v-col-1-4">Email</div>
                                            <input type="text" name="" tabindex="1" v-model="employee.Email" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="divider"></div>

                    <!-- Button -->
                    <div class="popup__content-btn d-flex">
                        <div class="btn-left">
                            <div
                                class="btn cancel-btn"
                                tabindex="1"
                                @click="deleteErrorWhenClose"
                                @keyup.13="deleteErrorWhenClose"
                            >
                                Hủy
                            </div>
                        </div>
                        <div class="btn-right d-flex">
                            <div class="btn save-btn" title="Cất (Ctr + S)" tabindex="1">Cất</div>
                            <div class="btn add-save-btn" title="Cất và thêm" tabindex="1" @click="onSaveClick">
                                Cất và thêm
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </transition>
</template>

<script>
    // import { ErrorMessage } from '@/environment/message';
    import BaseDatePicker from '@/components/common/BaseDatePicker';
    import { departmentApi } from '@/api/departmentApi';
    import { employeeApi } from '@/api/employeeApi';
    import { Validator } from '@/helper/validate';

    export default {
        name: 'EmployeePopupAdd',
        components: {
            BaseDatePicker,
        },
        // data
        data() {
            return {
                selectLists: [],
                // Cờ validate
                hasError: false,
                // Ẩn hiện thanh loading
                showLoading: false,

                // Show Birthday Calender
                showDateOfBirthCalender: false,
                // Show Calender ngày nhập chứng minh thư nhân dân
                showIndentityDateCalender: false,

                // Danh sách các phòng ban
                listDepartment: [],

                // Data to show Department Name
                departmentName: '',

                showDepartment: false,

                errorMessage: '',

                showError: false,
            };
        },

        // props
        props: {
            modalStatus: {
                type: Boolean,
                default: false,
            },
            employee: {
                type: Object,
                default() {
                    return {};
                },
            },

            formMode: {
                type: String,
                default: 'add',
            },
        },
        methods: {
            // Xóa thông báo lỗi khi đóng cửa sổ
            deleteErrorWhenClose() {
                this.$emit('closeAddModal');
                this.hasError = false;
                this.departmentName = '';
                var inputs = document.querySelectorAll('input');

                // Xóa viền lỗi
                inputs.forEach((item) => {
                    item.classList.remove('value-error');
                });
            },

            // Thêm mới || sửa người dùng khi nhấn Save
            async onSaveClick() {
                try {
                    if (this.checkRequiredWhenSave()) {
                        this.showLoading = true;
                        if (this.formMode == 'add') {
                            employeeApi.checkEmployeeCodeAdd(this.employee.EmployeeCode).then((res) => {
                                if (res.data) {
                                    this.errorMessage = 'Mã khách hàng bị trùng';
                                    this.showLoading = false;
                                    this.showError = true;
                                } else {
                                    employeeApi.addNewEmployee(this.employee).then((res1) => {
                                        this.showLoading = false;
                                        // Nếu trả về 201 thì thông báo cho người dùng thêm thành công
                                        if (res1.status == 201) {
                                            this.$emit('closeAddModal', 201);
                                        }
                                    });
                                }
                            });
                        } else {
                            employeeApi
                                .checkEmployeeCodeUpdate(this.employee.EmployeeCode, this.employee.EmployeeId)
                                .then((res) => {
                                    if (res.data) {
                                        this.errorMessage = 'Mã khách hàng bị trùng';
                                        this.showLoading = false;
                                        this.showError == true;
                                    } else {
                                        employeeApi.updateEmployee(this.employee).then((response) => {
                                            this.showLoading = false;
                                            if (response.status == 200) {
                                                this.$emit('closeAddModal', 200);
                                            }
                                        });
                                    }
                                });
                        }
                    } else {
                        this.showError = true;
                    }
                } catch (error) {
                    console.log(error);
                }
            },

            changeDepartment(departmentName, departmentId) {
                this.departmentName = departmentName;
                this.employee.DepartmentName = departmentName;
                this.employee.DepartmentId = departmentId;
                this.showDepartment = false;
            },

            closeBirthdayCalender() {
                this.showDateOfBirthCalender = false;
            },

            // Validate bắt buộc nhập
            donotEmpty(e) {
                var value = e.target.value;
                if (Validator.validateEmpty(value)) {
                    e.target.classList.remove('value-error');
                    this.hasError = false;
                } else {
                    e.target.classList.add('value-error');
                    this.hasError = true;
                }
            },
            // Xóa thông báo lỗi khi focus
            deleteErrorWhenFocus(e) {
                e.target.classList.remove('value-error');
            },

            // Check required value
            checkRequiredWhenSave() {
                if (this.$refs.firstFocus.value == '') {
                    this.$refs.firstFocus.classList.add('value-error');
                    this.errorMessage = 'Mã khách hàng ko được để trống';
                    return false;
                }

                if (this.$refs.name.value == '') {
                    this.$refs.name.classList.add('value-error');
                    this.errorMessage = 'Tên không được để trống';
                    return false;
                }

                if (this.departmentName == '' || this.departmentName == undefined || this.departmentName == null) {
                    this.$refs.position.classList.add('value-error');
                    this.errorMessage = 'Vị trí không được để trống';
                    return false;
                }
                return true;
            },
        },

        watch: {
            'employee.DepartmentName': {
                handler() {
                    this.changeDepartment(this.employee.DepartmentName, this.employee.DepartmentId);
                },
            },
        },

        created() {
            try {
                departmentApi.getDepartment().then((res) => {
                    this.listDepartment = res.data;
                });
            } catch (error) {
                console.log(error);
            }
        },
    };
</script>

<style lang="scss" scoped>
    @import '../../style/layout/EmployeePopUpAdd';
</style>
