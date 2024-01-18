<template>
  <div>
    <list-page-template page-title="Layout Field Map">
      <!--<filtered-table :settings="tableSettings" @rowClicked="onRowClicked" @newClicked="onNewClicked">-->
      <filtered-table :key="reRenderCount" :settings="tableSettings" @rowClicked="onRowClicked" @newClicked="onNewClicked">
      </filtered-table>
    </list-page-template>
    <b-modal id="layoutFieldMappingAdd" size="l" title="Add Mapping">
      <layout-field-map-add @success="onAddSuccess" @cancel="onAddCancel" :layoutId="this.layoutId" @onClosed="$bvModal.hide('layoutFieldMappingAdd')" />
      <template slot="modal-footer">
        <div />
      </template>
    </b-modal>
    <b-modal id="layoutFieldMappingEdit" size="l" title="Edit Mapping">
      <layout-field-map-edit @success="onEditSuccess" @cancel="onEditCancel" :layoutFieldMapId="this.selectedLayoutFieldMapId" @onClosed="$bvModal.hide('layoutFieldMappingEdit')" />
      <template slot="modal-footer">
        <div />
      </template>
    </b-modal>
  </div>
</template>

<script>
import axios from "axios";

export default {
  name: "LayoutFieldMapList",
  props: ['layoutId'],
  data() {
    return {
      reRenderCount: 0,
      selectedLayoutFieldMapId: null,
      tableSettings: {
        endpoint: '/api/layoutFieldsMap',
        showNewButton: true,
        defaultLimit: 100,
        defaultSortColumn: 'fieldOrder',
        columns: [
          {
            key: 'fieldOrder',
            name: 'Order',
            visible: true,
            sortable: true,
            type: 'number'
          },
          {
            key: 'layoutField.name',
            name: 'Layout Field Name',
            visible: true,
            sortable: true,
            type: 'text'
          },
          {
            key: 'layoutField.layoutFieldTypeId',
            name: 'Layout Field Type',
            visible: true,
            sortable: true,
            type: 'select',
            selectOptions: [],
            selectOptionsSource: { storeModule: 'cachedData', storeAction: 'loadLayoutFieldTypes', storeGetter: 'layoutFieldTypes' }
          },
          {
            key: 'headerLabel',
            name: 'Header Label',
            visible: true,
            sortable: true,
            type: 'text'
          },
        ],
        getDefaultFilter: () => {
          if (this.layoutId)
            return 'layoutId="' + this.layoutId + '"';

          return '';
        },
        includes: ['layoutField'],
        viewStorageName: '/layout:layoutFieldMap'
      }
    }
  },
  methods: {
    onRowClicked: function (item, context) {
      this.selectedLayoutFieldMapId = item.layoutFieldsMapId;
      this.$bvModal.show('layoutFieldMappingEdit');
    },
    onNewClicked: function (filters) {
      this.$bvModal.show('layoutFieldMappingAdd');
    },
    onAddCancel: function (evt) {
      this.$bvModal.hide('layoutFieldMappingAdd');
    },
    onEditCancel: function (evt) {
      this.$bvModal.hide('layoutFieldMappingEdit');
    },
    onAddSuccess: function (evt) {
      this.reRenderCount += 1;
      this.$bvModal.hide('layoutFieldMappingAdd');
    },
    onEditSuccess: function (evt) {
      this.reRenderCount += 1;
      this.$bvModal.hide('layoutFieldMappingEdit');
    },

  },
  computed: {
  },
  mounted () {
  }
};
</script>