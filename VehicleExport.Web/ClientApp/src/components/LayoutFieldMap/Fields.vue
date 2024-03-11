<template>
  <form-template @submit="onSubmit" @cancel="onCancel">
    <template v-slot:save><slot name="save"></slot></template>
    <template>
      <b-row>
        <b-col xs="12" sm="12" lg="12">
            <select-list-control label="Layout Field" required v-model="item.layoutFieldId" :options="nonNullLayoutFieldSelectOptions" :concurrency-check="item.concurrencyCheck"></select-list-control>
            <text-control label="Header Label" v-model="item.headerLabel" :concurrency-check="item.concurrencyCheck" description="This is for overriding a default header for the layout field"></text-control>
            <div v-if="showFieldOrder">
              <text-control label="Field Order" :disabled="true" v-model="item.fieldOrder" :concurrency-check="item.concurrencyCheck"></text-control>
              <hr />
                <b-form-group label="Re-Ordering Options">
                  <b-form-radio-group id="reordering-radio-group" v-model="item.replacementOption" name="replacement-option-radios">
                  <b-form-radio value="insert">Insert</b-form-radio>
                  <b-form-radio value="replace">Replace</b-form-radio>
                </b-form-radio-group>
                <text-control v-model="item.newFieldOrder" label="New Field Order" description="This will be the new ordering for this column if filled in"></text-control>
              </b-form-group>
            </div>
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
    'item',
    'showFieldOrder'
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