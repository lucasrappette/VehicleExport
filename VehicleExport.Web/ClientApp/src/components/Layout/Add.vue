<template>
  <form-page-template :page-title="pageTitle" :item="item">
    <layout-fields :item="item" v-on:submit="onSubmit" v-on:cancel="onCancel">
      <template v-slot:save>Add Layout</template>
    </layout-fields>
  </form-page-template>
</template>

<script>
import axios from "axios";
import FormMixin from '../Mixins/FormMixin.vue';

export default {
  name: "LayoutAdd",
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
      return 'New Layout' + (this.itemTitle && this.itemTitle.length > 0 ? ': ' + this.itemTitle : '');
    }
  },
  methods: {
    load: function () {
      axios
        .get('/api/layout/new')
        .then(response => {
          this.item = response.data;
        })
        .catch(error => {
          this.processAddErrorResponse(error, 'layout');
        });
    },
    onCancel(evt) {
      this.$router.push('/layout');
    },
    onSubmit(evt) {
      let url = '/api/layout?context=WebApiElevated';

      axios
        .post(url, this.item)
        .then(response => {
          this.item = response.data;

          this.processAddSuccessResponse(response, 'layout');
          //Dispatch here
          this.$router.push('layout');
        })
        .catch(error => {
          this.processAddErrorResponse(error, 'layout');
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