<template>
  <b-form-group :label="label" :description="description" :invalid-feedback="validationError" class="form-floating-label-group">
    <br/>
    <b-form-tags v-model="renderedContent" no-outer-focus class="multiselect">
      <template v-slot="{ tags, inputAttrs, inputHandlers, disabled, addTag, removeTag }">
        <ul v-if="tags.length > 0" class="list-inline d-inline-block mb-2">
          <li v-for="tag in tags" :key="tag" class="list-inline-item">
            <b-form-tag @remove="removeMultiselectTag(removeTag, tag)" :title="tag" :disabled="disabled" variant="secondary">
              {{options.find(c => c.value == tag).text}}
            </b-form-tag>
          </li>
        </ul>
        <b-form-select v-bind="inputAttrs" v-on="inputHandlers" :options="options" :state="state" class="floating-label"  @change="addMultiselectTag(addTag, inputAttrs);"></b-form-select>
      </template>
    </b-form-tags>
  </b-form-group>
</template>

<script>
export default {
  name: "MultiSelectListControl",
  props: {
    label: {},
    description: {},
    options: {},
    value: {
      required: true
    },
    required: {
      default: false
    },
    requiredError: {
      default: 'This field is required'
    },
    concurrencyCheck: {
      default: null
    },
    customValidation: {}
  },
  data() {
    return {
      content: this.value,
      renderedContent: this.value ? this.value.split(',') : null,
      originalValue: this.value,
      state: null,
      validationError: null
    };
  },
  computed: {
    isValid: function () {
      if (this.state === null)
        this.checkValidity(this.content, this.content);

      return this.state === true || this.state === null;
    },
  },
  methods: {
    updateContent(inputAttrs) {
      this.content = inputAttrs.join();
      this.renderedContent = inputAttrs;
      this.$emit('input', this.content);
    },
    addContent(value) {
      if(this.content)
      {
        var contentList = this.content.split(',');
        this.content = contentList;
        if(contentList.indexOf(value.toString()) == -1)
        {
          contentList.push(value.toString());
        }
      }
      else
      {
        this.content = [];
        this.content.push(value.toString());
      }
      this.renderedContent = this.content;
      this.content = this.content.join(',');
      this.$emit('input', this.content);
    },
    removeContent(value) {
      if(this.content)
      {
        var contentList = this.content.split(',');
        this.content = contentList;
        contentList.splice(contentList.indexOf(value.toString()), 1);
      }
      else
      {
        this.content = [];
      }
      this.renderedContent = this.content;
      this.content = this.content.join(',');
      this.$emit('input', this.content);
    },
    addMultiselectTag(addTag, inputAttrs) {
      addTag(window.document.getElementById(inputAttrs.id).value);
      this.addContent(window.document.getElementById(inputAttrs.id).value);
    },
    removeMultiselectTag(removeTag, tag)
    {
      removeTag(tag);
      this.removeContent(tag);
    },
    checkValidity(newValue, oldValue) {
      let validationError = null;

      if (this.required !== null && this.required !== false && (newValue == null || newValue == '') && newValue !== true && newValue !== false)
        validationError = this.requiredError;
      else if (typeof(this.customValidation) === 'function') {
        let retVal = this.customValidation(newValue, oldValue);
        if (retVal !== true && retVal !== null)
          validationError = retVal;
        else {
          this.state = retVal;
          validationError = null;
        }
      }

      this.validationError = validationError;
      if (this.validationError != null)
        this.state = false;
      else {
        if (this.originalValue == newValue)
          this.state = null;
        else
          this.state = true;
      }
    }
  },
  watch: {
    content: function (newValue, oldValue) {
      this.checkValidity(newValue, oldValue);
    },
    value: function (newValue, oldValue) {
      this.content = newValue;
    },
    concurrencyCheck: function (newValue, oldValue) {
      this.originalValue = this.content;
      this.state = null;
    }
  },
  mounted () {
  }
};
</script>