<template>
    <layout-field-map-fields :item="item" v-on:submit="onSubmit" v-on:cancel="onCancel" :showFieldOrder="false">
      <template v-slot:save>Save Layout Field Mapping</template>
    </layout-field-map-fields>
</template>

<script>
import axios from "axios";
import FormMixin from '../Mixins/FormMixin.vue';

export default {
  name: "LayoutFieldMapAdd",
  mixins: [FormMixin],
  props: ['layoutId'],
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
        .get('/api/layoutFieldsMap/new')
        .then(response => {
          this.item = response.data;

          if (this.layoutId)
            this.item.layoutId = this.layoutId;
        })
        .catch(error => {
          this.processAddErrorResponse(error, 'Layout Field Mapping');
        });
    },
    onSubmit(evt) {
      let url = '/api/layoutFieldsMap';

      axios
        .post(url, this.item)
        .then(response => {
          this.item = response.data;

          this.processAddSuccessResponse(response, 'Layout Field Mapping');
          this.$emit('success');
        })
        .catch(error => {
          this.processAddErrorResponse(error, 'Layout Field Mapping');
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