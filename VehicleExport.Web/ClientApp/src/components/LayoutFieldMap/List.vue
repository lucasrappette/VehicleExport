<template>
  <div>
    <list-page-template page-title="Layout Field Map">
      <!--<filtered-table :settings="tableSettings" @rowClicked="onRowClicked" @newClicked="onNewClicked">-->
      <filtered-table :settings="tableSettings" @rowClicked="onRowClicked" @newClicked="onNewClicked">
      </filtered-table>
    </list-page-template>
    <b-modal id="layoutFieldMappingAdd" size="l" title="Add Mapping">
      <layout-field-map-add :layoutId="this.layoutId" @onClosed="$bvModal.hide('layoutFieldMappingAdd')" />
    </b-modal>
    <b-modal id="layoutFieldMappingEdit" size="l" title="Edit Mapping">
      <layout-field-map-edit :layoutFieldMapId="this.selectedLayoutFieldMapId" @onClosed="$bvModal.hide('layoutFieldMappingEdit')" />
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
      selectedLayoutFieldMapId: null,
      tableSettings: {
        endpoint: '/api/layoutFieldsMap',
        showNewButton: true,
        defaultLimit: 100,
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
  },
  computed: {
  },
  mounted () {
  }
};
</script>