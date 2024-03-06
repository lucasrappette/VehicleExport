import Vue from 'vue';
import Vuex from 'vuex';
import axios from "axios";

const STATE_UNLOADED = 0;
const STATE_LOADING = 1;
const STATE_LOADED = 2;

export default {
  namespaced: true,
  state: () => ({
    knownPageNames: [
      { path: '/', name: 'Home' },
      { path: '/add', name: 'Add New' },
      { path: '/content', name: 'Content' },
      { path: '/summary', name: 'Summary' },
      { path: '/export', name: 'Exports'},
      { path: '/dealer', name: 'Dealers' },
      { path: '/layout', name: 'Layouts' },
      { path: '/layoutField', name: 'Layout Fields' },
      { path: '/layoutFieldMap', name: 'Layout Field Map'},
      { path: '/destination', name: 'Destinations' },
      { path: '/applicationUser', name: 'Users' },
      { path: '/contentBlock', name: 'Content Blocks' },
      { path: '/job', name: 'Background Jobs' },
    ],
    applicationRoles: {
      loadState: STATE_UNLOADED,
      values: [],
      selectOptions: [],
      pendingResolves: [],
      pendingRejects: []
    },
    applicationUsers: {
      loadState: STATE_UNLOADED,
      values: [],
      selectOptions: [],
      pendingResolves: [],
      pendingRejects: []
    },
    dealers: {
      loadState: STATE_UNLOADED,
      values: [],
      selectOptions: [],
      pendingResolves: [],
      pendingRejects: []
    },
    destinations: {
      loadState: STATE_UNLOADED,
      values: [],
      selectOptions: [],
      pendingResolves: [],
      pendingRejects: []
    },
    protocolTypes: {
      loadState: STATE_UNLOADED,
      values: [],
      selectOptions: [],
      pendingResolves: [],
      pendingRejects: []
    },
    encryptionTypes: {
      loadState: STATE_UNLOADED,
      values: [],
      selectOptions: [],
      pendingResolves: [],
      pendingRejects: []
    },
    outputFormatTypes: {
      loadState: STATE_UNLOADED,
      values: [],
      selectOptions: [],
      pendingResolves: [],
      pendingRejects: []
    },
    transferModeTypes: {
      loadState: STATE_UNLOADED,
      values: [],
      selectOptions: [],
      pendingResolves: [],
      pendingRejects: []
    },
    layoutFieldTypes: {
      loadState: STATE_UNLOADED,
      values: [],
      selectOptions: [],
      pendingResolves: [],
      pendingRejects: []
    },
    layoutFields: {
      loadState: STATE_UNLOADED,
      values: [],
      selectOptions: [],
      pendingResolves: [],
      pendingRejects: []
    },
    layouts: {
      loadState: STATE_UNLOADED,
      values: [],
      selectOptions: [],
      pendingResolves: [],
      pendingRejects: []
    },
    layoutDataSourceTypes: {
      loadState: STATE_UNLOADED,
      values: [],
      selectOptions: [],
      pendingResolves: [],
      pendingRejects: []
    },
    makes: {
      loadState: STATE_UNLOADED,
      values: [],
      selectOptions: [],
      pendingResolves: [],
      pendingRejects: []
    },
    products: {
      loadState: STATE_UNLOADED,
      values: [],
      selectOptions: [],
      pendingResolves: [],
      pendingRejects: []
    },
    warranties: {
      loadState: STATE_UNLOADED,
      values: [],
      selectOptions: [],
      pendingResolves: [],
      pendingRejects: []
    },
  }),
  mutations: {
    SET_KNOWN_PAGE_NAME(state, item) {
      let existing = state.knownPageNames.find(x => x.path == item.path);

      if (existing)
        existing.name = item.name;
      else
        state.knownPageNames.push({
          path: item.path,
          name: item.name
        });
    },
    ADD_PENDING_PROMISE(state, data) {
      state[data.type].pendingResolves.push(data.resolve);
      state[data.type].pendingRejects.push(data.reject);
    },
    CLEAR_PENDING_PROMISES(state, data) {
      state[data.type].pendingResolves.length = 0;
      state[data.type].pendingRejects.length = 0;
    },
    SET_LOAD_STATE(state, data) {
      state[data.type].loadState = data.loadState;
    },
    LOAD_APPLICATION_ROLES(state, values) {
      state.applicationRoles.values = values;

      state.applicationRoles.selectOptions = values.map(x => ({
        text: x.name,
        value: x.id,
        sortOrder: x.sortOrder,
        description: x.description
      }));

      state.applicationRoles.selectOptions.unshift({
        text: '',
        value: null
      });

      state.applicationRoles.loadState = STATE_LOADED;
    },
    LOAD_APPLICATION_USERS(state, values) {
      state.applicationUsers.values = values;

      state.applicationUsers.selectOptions = values.map(x => ({
        text: x.firstName + " " + x.lastName,
        value: x.id,
        sortOrder: x.firstName,
      }));

      state.applicationUsers.selectOptions.unshift({
        text: '',
        value: null
      });

      state.applicationUsers.loadState = STATE_LOADED;
    },
    LOAD_DEALERS(state, values) {
      state.dealers.values = values;

      state.dealers.selectOptions = values.map(x => ({
        text: x.dealerName,
        value: x.dealerId
      }));

      state.dealers.selectOptions.unshift({
        text: '',
        value: null
      });

      state.dealers.loadState = STATE_LOADED;
    },
    LOAD_PRODUCTS(state, values) {
      state.products.values = values;

      state.products.selectOptions = values.map(x => ({
        text: x.productName,
        value: x.productId
      }));

      state.products.selectOptions.unshift({
        text: '',
        value: null
      });

      state.products.loadState = STATE_LOADED;
    },
    LOAD_MAKES(state, values) {
      state.makes.values = values;

      state.makes.selectOptions = values.map(x => ({
        text: x.make,
        value: x.make
      }));

      state.makes.selectOptions.unshift({
        text: '',
        value: null
      });

      state.makes.loadState = STATE_LOADED;
    },
    LOAD_WARRANTIES(state, values) {
      state.warranties.values = values;

      state.warranties.selectOptions = values.map(x => ({
        text: x.warrantyName,
        value: x.warrantyId
      }));

      state.warranties.selectOptions.unshift({
        text: '',
        value: null
      });

      state.warranties.loadState = STATE_LOADED;
    },
    LOAD_PROTOCOL_TYPES(state, values) {
      state.protocolTypes.values = values;

      state.protocolTypes.selectOptions = values.map(x => ({
        text: x.description,
        value: x.protocolTypeId
      }));

      state.protocolTypes.loadState = STATE_LOADED;
    },
    LOAD_TRANSFER_MODE_TYPES(state, values) {
      state.transferModeTypes.values = values;

      state.transferModeTypes.selectOptions = values.map(x => ({
        text: x.description,
        value: x.transferModeTypeId
      }));

      state.transferModeTypes.loadState = STATE_LOADED;
    },
    LOAD_DESTINATIONS(state, values) {
      state.destinations.values = values;

      state.destinations.selectOptions = values.map(x => ({
        text: x.name,
        value: x.destinationId
      }));

      state.destinations.loadState = STATE_LOADED;
    },
    LOAD_ENCRYPTION_TYPES(state, values) {
      state.encryptionTypes.values = values;

      state.encryptionTypes.selectOptions = values.map(x => ({
        text: x.description,
        value: x.encryptionTypeId
      }));

      state.encryptionTypes.loadState = STATE_LOADED;
    },
    LOAD_OUTPUT_FORMAT_TYPES(state, values) {
      state.outputFormatTypes.values = values;

      state.outputFormatTypes.selectOptions = values.map(x => ({
        text: x.description,
        value: x.outputFormatTypeId
      }));

      state.outputFormatTypes.loadState = STATE_LOADED;
    },
    LOAD_LAYOUT_FIELD_TYPES(state, values) {
      state.layoutFieldTypes.values = values;

      state.layoutFieldTypes.selectOptions = values.map(x => ({
        text: x.description,
        value: x.layoutFieldTypeId
      }));

      state.layoutFieldTypes.loadState = STATE_LOADED;
    },
    LOAD_LAYOUT_FIELDS(state, values) {
      state.layoutFields.values = values;

      state.layoutFields.selectOptions = values.map(x => ({
        text: x.name,
        value: x.layoutFieldId
      }));

      state.layoutFields.loadState = STATE_LOADED;
    },
    LOAD_LAYOUTS(state, values) {
      state.layouts.values = values;

      state.layouts.selectOptions = values.map(x => ({
        text: x.name,
        value: x.layoutId
      }));

      state.layouts.loadState = STATE_LOADED;
    },
    LOAD_LAYOUT_DATA_SOURCE_TYPES(state, values) {
      state.layoutDataSourceTypes.values = values;

      state.layoutDataSourceTypes.selectOptions = values.map(x => ({
        text: x.description,
        value: x.layoutDataSourceTypeId
      }));

      state.layoutDataSourceTypes.loadState = STATE_LOADED;
    },
  },
  actions: {
    setKnownPageName({ state, commit }, item) {
      commit('SET_KNOWN_PAGE_NAME', item);
    },
    loadValues({ state, commit, rootState }, valType) {
      return new Promise((resolve, reject) => {
        if (state[valType.type].loadState == STATE_LOADED)
        {
          resolve();
          return;
        }

        if (state[valType.type].loadState == STATE_LOADING) {
          commit('ADD_PENDING_PROMISE', {
            type: valType.type,
            resolve: resolve,
            reject: reject
          });

          return;
        }

        commit('SET_LOAD_STATE', {
          type: valType.type,
          loadState: STATE_LOADING
        });
        //commit('SET_' + valType.commitType + '_LOAD_STATE', STATE_LOADING);

        let url = valType.url;
        url += '?limit=1000';

        if (valType.includes && valType.includes.length > 0)
          url += '&includes=' + valType.includes.join(',')

        if (valType.order)
          url += '&order=' + encodeURIComponent(valType.order);

        if (valType.filter)
          url += '&filter=' + encodeURIComponent(valType.filter);
        axios
          .get(url)
          .then(response => {
            commit('LOAD_' + valType.commitType, response.data);
            resolve();
            if (state[valType.type].pendingResolves) {
              state[valType.type].pendingResolves.forEach(function (callback) {
                callback();
              });
            }

            commit('CLEAR_PENDING_PROMISES', {
              type: valType.type,
            });
          })
          .catch(error => {
            console.log(error);

            reject();
            if (state[valType.type].pendingRejects) {
              state[valType.type].pendingRejects.forEach(function (callback) {
                callback();
              });
            }

            commit('CLEAR_PENDING_PROMISES', {
              type: valType.type,
            });
          });
      });
    },
    loadApplicationRoles({ commit, dispatch }) {
      return dispatch('loadValues', { 
        type: 'applicationRoles', 
        commitType: 'APPLICATION_ROLES', 
        url: '/api/applicationRole'
      });
    },
    reloadApplicationRoles({ commit, dispatch }) {
      commit('SET_LOAD_STATE', {
        type: 'applicationRoles',
        loadState: STATE_UNLOADED
      });
      dispatch('loadApplicationRoles');
    },
    loadProtocolTypes({ commit, dispatch }) {
      return dispatch('loadValues', { 
        type: 'protocolTypes', 
        commitType: 'PROTOCOL_TYPES', 
        url: '/api/protocolType',
        order: 'protocolTypeId'
      });
    },
    reloadProtocolTypes({ commit, dispatch }) {
      commit('SET_LOAD_STATE', {
        type: 'protocolTypes',
        loadState: STATE_UNLOADED
      });
      dispatch('loadProtocolTypes');
    },
    loadEncryptionTypes({ commit, dispatch }) {
      return dispatch('loadValues', { 
        type: 'encryptionTypes', 
        commitType: 'ENCRYPTION_TYPES', 
        url: '/api/encryptionType',
        order: 'encryptionTypeId'
      });
    },
    reloadEncryptionTypes({ commit, dispatch }) {
      commit('SET_LOAD_STATE', {
        type: 'encryptionTypes',
        loadState: STATE_UNLOADED
      });
      dispatch('loadEncryptionTypes');
    },
    loadTransferModeTypes({ commit, dispatch }) {
      return dispatch('loadValues', { 
        type: 'transferModeTypes', 
        commitType: 'TRANSFER_MODE_TYPES', 
        url: '/api/transferModeType',
        order: 'transferModeTypeId'
      });
    },
    reloadTransferModeTypes({ commit, dispatch }) {
      commit('SET_LOAD_STATE', {
        type: 'transferModeTypes',
        loadState: STATE_UNLOADED
      });
      dispatch('loadTransferModeTypes');
    },
    loadDestinations({ commit, dispatch }) {
      return dispatch('loadValues', { 
        type: 'destinations', 
        commitType: 'DESTINATIONS', 
        url: '/api/destination',
        order: 'destinationId'
      });
    },
    reloadDestinations({ commit, dispatch }) {
      commit('SET_LOAD_STATE', {
        type: 'destinations',
        loadState: STATE_UNLOADED
      });
      dispatch('loadDestinations');
    },
    loadOutputFormatTypes({ commit, dispatch }) {
      return dispatch('loadValues', { 
        type: 'outputFormatTypes', 
        commitType: 'OUTPUT_FORMAT_TYPES', 
        url: '/api/outputFormatType',
        order: 'outputFormatTypeId'
      });
    },
    reloadOutputFormatTypes({ commit, dispatch }) {
      commit('SET_LOAD_STATE', {
        type: 'outputFormatTypes',
        loadState: STATE_UNLOADED
      });
      dispatch('loadOutputFormatTypes');
    },
    loadLayoutFieldTypes({ commit, dispatch }) {
      return dispatch('loadValues', { 
        type: 'layoutFieldTypes', 
        commitType: 'LAYOUT_FIELD_TYPES', 
        url: '/api/layoutFieldType',
        order: 'layoutFieldTypeId'
      });
    },
    reloadLayoutFieldTypes({ commit, dispatch }) {
      commit('SET_LOAD_STATE', {
        type: 'layoutFieldTypes',
        loadState: STATE_UNLOADED
      });
      dispatch('loadLayoutFieldTypes');
    },
    loadLayoutFields({ commit, dispatch }) {
      return dispatch('loadValues', { 
        type: 'layoutFields', 
        commitType: 'LAYOUT_FIELDS', 
        url: '/api/layoutFields',
        order: 'layoutFieldId'
      });
    },
    reloadLayoutFields({ commit, dispatch }) {
      commit('SET_LOAD_STATE', {
        type: 'layoutFields',
        loadState: STATE_UNLOADED
      });
      dispatch('loadLayoutFields');
    },
    loadLayouts({ commit, dispatch }) {
      return dispatch('loadValues', { 
        type: 'layouts', 
        commitType: 'LAYOUTS', 
        url: '/api/layout',
        order: 'layoutId'
      });
    },
    reloadLayouts({ commit, dispatch }) {
      commit('SET_LOAD_STATE', {
        type: 'layouts',
        loadState: STATE_UNLOADED
      });
      dispatch('loadLayouts');
    },
    loadLayoutDataSourceTypes({ commit, dispatch }) {
      return dispatch('loadValues', { 
        type: 'layoutDataSourceTypes', 
        commitType: 'LAYOUT_DATA_SOURCE_TYPES', 
        url: '/api/layoutDataSourceType',
        order: 'layoutDataSourceTypeId'
      });
    },
    reloadLayoutDataSourceTypes({ commit, dispatch }) {
      commit('SET_LOAD_STATE', {
        type: 'layoutDataSourceTypes',
        loadState: STATE_UNLOADED
      });
      dispatch('loadLayoutDataSourceTypes');
    },
    loadApplicationUsers({ commit, dispatch }) {
      return dispatch('loadValues', { 
        type: 'applicationUsers', 
        commitType: 'APPLICATION_USERS', 
        url: '/api/applicationUser'
      });
    },
    reloadApplicationUsers({ commit, dispatch }) {
      commit('SET_LOAD_STATE', {
        type: 'applicationUsers',
        loadState: STATE_UNLOADED
      });
      dispatch('loadApplicationUsers');
    },
    loadDealers({ commit, dispatch }) {
      return dispatch('loadValues', { 
        type: 'dealers', 
        commitType: 'DEALERS', 
        url: '/api/dealers'
      });
    },
    reloadDealers({ commit, dispatch }) {
      commit('SET_LOAD_STATE', {
        type: 'dealers',
        loadState: STATE_UNLOADED
      });
      dispatch('loadDealers');
    },
    loadMakes({ commit, dispatch }) {
      return dispatch('loadValues', { 
        type: 'makes', 
        commitType: 'MAKES', 
        url: '/api/makes'
      });
    },
    reloadMakes({ commit, dispatch }) {
      commit('SET_LOAD_STATE', {
        type: 'makes',
        loadState: STATE_UNLOADED
      });
      dispatch('loadMakes');
    },
    loadProducts({ commit, dispatch }) {
      return dispatch('loadValues', { 
        type: 'products', 
        commitType: 'PRODUCTS', 
        url: '/api/products'
      });
    },
    reloadProducts({ commit, dispatch }) {
      commit('SET_LOAD_STATE', {
        type: 'products',
        loadState: STATE_UNLOADED
      });
      dispatch('loadProducts');
    },
    loadWarranties({ commit, dispatch }) {
      return dispatch('loadValues', { 
        type: 'warranties', 
        commitType: 'WARRANTIES', 
        url: '/api/warranties'
      });
    },
    reloadWarranties({ commit, dispatch }) {
      commit('SET_LOAD_STATE', {
        type: 'warranties',
        loadState: STATE_UNLOADED
      });
      dispatch('loadWarranties');
    },
    loadCachedData({ commit, dispatch }) {
      dispatch('loadApplicationRoles');
      dispatch('loadApplicationUsers');
      dispatch('loadProtocolTypes');
      dispatch('loadEncryptionTypes');
      dispatch('loadOutputFormatTypes');
      dispatch('loadLayoutFieldTypes');
      dispatch('loadLayoutFields');
      dispatch('loadLayouts');
      dispatch('loadTransferModeTypes');
      dispatch('loadLayoutDataSourceTypes');
      dispatch('loadDestinations');
      dispatch('loadDealers');
      dispatch('loadMakes');
      dispatch('loadProducts');
      dispatch('loadWarranties');
    },
    reloadCachedData({ commit, dispatch }) {
      dispatch('reloadApplicationRoles');
      dispatch('reloadApplicationUsers');
      dispatch('reloadProtocolTypes');
      dispatch('reloadEncryptionTypes');
      dispatch('reloadOutputFormatTypes');
      dispatch('reloadLayoutFieldTypes');
      dispatch('reloadLayoutFields');
      dispatch('reloadLayouts');
      dispatch('loadTransferModeTypes');
      dispatch('reloadLayoutDataSourceTypes');
      dispatch('reloadDestinations');
      dispatch('reloadDealers');
      dispatch('reloadMakes');
      dispatch('reloadWarranties');
      dispatch('reloadProducts');
    }
  },
  getters: {
  }
}