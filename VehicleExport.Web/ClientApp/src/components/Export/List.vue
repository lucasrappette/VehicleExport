<template>
  <list-page-template page-title="Exports">
    <filtered-table :settings="tableSettings" @rowClicked="onRowClicked" @newClicked="onNewClicked">
    </filtered-table>
  </list-page-template>
</template>

<script>
import axios from "axios";

export default {
  name: "ExportList",
  props: {},
  data() {
    let base = this;
    return {
      tableSettings: {
        endpoint: '/api/export',
        showNewButton: true,
        defaultLimit: 100,
        columns: [
          {
            key: 'name',
            name: 'Name',
            visible: true,
            sortable: true,
            type: 'text'
          },
          {
            key: 'layoutId',
            name: 'Layout',
            visible: true,
            sortable: true,
            type: 'select',
            selectOptions: [],
            selectOptionsSource: { storeModule: 'cachedData', storeAction: 'loadLayouts', storeGetter: 'layouts' }
          },
          {
            key: 'destinationId',
            name: 'Destination',
            visible: true,
            sortable: true,
            type: 'select',
            selectOptions: [],
            selectOptionsSource: { storeModule: 'cachedData', storeAction: 'loadDestinations', storeGetter: 'destinations' }
          }
        ],
        getDefaultFilter: function () {
          return '';
        }
      }
    }
  },
  methods: {
    onRowClicked: function (item, context) {
      this.$router.push('/export/' + item.exportId);
    },
    onNewClicked: function (filters) {
      this.$router.push('/export/add');
    }
  },
  computed: {
  },
  mounted () {
  }
};
</script>