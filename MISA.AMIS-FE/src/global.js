/**
 * Register Global Vue Component
 * @author: Chiến Nobi (09/04/2021)
 */

import Vue from 'vue';

import BaseLoader from '@/components/common/BaseLoader';
Vue.component('BaseLoader', BaseLoader);

import BaseSuccessMessage from '@/components/common/BaseSuccessMessage';
Vue.component('BaseSuccessMessage', BaseSuccessMessage);

import BaseDeleteWarning from '@/components/common/BaseDeleteWarning';
Vue.component('BaseDeleteWarning', BaseDeleteWarning);

import Content from '@/components/layout/Content';
Vue.component('Content', Content);

import Header from '@/components/layout/Header';
Vue.component('Header', Header);

import Sidebar from '@/components/layout/Sidebar';
Vue.component('Sidebar', Sidebar);