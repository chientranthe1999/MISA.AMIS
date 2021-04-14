<template>
    <div class="employee-popup" id="employee-popup" v-if="modalStatus">
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
                                    <input type="text" name="" tabindex="1" v-model="employee.EmployeeCode" />
                                </div>
                                <div class="input-swapper v-col-6">
                                    <div class="input-label">Tên <span>*</span></div>
                                    <input type="text" name="" tabindex="1" v-model="employee.EmployeeName" />
                                </div>
                            </div>
                            <div class="input-swapper">
                                <div class="input-label">Đơn vị <span>*</span></div>
                                <input type="text" name="" tabindex="1" v-model="employee.EmployeeDepartment" />
                            </div>
                            <div class="input-swapper">
                                <div class="input-label">Chức danh</div>
                                <input type="text" name="" tabindex="1" v-model="employee.EmployeePosition" />
                            </div>
                        </div>

                        <div class="input-section-right input-section">
                            <div class="d-center-flex c-grid-col">
                                <div class="input-swapper v-col-4 cs-calender">
                                    <div class="input-label">Ngày sinh</div>
                                    <div class="cs-calender-input" v-click-outside="closeBirthdayCalender">
                                        <input type="date" name="" tabindex="1" v-model="employee.DateOfBirth" />
                                        <div class="calender-icon" @click="showDateOfBirthCalender = !showDateOfBirthCalender">
                                            <div class="svg-icon svg-calender"></div>
                                        </div>

                                        <BaseDatePicker :dateTime.sync="employee.DateOfBirth" :isShow.sync="showDateOfBirthCalender" />
                                    </div>
                                </div>
                                <div class="input-swapper v-col-6 gender-swapper">
                                    <div class="input-label">Giới tính</div>
                                    <div class="d-center-flex gender">
                                        <label for="female">
                                            <input type="radio" name="gender" id="female" value="0" v-model="employee.Gender" tabindex="1" />
                                            <span class="circle"></span>
                                            <span class="input-lable">Nam</span>
                                        </label>
                                        <label for="male">
                                            <input type="radio" name="gender" id="male" value="1" v-model="employee.Gender" tabindex="1" />
                                            <span class="circle"></span>
                                            <span class="input-lable">Nữ</span>
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="d-center-flex c-grid-col">
                                <div class="input-swapper v-col-6">
                                    <div class="input-label">Số CMND</div>
                                    <input type="text" name="" tabindex="1" v-model="employee.IdentityNumber" />
                                </div>
                                <div class="input-swapper v-col-4 cs-calender">
                                    <div class="input-label">Ngày cấp</div>
                                    <div class="cs-calender-input">
                                        <input type="date" name="" tabindex="1" v-model="employee.IdentityDate" />
                                        <div class="calender-icon" @click="showIndentityDateCalender = !showIndentityDateCalender" tabindex="1">
                                            <div class="svg-icon svg-calender"></div>
                                        </div>

                                        <BaseDatePicker :dateTime.sync="employee.IdentityDate" :isShow.sync="showIndentityDateCalender" />
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
                        <div class="btn cancel-btn" tabindex="1">Hủy</div>
                    </div>
                    <div class="btn-right d-flex">
                        <div class="btn save-btn" title="Cất (Ctr + S)" tabindex="1">Cất</div>
                        <div class="btn add-save-btn" title="Cất và thêm" tabindex="1">Cất và thêm</div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    // import { ErrorMessage } from '@/environment/message';
    import BaseDatePicker from '@/components/common/BaseDatePicker';
    import axios from 'axios';
    // import { Validator } from '@/helper/validate';

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

                // Cờ Update, Add
                formMode: 'add',
                // Ẩn hiện thanh loading
                showLoading: false,

                // Show Birthday Calender
                showDateOfBirthCalender: false,
                // Show Calender ngày nhập chứng minh thư nhân dân
                showIndentityDateCalender: false,
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
        },
        methods: {
            // Xóa thông báo lỗi khi đóng cửa sổ
            deleteErrorWhenClose() {
                this.$emit('closeModal');
                var inputs = document.querySelectorAll('input');

                // Xóa viền lỗi
                inputs.forEach((item) => {
                    item.classList.remove('value-error');
                });
            },

            // Thêm mới người dùng khi nhấn Save
            async createNewCustomer() {
                try {
                    this.isShow = true;
                    var res = await axios.post('https://localhost:44388/api/v1/Customers', this.customer);
                    this.isShow = false;
                    // Nếu trả về 201 thì thông báo cho người dùng thêm thành công
                    if (res.status == 201) {
                        this.$emit('closeModal');
                        this.$emit('reload');
                    }
                } catch (error) {
                    console.log(error);
                }
            },

            closeBirthdayCalender() {
                this.showDateOfBirthCalender = false;
            },
        },

        updated() {},

        // created() {
        //     this.getCustomerGroup();
        // },
    };
</script>

<style lang="scss" scoped>
    @import '../../style/layout/EmployeePopUpAdd';
</style>
