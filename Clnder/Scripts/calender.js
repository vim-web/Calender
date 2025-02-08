$.ajax({
    url: '@Url.Action("GetTasksForCalendar", "TodoTask")',
    method: 'GET',
    dataType: 'json',
    beforeSend: function () {
        // Show loading indicator
        $('#calendar').html('<p>Loading...</p>');
    },
    success: function (data) {
        var events = data.map(function (task) {
            return {
                title: task.Title,
                start: task.DueDate,
                description: task.Description,
                status: task.Status,
                color: getStatusColor(task.Status),
                url: '@Url.Action("Edit", "TodoTask", new { id = "__id__" })'.replace('__id__', task.Id)
            };
        });
        successCallback(events);
    },
    error: function () {
        failureCallback();
        alert('Failed to load tasks');
    }
});
