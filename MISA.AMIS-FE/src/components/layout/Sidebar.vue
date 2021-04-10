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
            <div class="sidebar__main-list" v-for="sideBarItem in sideBarItems" :key="sideBarItem.title">
                <div class="sidebar__main-list-img">
                    <div class="img-icon svg-icon" :style="{ backgroundPosition: sideBarItem.iconPosition }"></div>
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
                    { iconPosition: '-30px -1628px', title: 'Tổng quan', iconPositionActive: '' },
                    { iconPosition: '-73px -1628px', title: 'Tiền mặt', iconPositionActive: '' },
                    { iconPosition: '-117px -1628px', title: 'Tiền gửi', iconPositionActive: '' },
                    { iconPosition: '-161px -1628px', title: 'Mua hàng', iconPositionActive: '' },
                    { iconPosition: '-204px -1628px', title: 'Bán hàng', iconPositionActive: '' },
                    { iconPosition: '-291px -1628px', title: 'Kho', iconPositionActive: '' },
                    { iconPosition: '-336px -1628px', title: 'Công cụ dụng cụ', iconPositionActive: '' },
                    { iconPosition: '-378px -1630px', title: 'Tài sản cố định', iconPositionActive: '' },
                    { iconPosition: '-423px -1630px', title: 'Thuế', iconPositionActive: '' },
                    { iconPosition: '-467px -1628px', title: 'Giá thành', iconPositionActive: '' },
                    { iconPosition: '-510px -1628px', title: 'Tổng hợp', iconPositionActive: '' },
                    { iconPosition: '-378px -1659px', title: 'Ngân sách', iconPositionActive: '' },
                    { iconPosition: '-547px -1628px', title: 'Báo cáo', iconPositionActive: '' },
                    { iconPosition: '-204px -1664px', title: 'Phân tích tài chính', iconPositionActive: '' },
                ],
            };
        },
    };
</script>

<style scoped lang="scss">
    @import '@/style/layout/Sidebar.scss';
</style>
