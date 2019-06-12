$(function () {

    $(".delete-photo").click(function () {
        $("#Employee_Photo").attr('value', null);
        $(".employee-photo").remove();
    });

    $("#employee-form").validate();


});

