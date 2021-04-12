<template>
    <div class="employee-popup" id="employee-popup" :class="{ active: modalStatus }">
        <BaseLoader :isShow="isShow" />
        <div class="popup__content">
            <!-- Popup header -->
            <div class="popup__content-header d-center-flex">
                <div class="header-right d-center-flex">
                    <p class="header-title">Thông tin nhân viên</p>
                    <div class="type-choose d-center-flex">
                        <label for="customer">
                            <input type="checkbox" id="customer" value="0" v-model="genderValue" />
                            <span class="square"></span>
                            <span>Là khách hàng</span>
                        </label>
                        <label for="provider">
                            <input type="checkbox" id="provider" value="1" v-model="genderValue" />
                            <span class="square"></span>
                            <span>Là nhà cung cấp</span>
                        </label>
                    </div>
                </div>

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
                            <div class="d-center-flex grid-col">
                                <div class="input-swapper col-4">
                                    <div class="input-label">Mã <span>*</span></div>
                                    <input type="text" name="" tabindex="1" />
                                </div>
                                <div class="input-swapper col-6">
                                    <div class="input-label">Tên <span>*</span></div>
                                    <input type="text" name="" tabindex="1" />
                                </div>
                            </div>
                            <div class="input-swapper">
                                <div class="input-label">Đơn vị <span>*</span></div>
                                <input type="text" name="" tabindex="1" />
                            </div>
                            <div class="input-swapper">
                                <div class="input-label">Chức danh</div>
                                <input type="text" name="" tabindex="1" />
                            </div>
                        </div>

                        <div class="input-section-right input-section">
                            <div class="d-center-flex grid-col">
                                <div class="input-swapper col-4">
                                    <div class="input-label">Ngày sinh</div>
                                    <input type="date" name="" tabindex="1" />
                                </div>
                                <div class="input-swapper col-6 gender-swapper">
                                    <div class="input-label">Giới tính</div>
                                    <div class="d-center-flex gender">
                                        <label for="female">
                                            <input
                                                type="radio"
                                                name="gender"
                                                id="female"
                                                value="0"
                                                v-model="genderValue"
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
                                                v-model="genderValue"
                                            />
                                            <span class="circle"></span>
                                            <span class="input-lable">Nữ</span>
                                        </label>
                                    </div>
                                </div>
                            </div>
                            <div class="d-center-flex grid-col">
                                <div class="input-swapper col-6">
                                    <div class="input-label">Số CMND</div>
                                    <input type="text" name="" tabindex="1" />
                                </div>
                                <div class="input-swapper col-4">
                                    <div class="input-label">Ngày cấp</div>
                                    <input type="date" name="" tabindex="1" />
                                </div>
                            </div>
                            <div class="input-swapper">
                                <div class="input-label">Nơi cấp</div>
                                <input type="text" name="" tabindex="1" />
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
                                    <input type="text" name="" tabindex="1" />
                                </div>

                                <div class="grid-col">
                                    <div class="input-swapper">
                                        <div class="input-label col-1-4">ĐT di động</div>
                                        <input type="text" name="" tabindex="1" />
                                    </div>
                                    <div class="input-swapper">
                                        <div class="input-label col-1-4">ĐT cố định</div>
                                        <input type="text" name="" />
                                    </div>
                                    <div class="input-swapper">
                                        <div class="input-label col-1-4">Email</div>
                                        <input type="text" name="" tabindex="1" />
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
    import { ErrorMessage } from '@/environment/message';
    import axios from 'axios';
    import { Validator } from '@/helper/validate';

    export default {
        name: 'EmployeePopupAdd',

        // data
        data() {
            return {
                selectLists: [],
                // Cờ validate
                hasError: false,

                // Cờ focus
                count: 0,

                // Cờ Update, Add
                formMode: 'add',
                // Ẩn hiện thanh loading
                isShow: false,

                genderValue: [],
            };
        },

        // props
        props: {
            modalStatus: {
                type: Boolean,
                default: false,
            },
            customer: {
                type: Object,
                default() {
                    return {};
                },
            },
        },

        methods: {
            /**
             * Lấy danh sách nhóm khách hàng
             */
            async getCustomerGroup() {
                var response = [];
                var res = await axios.get('https://localhost:44388/api/v1/CustomerGroups');

                res.data.forEach((element) => {
                    response.push({ key: element.CustomerGroupId, value: element.CustomerGroupName });
                });

                this.selectLists = [...response];
            },

            /**
             * Validate Email
             */
            validateEmail(e) {
                var value = e.target.value;
                var parentNode = e.target.parentNode;
                var errorNode;
                // Kiểm tra email có rỗng không
                // Nếu không rỗng, kiểm tra định dạnh Email

                if (Validator.validateEmpty(value)) {
                    // Xóa viền đỏ khi không rỗng
                    e.target.classList.remove('value-error');
                    // Kiểm tra định dạng email
                    if (!Validator.validateEmailFormat(value)) {
                        errorNode = this.createErrorNode(ErrorMessage.errorEmailFormat);
                        parentNode.appendChild(errorNode);
                    }
                } else {
                    e.target.classList.add('value-error');
                    errorNode = this.createErrorNode(ErrorMessage.doNotEmpty('Email'));
                    parentNode.appendChild(errorNode);
                }
            },
            /**
             * Validate CustomerCode
             * Không được empty
             * Không được phép trùng
             */
            validateCustomerCode(e) {
                var value = e.target.value;
                var parentNode = e.target.parentNode;
                var errorNode;

                // Kiểm tra rỗng lỗi
                if (Validator.validateEmpty(value)) {
                    // Xóa viền đỏ khi không rỗng
                    e.target.classList.remove('value-error');

                    // Kiểm tra customerCode đã tồn tại chưa
                    Validator.validateCustomerCode(value).then((res) => {
                        if (!res) {
                            errorNode = this.createErrorNode(ErrorMessage.duplicateCustomerCode);
                            parentNode.appendChild(errorNode);
                        }
                    });
                } else {
                    e.target.classList.add('value-error');
                    errorNode = this.createErrorNode(ErrorMessage.doNotEmpty('Mã khách hàng'));
                    parentNode.appendChild(errorNode);
                }
            },

            /**
             * Validate số điện thoại
             * Có 10 hoặc 11 số
             * Không được có chữ
             */

            // helper _methods
            /**
             * Tạo ra thông báo lỗi
             */
            createErrorNode(msg) {
                var errorNode = document.createElement('div');
                errorNode.className = 'data-append';
                errorNode.innerHTML = msg;
                return errorNode;
            },

            // Xóa thông báo lỗi khi focus
            deleteErrorWhenFocus(e) {
                var parentNode = e.target.parentNode;
                e.target.classList.remove('value-error');
                var errorNode = parentNode.querySelector('.data-append');
                if (errorNode != null) {
                    parentNode.removeChild(errorNode);
                }
            },

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
                    this.customer.CustomerGroupId = '19165ed7-212e-21c4-0428-030d4265475f';
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
        },

        updated() {
            this.count++;
            // Mở lần đầu tiên thì focus vào input đầu tiên
            // Update lần đầu tiên khi gọi xong API getCustomerGroup
            // Update lần 2 khi modal status prop thay đổi
            if (this.count == 2) {
                document.querySelector('#customerCode').focus();
            }
            console.log(this.customer.DateOfBith);
        },

        created() {
            this.getCustomerGroup();
        },
    };
</script>

<style lang="scss">
    @import '@/style/layout/EmployeePopUpAdd';
</style>
