<template>
  <form-template @submit="onSubmit" @cancel="onCancel">
    <template v-slot:save><slot name="save"></slot></template>
    <template>
      <b-row class="mt-3">
        <b-col xs="12" sm="6" lg="3">
          <h4>Basic</h4>
          <hr />
          <text-control label="Export Name" required v-model="item.name" :concurrency-check="item.concurrencyCheck"></text-control>
          <select-list-control label="Layout" required v-model="item.layoutId" :options="nonNullLayoutSelectOptions" :concurrency-check="item.concurrencyCheck"></select-list-control>
          <select-list-control label="Destination" required v-model="item.destinationId" :options="nonNullDestinationSelectOptions" :concurrency-check="item.concurrencyCheck"></select-list-control>
        </b-col>
        <b-col xs="12" sm="6" lg="3">
          <h4>Run Times</h4>
          <hr />
          <time-picker-control topDescription="Run Time 1" required v-model="item.runTimeOne" :concurrency-check="item.concurrencyCheck"></time-picker-control>
          <time-picker-control topDescription="Run Time 2" v-model="item.runTimeTwo" :concurrency-check="item.concurrencyCheck"></time-picker-control>
        </b-col>
      </b-row>
    </template>
  </form-template>
</template>

<script>
import { mapState, mapGetters } from 'vuex'
import TimePickerControl from '../Controls/TimePickerControl.vue';

export default {
  components: { TimePickerControl },
  name: "LayoutFields",
  props: [
    'item'
  ],
  data() {
    return {
    };
  },
  computed: {
    ...mapState('cachedData', ['layouts','destinations']),
    nonNullLayoutSelectOptions: function () {
      return this.layouts.selectOptions.filter(x => x.value != null);
    },
    nonNullDestinationSelectOptions: function () {
      return this.destinations.selectOptions.filter(x => x.value != null);
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