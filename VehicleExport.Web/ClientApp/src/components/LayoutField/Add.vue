<template>
  <form-page-template :page-title="pageTitle" :item="item">
    <layout-field-fields :item="item" v-on:submit="onSubmit" v-on:cancel="onCancel">
      <template v-slot:save>Add Layout Field</template>
    </layout-field-fields>
  </form-page-template>
</template>

<script>
import axios from "axios";
import FormMixin from '../Mixins/FormMixin.vue';

export default {
  name: "LayoutFieldAdd",
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
      return 'New Layout Field' + (this.itemTitle && this.itemTitle.length > 0 ? ': ' + this.itemTitle : '');
    }
  },
  methods: {
    load: function () {
      axios
        .get('/api/layoutFields/new')
        .then(response => {
          this.item = response.data;
        })
        .catch(error => {
          this.processAddErrorResponse(error, 'layout field');
        });
    },
    onCancel(evt) {
      this.$router.push('/layoutField');
    },
    onSubmit(evt) {
      let url = '/api/layoutFields?context=WebApiElevated';

      axios
        .post(url, this.item)
        .then(response => {
          this.item = response.data;

          this.processAddSuccessResponse(response, 'layout field');
          //Dispatch here
          this.$store.dispatch('cachedData/reloadLayoutFields');
          this.$router.push('/layoutField');
        })
        .catch(error => {
          this.processAddErrorResponse(error, 'layout field');
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