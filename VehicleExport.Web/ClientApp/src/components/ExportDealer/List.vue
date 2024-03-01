<template>
  <div>
    <list-page-template page-title="Enrolled Dealers">
      <filtered-table v-if="tableSettingsLoaded === true" :key="reRenderCount" :settings="tableSettings" @rowClicked="onRowClicked" @newClicked="onNewClicked">
      </filtered-table>
      <b-spinner label="Spinning" v-if="tableSettingsLoaded === false"></b-spinner>
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
        
      },
      tableSettingsLoaded: false
    }
  },
  computed: {
  },
  methods: {
    loadTableSettings: function () {
      var defaultSettings = { 
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
            selectOptions: [],
            selectOptionsSource: { storeModule: 'cachedData', storeAction: 'loadDealers', storeGetter: 'dealers' }
          }
        ],
        getDefaultFilter: () => {
          if (this.exportId)
            return 'exportId="' + this.exportId + '"';

          return '';
        },
        includes: ['exportDealerParameters,exportDealerParameters.layoutField'],
        viewStorageName: '/export:exportDealer'
      };

      let url = '/api/export/'+ this.exportId
      + '?includes=' + 'layout,layout.layoutFieldMappings,layout.layoutFieldMappings.layoutField'
      + '&limit=1';

      axios
        .get(url)
        .then(response => {
          if(response.data)
          {
            var layoutFieldMappings = response.data.layout.layoutFieldMappings.filter(x => x.layoutField.layoutFieldTypeId == 2);
            if(layoutFieldMappings)
            {
              layoutFieldMappings.forEach((element, index) => {
                if(element.layoutField.layoutFieldTypeId == 2)
                {
                var newSetting = 
                  {
                    key: `exportDealerParameters.${index}.parameterValue`,
                    name: element.layoutField.name + '(P)',
                    visible: true,
                    sortable: true,
                    hideFilter: false
                  };
                defaultSettings.columns.push(newSetting);
                }
              });
            }
          }
          this.tableSettings = defaultSettings;
          this.tableSettingsLoaded = true;
          this.reRenderCount += 1;
        })
        .catch(error => {
          console.log(error);
        });
    },
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
      this.tableSettingsLoaded = false;
      this.loadTableSettings();
      this.$bvModal.hide('exportDealerAdd');
    },
    onEditSuccess: function (evt) {
      this.reRenderCount += 1;
      this.$bvModal.hide('exportDealerEdit');
    },
  },
  mounted () {
    this.loadTableSettings();
  }
};
</script>