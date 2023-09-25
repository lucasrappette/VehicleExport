<template>
  <form-template @submit="onSubmit" @cancel="onCancel">
    <template v-slot:save><slot name="save"></slot></template>
    <template>
      <b-row class="mt-3">
        <b-col xs="12" sm="6" lg="3">
          <h4>Basic</h4>
          <hr />
          <text-control label="Layout Name" required v-model="item.name" :concurrency-check="item.concurrencyCheck"></text-control>
          <text-control label="Description" required v-model="item.description" :concurrency-check="item.concurrencyCheck"></text-control>
          <select-list-control label="Data Source Type Id" required v-model="item.layoutDataSourceTypeId" :options="nonNullLayoutDataSourceTypeSelectOptions" :concurrency-check="item.concurrencyCheck"></select-list-control>
          <text-control v-if="item.layoutDataSourceTypeId == 2" label="Stored Procedure Name" v-model="item.storedProcedureName" :concurrency-check="item.concurrencyCheck"></text-control>
        </b-col>
        <b-col xs="12" sm="6" lg="3">
          <h4>Filters</h4>
          <hr />
          <multi-select-list-control label="Makes" required v-model="item.makesList" :options="nonNullStateSelectOptions" :concurrency-check="item.concurrencyCheck"></multi-select-list-control>
          <checkbox-control label="Certified Only?" v-model="item.certifiedOnly" :concurrency-check="item.concurrencyCheck"></checkbox-control>
          <checkbox-control label="New Vehicles?" v-model="item.newVehicles" :concurrency-check="item.concurrencyCheck"></checkbox-control>
          <checkbox-control label="Used Vehicles?" v-model="item.usedVehicles" :concurrency-check="item.concurrencyCheck"></checkbox-control>
          <multi-select-list-control label="Warranties" required v-model="item.warrantiesList" :options="nonNullStateSelectOptions" :concurrency-check="item.concurrencyCheck"></multi-select-list-control>
          <multi-select-list-control label="Products" required v-model="item.productsList" :options="nonNullStateSelectOptions" :concurrency-check="item.concurrencyCheck"></multi-select-list-control>
        </b-col>
      </b-row>
    </template>
  </form-template>
</template>

<script>
import { mapState, mapGetters } from 'vuex'

export default {
  name: "LayoutFields",
  props: [
    'item'
  ],
  data() {
    return {
    };
  },
  computed: {
    ...mapState('cachedData', ['layoutDataSourceTypes','stateSelectOptions']),
    nonNullLayoutDataSourceTypeSelectOptions: function () {
      return this.layoutDataSourceTypes.selectOptions.filter(x => x.value != null);
    },
    nonNullStateSelectOptions: function () {
      return this.stateSelectOptions;
    }
  },
  methods: {
    onCancel(evt) {
      this.$emit('cancel');
    },
    onSubmit(evt) {
      this.$emit('submit');
    }
  }
};
</script>