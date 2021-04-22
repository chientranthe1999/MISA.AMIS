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
    };
</script>

<style lang="scss">
    .right-swapper {
        float: left;
        width: calc(100% - 180px);
    }
</style>
