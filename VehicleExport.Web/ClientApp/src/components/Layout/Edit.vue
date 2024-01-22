<template>
  <form-page-template :page-title="pageTitle" :item="item">
    <b-nav pills v-if="item && item.layoutId && item.layoutDataSourceTypeId == 1">
      <b-nav-item :to="{ path: this.$route.path + '/layoutFieldMap' }">Layout Field Mapping</b-nav-item>
    </b-nav>
    <hr />
    <layout-fields :item="item" v-on:submit="onSubmit" v-on:cancel="onCancel">
      <template v-slot:save>Save Layout</template>
    </layout-fields>
  </form-page-template>
</template>

<script>
import axios from "axios";
import FormMixin from '../Mixins/FormMixin.vue';
import { mapState, mapGetters, mapMutations, mapActions } from 'vuex'

export default {
  name: "LayoutEdit",
  mixins: [FormMixin],
  props: ['id'],
  data() {
    return {
      item: null
    };
  },
  computed: {
    itemTitle: function () {
      if (!this.item)
        return null;
      return this.item.name;
    },
    pageTitle: function () {
      return 'Layout: ' + this.itemTitle;
    }
  },
  methods: {
    ...mapActions('cachedData', ['setKnownPageName']),
    load: function () {
      let url = '/api/layout/' + this.id + '?context=WebApiElevated';

      axios
        .get(url)
        .then(response => {
          this.item = response.data;

          this.setKnownPageName({ path: this.$route.path, name: this.item.name});
        })
        .catch(error => {
          console.log(error);
        });
    },
    onCancel(evt) {
      this.goToParentPage();
    },
    onSubmit(evt) {
      let url = '/api/layout/' + this.id + '?context=WebApiElevated';

      axios
        .put(url, this.item)
        .then(response => {
          this.item = response.data;
          //this.$store.dispatch('cachedData/reloadLayouts');
          this.processEditSuccessResponse(response, 'layout');
          this.$store.dispatch('cachedData/reloadLayouts');
          this.goToParentPage();
        })
        .catch(error => {
          this.processEditErrorResponse(error, 'layout');
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