<template>
  <list-page-template page-title="Layout Fields">
    <filtered-table :settings="tableSettings" @rowClicked="onRowClicked" @newClicked="onNewClicked">
    </filtered-table>
  </list-page-template>
</template>

<script>
import axios from "axios";

export default {
  name: "LayoutFieldList",
  props: {},
  data() {
    let base = this;
    return {
      tableSettings: {
        endpoint: '/api/layoutFields',
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
            key: 'description',
            name: 'Description',
            visible: true,
            sortable: true,
            type: 'text'
          },
          {
            key: 'storedProcedureName',
            name: 'Stored Procedure Name',
            visible: true,
            sortable: true,
            type: 'text'
          },
          {
            key: 'contributerApplicationUserId',
            name: 'Salesperson',
            visible: true,
            sortable: true,
            type: 'select',
            selectOptions: [],
            selectOptionsSource: { storeModule: 'cachedData', storeAction: 'loadApplicationUsers', storeGetter: 'applicationUsers' }
          },
        ],
        getDefaultFilter: function () {
          return '';
        }
      }
    }
  },
  methods: {
    onRowClicked: function (item, context) {
      this.$router.push('/layoutField/' + item.layoutFieldId);
    },
    onNewClicked: function (filters) {
      this.$router.push('/layoutField/add');
    }
  },
  computed: {
  },
  mounted () {
  }
};
</script>