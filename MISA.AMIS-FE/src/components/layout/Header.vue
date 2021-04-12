<template>
    <!-- Header -->
    <div class="header">
        <!-- Header left-->
        <div class="header__left d-center-flex">
            <div class="header__toogle-btn svg-icon svg-toggle"></div>
            <div class="header__company d-center-flex">
                <p class="company-name">Công ty cổ phần XYZ</p>
                <div class="svg-icon svg-l-chevron-down svg-icon-14"></div>
            </div>
        </div>

        <!-- Header right-->
        <div class="header__right">
            <div class="header__search-box d-center-flex search-box">
                <input type="text" placeholder="Nhập vào từ khóa tìm kiếm" />
                <div class="svg-icon svg-search svg-icon-16"></div>
            </div>
            <div class="header__function d-center-flex">
                <div class="icon-swaper">
                    <div class="svg-icon svg-ellipsis"></div>
                </div>
                <div class="icon-swaper">
                    <div class="svg-icon svg-cog"></div>
                </div>
                <div class="icon-swaper">
                    <div class="svg-icon svg-message"></div>
                </div>
                <div class="icon-swaper">
                    <div class="svg-icon svg-help"></div>
                </div>
                <div class="icon-swaper">
                    <div class="svg-icon svg-notification"></div>
                </div>
            </div>
            <div class="header__user d-center-flex">
                <div class="user-avt"></div>
                <div class="user-name">Trần Thế Chiến</div>
                <div class="svg-icon svg-icon-14 svg-s-chevron-down"></div>
            </div>
        </div>
    </div>
    <!-- End header  -->
</template>

<script>
    export default {
        name: 'Header',
    };
</script>

<style lang="scss" scoped>
    @import '@/style/layout/Header.scss';
</style>
