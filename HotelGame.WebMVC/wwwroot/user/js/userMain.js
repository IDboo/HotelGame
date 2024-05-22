<script>
    document.addEventListener("DOMContentLoaded", function() {
    var gridItems = document.querySelectorAll('.grid-item');
    gridItems.forEach(function(item, index) {
        // Burada her öğeye ek işlemler yapabilirsiniz.
        console.log('Item ID:', item.getAttribute('data-room-id'), 'Class Name:', 'grid-item-' + index);
    });
});
</script>
