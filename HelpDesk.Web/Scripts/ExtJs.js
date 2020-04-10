$('.btnRunningWithFlag').on('click', function(e) {
    if (window.flag) {
        $.blockUI({ message: '<h1> 執行中,請稍待...<br/>(Server is running,please wait...)</h1>' }); 
    }
        
});

$('.btnRunning').on('click', function(e) {
    $.blockUI({ message: '<h1> 執行中,請稍待...<br/>(Server is running,please wait...)</h1>' }); 

        
});