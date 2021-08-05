<template>
    <div>
        <div class="footer ">
            <div class="footer-left ">Hiển thị <b id="employeeTotal">1-10/1000</b> nhân viên</div>
            <div class="pagination ">
                <div class="footer-middle ">
                    <a href="# " class="pagination-firstpage "></a>
                    <a href="# " class="pagination-prevpage "></a>
                    <a href="# " class="page-number">1</a>
                    <a class="active page-number" href="# ">2</a>
                    <a href="# " class="page-number">3</a>
                    <a href="# " class="page-number">4</a>
                    <a href="# " class="pagination-nextpage "></a>
                    <a href="# " class="pagination-lastpage "></a>
                </div>
            </div>
            <div class="footer-right ">10 nhân viên/trang</div>
        </div>  
    </div>
</template>

<script>
export default {
    name: 'Pagination',
}
</script>

<style scoped>
    /* Chưa tạo css cho footer */
</style>