<template>
  <list-page-template page-title="Layouts">
    <filtered-table :settings="tableSettings" @rowClicked="onRowClicked" @newClicked="onNewClicked">
    </filtered-table>
  </list-page-template>
</template>

<script>
import axios from "axios";

export default {
  name: "LayoutList",
  props: {},
  data() {
    let base = this;
    return {
      tableSettings: {
        endpoint: '/api/layout',
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
        ],
        getDefaultFilter: function () {
          return '';
        }
      }
    }
  },
  methods: {
    onRowClicked: function (item, context) {
      this.$router.push('/layout/' + item.layoutId);
    },
    onNewClicked: function (filters) {
      this.$router.push('/layout/add');
    }
  },
  computed: {
  },
  mounted () {
  }
};
</script>