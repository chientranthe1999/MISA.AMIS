<template>
    <div class="loading-indicator" v-if="isShow == true">
        <div class="loading-icon"></div>
    </div>
</template>

<script>
    export default {
        name: 'BaseLoader',

        props: {
            isShow: {
                type: Boolean,
                default: false,
            },
        },
    };
</script>

<style scoped lang="scss">
    .loading-indicator {
        position: absolute;
        top: 0;
        right: 0;
        left: 0;
        bottom: 0;
        display: flex;
        align-items: center;
        justify-content: center;
        z-index: 90;
        background-color: #fff;

        .loading-icon {
            width: 50px;
            height: 50px;
            background-image: url(../../assets/icon/loading.svg);
            background-size: cover;
            -webkit-animation: spin 2s linear infinite; /* Safari */
            animation: spin 2s linear infinite;
        }
    }

    @keyframes spin {
        0% {
            transform: rotate(0deg);
        }
        100% {
            transform: rotate(360deg);
        }
    }
</style>
