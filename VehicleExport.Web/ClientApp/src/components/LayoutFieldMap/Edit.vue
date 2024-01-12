<template>
    <layout-field-map-fields :item="item">
    </layout-field-map-fields>
</template>

<script>
import axios from "axios";
import FormMixin from '../Mixins/FormMixin.vue';
import { mapState, mapGetters, mapMutations, mapActions } from 'vuex'

export default {
  name: "LayoutFieldMapEdit",
  mixins: [FormMixin],
  props: ['layoutFieldMapId'],
  data() {
    return {
      item: null
    };
  },
  computed: {
  },
  methods: {
    load: function () {
      let url = '/api/layoutFieldsMap/' + this.layoutFieldMapId;

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
      let url = '/api/layoutFieldsMap/' + this.layoutFieldMapId;

      axios
        .put(url, this.item)
        .then(response => {
          this.item = response.data;

          this.processEditSuccessResponse(response, 'Layout Field Map');

        })
        .catch(error => {
          this.processEditErrorResponse(error, 'Layout Field Map');
        });
    }    
  },
  mounted () {
    this.load();
    // Use this instead of the previous line to test the "Loading" bar
    //window.setTimeout(this.load, 3000);
  }
};
</script>