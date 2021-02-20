// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//służy do załadowania widoku częściowego zawierającego listę tasków na wybranym boardzie
$('#sideMenu button').click(function () {
    $('#dynamicContent').load("Board/Tasks", { "taskBoardId": $(this).val() });
});

//służy do pokazania/ukrycia opisu konkretnego szczegółu taska
$('#dropdownDescription').click(function () {
    if ($('#' + $(this).val()).hasClass('d-none')) {
        $('#' + $(this).val()).removeClass('d-none');
    }
    else {
        $('#' + $(this).val()).addClass('d-none');
    }
});
