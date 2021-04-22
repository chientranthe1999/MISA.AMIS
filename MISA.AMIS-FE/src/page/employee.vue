<template>
    <div>
        <Sidebar />
        <div class="right-swapper">
            <Header />
            <Content />
        </div>
        <!-- <BaseSuccessMessage /> -->
    </div>
</template>

<script>
    export default {
        name: 'Employee',
        data() {
            return {
                employeeList: [],

                limmit: 20,

                offset: 0,

                pageNumber: 1,
            };
        },
    };
</script>

<style lang="scss">
    .right-swapper {
        float: left;
        width: calc(100% - 180px);
    }
</style>
