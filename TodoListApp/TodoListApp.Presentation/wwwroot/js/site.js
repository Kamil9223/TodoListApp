// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//służy do załadowania widoku częściowego zawierającego listę tasków na wybranym boardzie
$('#sideMenu button').click(function () {
    $('#dynamicContent').load("Task/Tasks", { "taskBoardId": $(this).val() });
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

var contentDiv = $('#dynamicContentForAddingBoardModal');

//służy do otwarcia okna do dodawania boardów
$('button[data-toggle="ajax-modal"]').click(function () {
    let url = $(this).data('url');

    $.get(url).done(function (data) {
        contentDiv.html(data);
        contentDiv.find('.modal').modal('show');
    })
});

//służy do wysyłki formularza dodania boardu, oraz do reakcji co ma się stać po wysłaniu,
//w zależności czy dane były podane w sposób prawidłowy cz nie
contentDiv.on('click', '[data-save="modal"]', function () {
    var form = $(this).parents('.modal').find('form');
    var actionUrl = form.attr('action');
    var dataToSend = form.serialize();
    $.post(actionUrl, dataToSend).done(function (data) {

        if (data == 'Redirect!') {
            contentDiv.find('.modal').modal('hide');
            $.get('Board/Redirect');
            location.reload(true);
        }
        else {
            contentDiv.find('.modal').removeClass('fade');
            contentDiv.find('.modal').modal('hide');
            contentDiv.html(data);
            contentDiv.find('.modal').addClass('fade');
            contentDiv.find('.modal').modal('show');
        }
    });
});
