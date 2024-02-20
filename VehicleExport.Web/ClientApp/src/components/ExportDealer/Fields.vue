<template>
  <form-template @submit="onSubmit" @cancel="onCancel">
    <template v-slot:save><slot name="save"></slot></template>
    <template>
      <b-row class="mt-3">
        <b-col xs="12" sm="12" lg="12">
          <h4>Enrolled Dealer</h4>
            <hr />
            <select-list-control label="Dealer" required v-model="item.dealerId" :options="nonNullDealerSelectOptions" :concurrency-check="item.concurrencyCheck"></select-list-control>
            <hr />
          <h5 v-if="item.exportDealerParameters && item.exportDealerParameters.length != 0">Parameters</h5>
            <div v-for="parameter in item.exportDealerParameters" v-bind:key="parameter.layoutFieldId">
              <text-control :label="parameter.layoutField.name" v-model="parameter.parameterValue" :concurrencyCheck="item.concurrencyCheck"></text-control>
            </div>
        </b-col>
      </b-row>
    </template>
  </form-template>
</template>

<script>
import { mapState, mapGetters } from 'vuex'
import TextControl from '../Controls/TextControl.vue';

export default {
  components: { TextControl },
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