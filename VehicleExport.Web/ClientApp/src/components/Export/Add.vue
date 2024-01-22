<template>
  <form-page-template :page-title="pageTitle" :item="item">
    <export-fields :item="item" v-on:submit="onSubmit" v-on:cancel="onCancel">
      <template v-slot:save>Add Export</template>
    </export-fields>
  </form-page-template>
</template>

<script>
import axios from "axios";
import FormMixin from '../Mixins/FormMixin.vue';

export default {
  name: "ExportAdd",
  mixins: [FormMixin],
  props: [],
  data() {
    return {
      item: {
        name: null
      }
    };
  },
  computed: {
    itemTitle: function () {
      if (this.item && this.item.name)
        return this.item.name;
      else
        return null;
    },
    pageTitle: function () {
      return 'New Export' + (this.itemTitle && this.itemTitle.length > 0 ? ': ' + this.itemTitle : '');
    }
  },
  methods: {
    load: function () {
      axios
        .get('/api/export/new')
        .then(response => {
          this.item = response.data;
        })
        .catch(error => {
          this.processAddErrorResponse(error, 'Export');
        });
    },
    onCancel(evt) {
      this.$router.push('/export');
    },
    onSubmit(evt) {
      let url = '/api/export?context=WebApiElevated';

      axios
        .post(url, this.item)
        .then(response => {
          this.item = response.data;

          this.processAddSuccessResponse(response, 'Export');
          this.$router.push('/export');
        })
        .catch(error => {
          this.processAddErrorResponse(error, 'Export');
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