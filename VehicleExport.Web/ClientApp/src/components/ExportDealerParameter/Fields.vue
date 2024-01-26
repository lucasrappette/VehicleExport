<template>
  <form-template @submit="onSubmit" @cancel="onCancel">
    <template v-slot:save><slot name="save"></slot></template>
    <template>
      <b-row class="mt-3">
        <b-col xs="12" sm="12" lg="12">
          <h4>Layout Field Mapping</h4>
            <hr />
            <select-list-control label="Layout Field" required v-model="item.layoutFieldId" :options="nonNullLayoutFieldSelectOptions" :concurrency-check="item.concurrencyCheck"></select-list-control>
            <text-control label="Header Label" v-model="item.headerLabel" :concurrency-check="item.concurrencyCheck" description="This is for overriding a default header for the layout field"></text-control>
            <text-control label="Field Order" :readonly="true" v-model="item.fieldOrder" :concurrency-check="item.concurrencyCheck"></text-control>
        </b-col>
      </b-row>
    </template>
  </form-template>
</template>

<script>
import { mapState, mapGetters } from 'vuex'

export default {
  name: "LayoutFieldMapFields",
  props: [
    'item'
  ],
  data() {
    return {
    };
  },
  computed: {
    ...mapState('cachedData', ['layoutFields']),
    nonNullLayoutFieldSelectOptions: function () {
      return this.layoutFields.selectOptions.filter(x => x.value != null);
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