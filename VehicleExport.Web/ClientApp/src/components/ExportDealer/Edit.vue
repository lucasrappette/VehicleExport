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
      item: {}
    };
  },
  computed: {
  },
  methods: {
    load: function () {
      let url = '/api/exportDealers/' + this.exportDealerId;

      axios
        .get(url)
        .then(response => {
          this.item = response.data;

        })
        .catch(error => {
          console.log(error);
        });
    },
    onSubmit(evt) {
      let url = '/api/exportDealers/' + this.exportDealerId;

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