<template>
  <form-template @submit="onSubmit" @cancel="onCancel">
    <template v-slot:save><slot name="save"></slot></template>
    <template>
      <b-row class="mt-3">
        <b-col xs="12" sm="12" lg="12">
          <h4>Enrolled Dealer</h4>
            <hr />
            <select-list-control label="Dealer" required v-model="item.dealerId" :options="nonNullDealerSelectOptions" :concurrency-check="item.concurrencyCheck"></select-list-control>
        </b-col>
      </b-row>
    </template>
  </form-template>
</template>

<script>
import { mapState, mapGetters } from 'vuex'

export default {
  name: "ExportDealerFields",
  props: [
    'item'
  ],
  data() {
    return {
    };
  },
  computed: {
    ...mapState('cachedData', ['dealers']),
    nonNullDealerSelectOptions: function () {
      return this.dealers.selectOptions.filter(x => x.value != null);
    },
  },
  methods: {
    load() {
    },
    onSubmit(evt) {
      this.$emit('submit');
    },
    onCancel(evt) {
      this.$emit('cancel');
    },
  },
  mounted() {
    this.load();
  }
};
</script>