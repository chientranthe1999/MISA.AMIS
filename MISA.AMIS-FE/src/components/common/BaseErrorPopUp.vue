<template>
    <transition name="fade">
        <div class="dialog-swapper" v-if="isShow">
            <div class="dialog">
                <div class="dialog__infor">
                    <div class="dialog__infor-icon svg-icon-48 svg-error"></div>
                    <p>{{ message }}</p>
                </div>
                <div class="break-line"></div>
                <div class="dialog__footer">
                    <div class="dialog__footer-cancel" @click="close">Đóng</div>
                </div>
            </div>
        </div>
    </transition>
</template>

<script>
    export default {
        name: 'BaseErrorPopUp',

        props: {
            message: {
                type: String,
                default: '',
            },

            isShow: {
                type: Boolean,
                default: false,
            },
        },

        methods: {
            close() {
                this.$emit('update:isShow', false);
            },
        },
    };
</script>

<style scoped lang="scss">
    .dialog-swapper {
        position: fixed;
        top: 0;
        right: 0;
        bottom: 0;
        left: 0;
        background-color: rgba(0, 0, 0, 0.5);
        font-size: 13px;
        z-index: 10;
    }

    .dialog {
        position: absolute;
        right: 50%;
        top: 50%;
        transform: translate(50%, -50%);
        background-color: white;
        border-radius: 4px;
        padding-top: 24px;
        overflow: hidden;
        width: 444px;
        min-width: 444px;
        padding: 32px;

        &__infor {
            display: flex;
            align-items: center;
            margin-bottom: 32px;
            > p {
                flex: 1;
                padding: 0 0 0 16px;
                color: #111111;
            }
        }

        .break-line {
            border-top: 1px solid #b8bcc3;
            margin-bottom: 20px;
        }

        &__footer {
            display: flex;
            align-items: center;
            justify-content: center;
            > div {
                height: 36px;
                border-radius: 4px;
                // line-height: 40px;
                cursor: pointer;
                width: 100px;
                text-align: center;
                font-size: 13px;
                user-select: none;
                padding: 8px 12px;
            }

            &-cancel {
                background-color: #2ca01c;
                color: #fff;
            }

            &-cancel:hover {
                background-color: #35bf22;
            }
        }
    }
</style>
