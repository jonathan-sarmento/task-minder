$(function () {

    const TodoUpdateModal = new abp.ModalManager({
        viewUrl: '/Index/TodoUpdateModal'
    });

    const TodoDeleteModal = new abp.ModalManager({
        viewUrl: '/Index/TodoDeleteModal'
    });

    TodoUpdateModal.onResult(function () {
        location.reload();
    });

    TodoDeleteModal.onResult(function () {
        location.reload();
    });

    $('[data-modal="OpenUpdateModal"]').click(function () {
        let todoId = $(this).attr('data-todoid');
        TodoUpdateModal.open({
            todoId: todoId
        });
    });

    $('[data-modal="OpenDeleteModal"]').click(function () {
        let todoId = $(this).attr('data-todoid');
        TodoDeleteModal.open({
            todoId: todoId
        });
    });

    $('[data-check="CheckButton"]').click(function () {
        let todoId = $(this).attr('data-todoid');
        console.log(todoId)
        taskMinder.services.todo.updateDoneStatus(todoId, true).then(function () {
            location.reload();
        });
    })

    $('[data-check="UncheckButton"]').click(function () {
        let todoId = $(this).attr('data-todoid');
        taskMinder.services.todo.updateDoneStatus(todoId, false).then(function () {
            location.reload();
        });
    })

});


