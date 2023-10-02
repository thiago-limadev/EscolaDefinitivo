// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).ready(function () {
    getDatatable('#tabela-alunos');
    getDatatable('#tabela-cursos');
    getDatatable('#tabela-usuarios');

    // Remova o evento click anterior e adicione o novo evento
    $(document).on('click', '.btn-total-alunos', function () {
        var cursoId = $(this).attr('curso-id');
        console.log('Botão Clicado');

        // Remova esta linha $('#modalAlunosCurso').modal('show');

        $.ajax({
            type: 'GET',
            url: '/Curso/ListarAlunosPorId/' + cursoId,
            success: function (result) {
                $('#listaAlunosMatriculados').html(result);
                $('#modalAlunosCurso').modal('show'); // Use 'show' para abrir o modal
            }
        });
    });

    


    $('#modalAlunosCurso .close').click(function () {
        $('#modalAlunosCurso').modal('hide');
    });
});
function getDatatable(id) {
    $(id).DataTable({
        "ordering": true,
        "paging": true,
        "searching": true,
        "oLanguage": {
            "sEmptyTable": "Nenhum registro encontrado na tabela",
            "sInfo": "Mostrar _START_ até _END_ de _TOTAL_ registros",
            "sInfoEmpty": "Mostrar 0 até 0 de 0 Registros",
            "sInfoFiltered": "(Filtrar de _MAX_ total registros)",
            "sInfoPostFix": "",
            "sInfoThousands": ".",
            "sLengthMenu": "Mostrar _MENU_ registros por pagina",
            "sLoadingRecords": "Carregando...",
            "sProcessing": "Processando...",
            "sZeroRecords": "Nenhum registro encontrado",
            "sSearch": "Pesquisar",
            "oPaginate": {
                "sNext": "Proximo",
                "sPrevious": "Anterior",
                "sFirst": "Primeiro",
                "sLast": "Ultimo"
            },
            "oAria": {
                "sSortAscending": ": Ordenar colunas de forma ascendente",
                "sSortDescending": ": Ordenar colunas de forma descendente"
            }
        }
    });
}


$('.close-alert').click(function () {
    $('.alert').hide('hide');
});


