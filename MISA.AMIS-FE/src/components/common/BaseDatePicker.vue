<template>
    <div class="cs-date-picker" v-if="isShow">
        <v-app>
            <v-row>
                <v-date-picker v-model="datePickerValue" elevation="15" no-title color="#2ca01c"></v-date-picker>
            </v-row>
        </v-app>
    </div>
</template>

<script>
    export default {
        name: 'BaseDatePicker',

        computed: {
            datePickerValue: {
                get: function() {
                    return this.dateTime;
                },

                set: function(val) {
                    this.$emit('update:isShow', false);
                    this.$emit('update:dateTime', val);
                },
            },
        },

        props: {
            dateTime: {
                type: String,
                default: '',
            },

            isShow: {
                type: Boolean,
                default: false,
            },
        },
    };
</script>

<style>
    .cs-date-picker {
        position: absolute;
        z-index: 3;
        right: 10px;
        top: 50px;
    }

    .cs-date-picker .v-application--wrap {
        min-height: auto;
    }
</style>
