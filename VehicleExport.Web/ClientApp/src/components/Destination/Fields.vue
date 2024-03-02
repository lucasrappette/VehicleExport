<template>
  <form-template @submit="onSubmit" @cancel="onCancel">
    <template v-slot:save><slot name="save"></slot></template>
    <template>
      <b-row class="mt-3">
        <b-col xs="12" sm="6" lg="3">
          <h4>Basic/FTP</h4>
          <hr />
          <text-control label="Name" required v-model="item.name" :concurrency-check="item.concurrencyCheck"></text-control>
          <text-control label="Ftp Host" required v-model="item.ftpHost" :concurrency-check="item.concurrencyCheck"></text-control>
          <text-control label="Ftp Username" required v-model="item.ftpUsername" :concurrency-check="item.concurrencyCheck"></text-control>
          <text-control label="Ftp Password" required v-model="item.ftpPassword" :concurrency-check="item.concurrencyCheck"></text-control>
          <text-control label="Ftp Remote Directory" v-model="item.ftpRemoteDir" :concurrency-check="item.concurrencyCheck"></text-control>
          <select-list-control label="Protocol" required v-model="item.protocolTypeId" :options="nonNullProtocolTypeSelectOptions" :concurrency-check="item.concurrencyCheck"></select-list-control>
          <select-list-control :disabled="encryptionDisabled" label="Encryption Type" v-model="item.encryptionTypeId" :options="nonNullEncryptionTypeSelectOptions" :concurrency-check="item.concurrencyCheck"></select-list-control>
          <select-list-control label="Transfer Mode Type" required v-model="item.transferModeTypeId" :options="nonNulltransferModeTypeSelectOptions" :concurrency-check="item.concurrencyCheck"></select-list-control>
        </b-col>
         <b-col xs="12" sm="6" lg="3">
          <h4>File Options</h4>
          <hr />
          <select-list-control label="Output File Format Type" required v-model="item.outputFormatTypeId" :options="nonNullOutputFormatTypeSelectOptions" :concurrency-check="item.concurrencyCheck"></select-list-control>
          <text-control label="Output File Name" required v-model="item.outputFileName" :concurrency-check="item.concurrencyCheck"></text-control>
          <br/>
          <h4>File Formatting Options</h4>
          <hr />
          <checkbox-control label="Quoted Text Fields?" v-model="item.useQuotedFields" :concurrency-check="item.concurrencyCheck"></checkbox-control>
          <checkbox-control label="Include Headers?" v-model="item.includeHeaders" :concurrency-check="item.concurrencyCheck"></checkbox-control>
          <br/>
          <h4>Output Options</h4>
          <hr />
          <checkbox-control label="Zipped File?" v-model="item.zipOutputFile" :concurrency-check="item.concurrencyCheck"></checkbox-control>
          <checkbox-control label="One File Per Dealer?" v-model="item.oneFilePerDealer" :concurrency-check="item.concurrencyCheck"></checkbox-control>
          <checkbox-control label="Send Photos In Zip?" v-model="item.sendPhotosInZip" :concurrency-check="item.concurrencyCheck"></checkbox-control>
        </b-col>
         <b-col v-if="item.protocolTypeId==2" xs="12" sm="6" lg="3">
          <h4>SSH</h4>
          <hr />
          <!--<b-form-file
          v-model="item.sshFile"
          :state="Boolean(item.sshFile)"
          placeholder="SSH File"
          ref="upInput"
          class="mt-1"
          ></b-form-file>-->
          <file-upload-control label="SSH File" @upload="upload" v-model="item.sshkeyFileName" :concurrency-check="item.concurrencyCheck"></file-upload-control>
          <text-control label="File Password" v-model="item.sshFilePassword" :concurrency-check="item.concurrencyCheck"></text-control>
        </b-col>
      </b-row>
    </template>
  </form-template>
</template>

<script>
import { mapState, mapGetters } from 'vuex'
import FileUploadControl from '../Controls/FileUploadControl.vue';

export default {
  components: { FileUploadControl },
  name: "DestinationFields",
  props: [
    'item'
  ],
  data() {
    return {
      encryptionDisabled: false
    };
  },
  computed: {
    ...mapState('cachedData', ['protocolTypes', 'encryptionTypes', 'transferModeTypes', 'outputFormatTypes']),
    nonNullProtocolTypeSelectOptions: function () {
      return this.protocolTypes.selectOptions.filter(x => x.value != null);
    },
    nonNullEncryptionTypeSelectOptions: function () {
      return this.encryptionTypes.selectOptions.filter(x => x.value != null);
    },
    nonNulltransferModeTypeSelectOptions: function () {
      return this.transferModeTypes.selectOptions.filter(x => x.value != null);
    },
    nonNullOutputFormatTypeSelectOptions: function () {
      return this.outputFormatTypes.selectOptions.filter(x => x.value != null);
    },
  },
  methods: {
    onCancel(evt) {
      this.$emit('cancel');
    },
    onSubmit(evt) {
      this.$emit('submit');
    },
    upload(file) {
      this.item.sshkeyFileName = file.name;
      this.item.sshFile = file;
    },
    download(sshKeyFileName)
    {
      window.open("/api/destination/downloadFile/" + sshKeyFileName);
    }
  },
  watch: {
    'item.protocolTypeId': function(newValue, oldValue) {
      if(newValue == 2)
      {
        this.encryptionDisabled = true;
        this.item.encryptionTypeId = null;
      }
      else {
        this.encryptionDisabled = false;
        this.item.encryptionTypeId = 1;
      }
    }
  }
};
</script>