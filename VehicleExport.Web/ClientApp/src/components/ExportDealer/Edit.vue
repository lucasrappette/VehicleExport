<template>
    <export-dealer-fields :item="item" v-on:submit="onSubmit" v-on:cancel="onCancel">
      <template v-slot:save>Save Enrolled Dealer</template>
    </export-dealer-fields>
</template>

<script>
import axios from "axios";
import FormMixin from '../Mixins/FormMixin.vue';
import { mapState, mapGetters, mapMutations, mapActions } from 'vuex'

export default {
  name: "ExportDealerEdit",
  mixins: [FormMixin],
  props: ['exportDealerId'],
  data() {
    return {
      item: {},
      itemTitle: 'to the enrolled dealer'
    };
  },
  computed: {
  },
  methods: {
    load: function () {
      let url = '/api/exportDealers/' + this.exportDealerId
      + '?includes=' + 'exportDealerParameters,exportDealerParameters.layoutField,export,export.layout,export.layout.layoutFieldMappings,export.layout.layoutFieldMappings.layoutField';

      axios
        .get(url)
        .then(response => {
          this.item = response.data;
          var layoutFieldMappings = response.data.export.layout.layoutFieldMappings;
          var layoutFieldParameters = layoutFieldMappings.filter(x => x.layoutField.layoutFieldTypeId == 2);
          layoutFieldParameters.forEach((element, index) =>
          {
            if(!this.item.exportDealerParameters.find(x => x.layoutFieldId == element.layoutFieldId))
            {
              this.item.exportDealerParameters.push({ 
                concurrencyCheck: null,
                dtmCreated: new Date(),
                exportDealerId: this.exportDealerId,
                exportDealerParameterId: 0,
                layoutFieldId: element.layoutFieldId,
                parameterValue: null,
                layoutField: element.layoutField
              });
            }
          });
        })
        .catch(error => {
          console.log(error);
        });
    },
    onSubmit(evt) {
      let parameterUrl = '/api'
      let url = '/api/exportDealers/saveExportDealerAndParameters';

      axios
        .put(url, this.item)
        .then(response => {
          this.item = response.data;

          this.processEditSuccessResponse(response, 'Enrolled Dealer');
          this.$emit('success');
        })
        .catch(error => {
          this.processEditErrorResponse(error, 'Enrolled Dealer');
        });
    },
    onCancel(evt) {
      this.$emit('cancel');
    },    
  },
  mounted () {
    this.load();
    // Use this instead of the previous line to test the "Loading" bar
    //window.setTimeout(this.load, 3000);
  }
};
</script>