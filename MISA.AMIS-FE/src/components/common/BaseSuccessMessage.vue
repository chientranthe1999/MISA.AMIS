<template>
    <transition name="fade">
        <div class="success-message d-flex" v-if="isShow">
            <div class="success-message-icon"><i class="far fa-check-circle"></i></div>
            <div>
                <p>Success</p>
                <p>{{ message }}</p>
            </div>
        </div>
    </transition>
</template>

<script>
    export default {
        name: 'BaseSuccessMessage',
        props: {
            isShow: {
                type: Boolean,
                default: true,
            },

            message: {
                type: String,
                default: '',
            },
        },
        updated() {
            setTimeout(() => {
                this.$emit('update:isShow', false);
            }, 4000);
        },
    };
</script>

<style lang="scss" scoped>
    $greenColor: #2ca01c;
    .success-message {
        position: fixed;
        right: 0;
        bottom: 80px;
        z-index: 5;
        padding: 10px;
        background-color: $greenColor;
        border-radius: 4px;
        color: white;
        align-items: center;
        justify-content: center;
        box-shadow: rgba(50, 50, 93, 0.25) 0px 50px 100px -20px, rgba(0, 0, 0, 0.3) 0px 30px 60px -30px;
        .success-message-icon {
            margin-right: 5px;
            font-size: 40px;
        }
        p {
            margin: 2px 2px;
        }
    }

    .fade-enter-active {
        transition: opacity 1s;
    }

    .fade-leave-active {
        transition: opacity 2s;
    }

    .fade-enter,
    .fade-leave-to {
        opacity: 0;
    }
</style>
