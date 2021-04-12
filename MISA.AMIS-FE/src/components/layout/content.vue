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
                        <!-- <tr
                            v-for="customer in dataBinding"
                            :key="customer.CustomerId"
                            @dblclick="trOnClick(customer.CustomerId)"
                        >
                            <td>{{ customer.CustomerCode }}</td>
                            <td>{{ customer.FullName }}</td>
                            <td>{{ customer.Gender }}</td>
                            <td>{{ customer.Email }}</td>
                            <td>{{ customer.PhoneNumber }}</td>
                            <td>{{ formatDate(customer.DateOfBirth) }}</td>
                            <td style="max-width: 250px;">{{ customer.Address }}</td>
                            <td class="">
                                <div class="d-center-flex user-action">
                                    <p>Sửa</p>
                                    <div class="icon-swapper">
                                        <div class="svg-icon svg-icon-16 svg-s-arrow-blue-down" @click="test">
                                            <div class="data-more-action">
                                                <div class="action-list">Nhân bản</div>
                                                <div class="action-list">Xóa</div>
                                                <div class="action-list">Ngừng sử dụng</div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </td>
                        </tr> -->

                        <td class="">
                            <div class="d-center-flex user-action">
                                <p>Sửa</p>
                                <div class="icon-swapper">
                                    <div class="svg-icon svg-icon-16 svg-s-arrow-blue-down" @click="test">
                                        <div class="data-more-action">
                                            <div class="action-list">Nhân bản</div>
                                            <div class="action-list">Xóa</div>
                                            <div class="action-list">Ngừng sử dụng</div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tbody>
                </table>
            </div>

            <div class="data-more-action">
                <div class="action-list">Nhân bản</div>
                <div class="action-list">Xóa</div>
                <div class="action-list">Ngừng sử dụng</div>
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

        <EmployeePopupAdd
            :modalStatus="modalStatus"
            :customer="selectedCustomer"
            @closeModal="hideModal"
            @reload="reload"
        />
    </div>
    <!-- End content -->
</template>

<script>
    import { formatDate } from '@/helper/formatTable.js';
    import EmployeePopupAdd from '../popup/EmployeePopupAdd';
    import { customerApi } from '@/api/customerApi';

    export default {
        name: 'Content',

        data() {
            return {
                dataList: '',
                modalStatus: false,
                selectedCustomer: {},
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
                this.selectedCustomer = {};
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
            trOnClick(customerId) {
                customerApi
                    .getCustomerById(customerId)
                    .then((res) => {
                        this.selectedCustomer = res.data;
                        this.showModal();
                    })
                    .catch((e) => {
                        console.log(e);
                    });
            },

            test(e) {
                console.log(e);
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
