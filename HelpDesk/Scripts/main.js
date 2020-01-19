$(".running").on("click",
    function(e) {
        if (window.flag) {
            $.blockUI({ message: '<h1>執行中(Running)</h1> ' });
        }
    });

$(".running2").on("click",
    function(e) {
        $.blockUI({ message: '<h1>執行中(Running)</h1> ' });
    });
$(".runningDDL").on("change",
    function(e) {
        $.blockUI({ message: '<h1>執行中(Running)</h1> ' });
    });

$('select[id*="DropDownList"]').multiselect({
    includeSelectAllOption: true,
    allSelectedText: 'All Selected',
    enableFiltering: true,
    buttonClass:'btn btn-default btn-flat',
    maxHeight: 400,
    filterPlaceholder: 'Search...',
    numberDisplayed: 1
});