<template>
  <div>
    <layout-field-map-fields :item="item" v-on:submit="onSubmit" v-on:cancel="onCancel" :showFieldOrder="true">
      <template v-slot:save>Save Layout Field Mapping</template>
    </layout-field-map-fields>
  </div>
</template>

<script>
import axios from "axios";
import FormMixin from '../Mixins/FormMixin.vue';
import { mapState, mapGetters, mapMutations, mapActions } from 'vuex'
import TextControl from '../Controls/TextControl.vue';

export default {
  components: { TextControl },
  name: "LayoutFieldMapEdit",
  mixins: [FormMixin],
  props: ['layoutFieldMapId'],
  data() {
    return {
      item: {},
      replacementOption: null,
      newFieldOrder: null
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
      let url = '/api/layoutFieldsMap/saveLayoutFieldMap/' + this.layoutFieldMapId;

      axios
        .put(url, this.item)
        .then(response => {
          this.item = response.data;

          this.processEditSuccessResponse(response, 'Layout Field Map');
          this.$emit('success');
        })
        .catch(error => {
          this.processEditErrorResponse(error, 'Layout Field Map');
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