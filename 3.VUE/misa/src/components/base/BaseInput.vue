<template>
  <div>
    <input
      :type="[typeName]"
      :placeholder="[placeholder]"
      :prop-name="[propName]"
      :id="idInput"
      :class="subClass"
      :required="required"
      :value="value"
      v-on:input="updateValue($event.target.value)"
      :tabindex="tabindex"
      :ref="refStr"
      @blur="this.$emit('blur')"
    />
  </div>
</template>
<script>
export default {
  name: "BaseInput",
  props: {
    typeName: String,
    placeholder: String,
    propName: String,
    idInput: String,
    subClass: String,
    tabindex: {
      type: Number,
      required: false,
    },
    refStr: String,
    value: {
      default: null,
    },
    required: {
      type: Boolean,
      default: false,
    },
  },
  methods: {
    updateValue: function (value) {
      this.$emit("input", value);
    },
  },
};
</script>
<style scoped>
/* @import "../../css/base/icon.css"; */
@import "../../css/base/input.css";
@import "../../css/base/button.css";
</style>