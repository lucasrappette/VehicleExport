<template>
  <div>
    <b-form novalidate @submit.prevent="onSubmit">
      <slot></slot>
      <b-row class="mt-3" v-if="!hideButtons">
        <b-col>
          <b-button-toolbar key-nav>
            <b-button-group v-if="!hideSubmit">
              <b-button type="submit" variant="primary" :disabled="isSubmitting">
                <b-spinner small type="grow" v-if="isSubmitting"></b-spinner> <slot name="save"></slot>
              </b-button>
            </b-button-group>
            <b-button-group class="mx-2" v-if="!hideCancel" :disabled="isSubmitting">
              <b-button type="button" @click="onCancel">Cancel</b-button>
            </b-button-group>
            <b-button-group v-if="showClone">
              <b-button type="button" @click="onClone" variant="warning" :disabled="isSubmitting || isCloning">
                <b-spinner small type="grow" v-if="isSubmitting || isCloning"></b-spinner> Clone
              </b-button>
            </b-button-group>
          </b-button-toolbar>
        </b-col>
      </b-row>
          
    </b-form>
  </div>
</template>

<script>
import FormMixin from '../Mixins/FormMixin.vue';

export default {
  name: 'FormTemplate',
  mixins: [FormMixin],
  props: [
    'hideButtons',
    'hideSubmit',
    'hideCancel',
    'isSubmitting',
    'showClone',
    'isCloning'
  ],
  methods: {
    onCancel(evt) {
      this.$emit('cancel');
    },
    onClone(evt) {
      this.$emit('clone');
    },
    onSubmit(evt) {
      if (this.isFormValid())
        this.$emit('submit');
    }
  }

}
</script>