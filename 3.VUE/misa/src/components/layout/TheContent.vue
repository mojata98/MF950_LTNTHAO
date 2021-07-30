<template>
    <div class="page">
        <EmployeeList />
    </div>
    
        
</template>

<script>

// import VueAxios from 'vue-axios';
import EmployeeList from '../../view/employee/EmployeeList.vue';
export default {
    name: 'TheContent',
    components: {
        EmployeeList
    },
    
}
</script>

<style scoped>
@import '../../css/layout/content.css';
/* @import '../../css/layout/modal-form.css'; */
</style>