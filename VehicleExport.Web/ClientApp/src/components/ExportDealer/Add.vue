<template>
    <export-dealer-fields :item="item" v-on:submit="onSubmit" v-on:cancel="onCancel">
      <template v-slot:save>Save Enrolled Dealer</template>
    </export-dealer-fields>
</template>

<script>
import axios from "axios";
import FormMixin from '../Mixins/FormMixin.vue';

export default {
  name: "ExportDealerAdd",
  mixins: [FormMixin],
  props: ['exportId'],
  data() {
    return {
      item: {}
    };
  },
  computed: {
  },
  methods: {
    load: function () {
      axios
        .get('/api/exportDealers/new')
        .then(response => {
          this.item = response.data;

          if (this.exportId)
            this.item.exportId = this.exportId;
        })
        .catch(error => {
          this.processAddErrorResponse(error, 'Enrolled Dealer');
        });
    },
    onSubmit(evt) {
      let url = '/api/exportDealers';

      axios
        .post(url, this.item)
        .then(response => {
          this.item = response.data;

          this.processAddSuccessResponse(response, 'Enrolled Dealer');
          this.$emit('success');
        })
        .catch(error => {
          this.processAddErrorResponse(error, 'Enrolled Dealer');
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