<template>
  <form-page-template :page-title="pageTitle" :item="item">
    <destination-fields :item="item" v-on:submit="onSubmit" v-on:cancel="onCancel">
      <template v-slot:save>Add Destination</template>
    </destination-fields>
  </form-page-template>
</template>

<script>
import axios from "axios";
import FormMixin from '../Mixins/FormMixin.vue';

export default {
  name: "DestinationAdd",
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
      return 'New Destination' + (this.itemTitle && this.itemTitle.length > 0 ? ': ' + this.itemTitle : '');
    }
  },
  methods: {
    load: function () {
      axios
        .get('/api/destination/new')
        .then(response => {
          this.item = response.data;
        })
        .catch(error => {
          this.processAddErrorResponse(error, 'dealer');
        });
    },
    onCancel(evt) {
      this.$router.push('/destination');
    },
    onSubmit(evt) {
      let url = '/api/destination?context=WebApiElevated';
      var config = {
      headers: {
        "Content-Type": "multipart/form-data"
        }
      };
      var myFormData = new FormData();
      for (const [key, value] of Object.entries(this.item)) {
        myFormData.append(key.toString(), value);
      };
      axios
        .post(url, myFormData, config)
        .then(response => {
          this.item = response.data;

          this.processAddSuccessResponse(response, 'destination');
          this.$store.dispatch('cachedData/reloadDestinations');

          this.$router.push('/destination');
        })
        .catch(error => {
          this.processAddErrorResponse(error, 'destination');
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