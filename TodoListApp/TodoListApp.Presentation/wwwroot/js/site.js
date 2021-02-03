// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('#sideMenu button').click(function () {
    $('#dynamicContent').load("Home/Tasks", { "categoryId": $(this).val() });
});