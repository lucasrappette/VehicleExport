<template>
  <list-page-template page-title="Dealers">
    <filtered-table :settings="tableSettings">
    </filtered-table>
  </list-page-template>
</template>

<script>
import axios from "axios";

export default {
  name: "DealerList",
  props: {},
  data() {
    let base = this;
    return {
      tableSettings: {
        endpoint: '/api/dealers',
        showNewButton: false,
        defaultLimit: 100,
        columns: [
          {
            key: 'dealerId',
            name: 'ID',
            visible: false,
            sortable: true,
            type: 'text'
          },
          {
            key: 'dealerName',
            name: 'Name',
            visible: true,
            sortable: true,
            type: 'text'
          }
        ],
        getDefaultFilter: function () {
          return '';
        },
        includes: [
          
        ]
      }
    }
  },
  methods: {
  },
  computed: {
  },
  mounted () {
  }
};
</script>