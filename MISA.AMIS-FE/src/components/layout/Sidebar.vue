<template>
    <!-- Side Bar -->
    <div class="sidebar">
        <!-- Sidebar top  -->
        <div class="sidebar__top d-flex">
            <div class="svg-icon more-app"></div>
            <img src="../../assets/logo.svg" alt="" />
        </div>
        <!-- Sidebar main -->
        <div class="sidebar__main">
            <div class="sidebar__main-list" v-for="sideBarItem in sideBarItems" :key="sideBarItem.title" @click="setActive">
                <div class="sidebar__main-list-img">
                    <div class="img-icon svg-icon" :style="{ maskPosition: sideBarItem.iconPosition }"></div>
                </div>
                <p class="sidebar__main-list-text">{{ sideBarItem.title }}</p>
            </div>
        </div>
    </div>
    <!-- End side bar -->
</template>

<script>
    export default {
        name: 'sidebar',
        data() {
            return {
                sideBarItems: [
                    { iconPosition: '-30px -1628px', title: 'Tổng quan' },
                    { iconPosition: '-73px -1628px', title: 'Tiền mặt' },
                    { iconPosition: '-117px -1628px', title: 'Tiền gửi' },
                    { iconPosition: '-161px -1628px', title: 'Mua hàng' },
                    { iconPosition: '-204px -1628px', title: 'Bán hàng' },
                    { iconPosition: '-291px -1628px', title: 'Kho' },
                    { iconPosition: '-336px -1628px', title: 'Công cụ dụng cụ' },
                    { iconPosition: '-378px -1630px', title: 'Tài sản cố định' },
                    { iconPosition: '-423px -1630px', title: 'Thuế' },
                    { iconPosition: '-467px -1628px', title: 'Giá thành' },
                    { iconPosition: '-510px -1628px', title: 'Tổng hợp' },
                    { iconPosition: '-378px -1659px', title: 'Ngân sách' },
                    { iconPosition: '-547px -1628px', title: 'Báo cáo' },
                    { iconPosition: '-204px -1664px', title: 'Phân tích tài chính' },
                ],
            };
        },

        methods: {
            setActive(e) {
                var sideBars = document.querySelectorAll('.sidebar__main-list');

                sideBars.forEach((sideBar) => {
                    sideBar.classList.remove('active');
                });
                e.currentTarget.classList.add('active');
            },
        },
    };
</script>

<style scoped lang="scss">
    @import '@/style/layout/Sidebar.scss';
</style>
