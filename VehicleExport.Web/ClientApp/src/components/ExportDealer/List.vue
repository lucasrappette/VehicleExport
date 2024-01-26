<template>
  <div>
    <list-page-template page-title="Enrolled Dealers">
      <filtered-table :key="reRenderCount" :settings="tableSettings" @rowClicked="onRowClicked" @newClicked="onNewClicked">
      </filtered-table>
    </list-page-template>
    <b-modal id="exportDealerAdd" size="l" title="Add Dealer">
      <export-dealer-add @success="onAddSuccess" @cancel="onAddCancel" :exportId="this.exportId" @onClosed="$bvModal.hide('exportDealerAdd')" />
      <template slot="modal-footer">
        <div />
      </template>
    </b-modal>
    <b-modal id="exportDealerEdit" size="l" title="Edit Dealer">
      <export-dealer-edit @success="onEditSuccess" @cancel="onEditCancel" :exportDealerId="this.selectedExportDealerId" @onClosed="$bvModal.hide('exportDealerEdit')" />
      <template slot="modal-footer">
        <div />
      </template>
    </b-modal>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "ExportDealerList",
  props: ['exportId'],
  data() {
    return {
      reRenderCount: 0,
      selectedExportDealerId: null,
      tableSettings: {
        endpoint: '/api/exportDealers',
        showNewButton: true,
        defaultLimit: 100,
        defaultSortColumn: 'exportDealerId',
        columns: [
          {
            key: 'dealerId',
            name: 'Enrolled Dealer Id',
            visible: true,
            sortable: true,
            type: 'select',
            type: 'select',
            selectOptions: [],
            selectOptionsSource: { storeModule: 'cachedData', storeAction: 'loadDealers', storeGetter: 'dealers' }
          }
        ],
        getDefaultFilter: () => {
          if (this.exportId)
            return 'exportId="' + this.exportId + '"';

          return '';
        },
        includes: [],
        viewStorageName: '/export:exportDealer'
      }
    }
  },
  methods: {
    onRowClicked: function (item, context) {
      this.selectedExportDealerId = item.exportDealerId;
      this.$bvModal.show('exportDealerEdit');
    },
    onNewClicked: function (filters) {
      this.$bvModal.show('exportDealerAdd');
    },
    onAddCancel: function (evt) {
      this.$bvModal.hide('exportDealerAdd');
    },
    onEditCancel: function (evt) {
      this.$bvModal.hide('exportDealerEdit');
    },
    onAddSuccess: function (evt) {
      this.reRenderCount += 1;
      this.$bvModal.hide('exportDealerAdd');
    },
    onEditSuccess: function (evt) {
      this.reRenderCount += 1;
      this.$bvModal.hide('exportDealerEdit');
    },

  },
  computed: {
  },
  mounted () {
  }
};
</script>