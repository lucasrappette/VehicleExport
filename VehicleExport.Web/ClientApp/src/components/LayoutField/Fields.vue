<template>
  <form-template @submit="onSubmit" @cancel="onCancel">
    <template v-slot:save><slot name="save"></slot></template>
    <template>
      <b-row class="mt-3">
        <b-col xs="12" sm="6" lg="3">
          <h4>Basic</h4>
          <hr />
          <text-control label="Layout Field Name" required v-model="item.name" :concurrency-check="item.concurrencyCheck"></text-control>
          <text-control label="Notes" v-model="item.notes" :concurrency-check="item.concurrencyCheck"></text-control>
          <select-list-control label="Layout Field Type" required v-model="item.layoutFieldTypeId" :options="nonNullLayoutFieldTypeSelectOptions" :concurrency-check="item.concurrencyCheck"></select-list-control>
        </b-col>
        <b-col v-if="item.layoutFieldTypeId == 1" xs="12" sm="6" lg="3">
          <h4>Database Layout Field Options</h4>
          <hr />
          <text-control label="Database Field Label" v-model="item.databaseFieldLabel" :concurrency-check="item.concurrencyCheck"></text-control>
          <textarea-control label="Database Field Sql Text" v-model="item.databaseFieldSqlText" :concurrency-check="item.concurrencyCheck"></textarea-control>
        </b-col>
        <b-col v-if="item.layoutFieldTypeId == 2" xs="12" sm="6" lg="3">
          <h4>Parameter Layout Field Options</h4>
          <hr />
          <text-control label="Parameter Name" v-model="item.parameter" :concurrency-check="item.concurrencyCheck"></text-control>
        </b-col>
      </b-row>
    </template>
  </form-template>
</template>

<script>
import { mapState, mapGetters } from 'vuex'

export default {
  name: "LayoutFieldFields",
  props: [
    'item'
  ],
  data() {
    return {
    };
  },
  computed: {
    ...mapState('cachedData', ['layoutFieldTypes']),
    nonNullLayoutFieldTypeSelectOptions: function () {
      return this.layoutFieldTypes.selectOptions.filter(x => x.value != null);
    },
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