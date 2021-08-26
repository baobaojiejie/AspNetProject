$(function () {

    function DisplayResult1(call, data) {
        $('#result').append("<strong>" + call + "<strong>" + "<br/>");

        $.each(data, function (i, item) {

            $('#result').append(JSON.stringify(item));
            $('#result').append("<br/>");
        });
    };

    function DisplayResult2(call, data) {
        $('#result').append("<strong>" + call + "<strong>" + "<br/>");

        $('#result').append(JSON.stringify(data));
        $('#result').append("<br/>");

    };
    //change the below port num. The below url is the LibraryService url
    var serviceUrl = 'https://localhost:44352/api'; 
    $('#getAllStudents').on('click', function () {
        //alert("Hello");
        $.ajax({
            url: serviceUrl + '/student',
            method: 'GET',
            success: function (data) {
                DisplayResult1("Get All:", data);
            }
        });
    });

    $('#getStudentById').on('click', function () {
        var studentId = $('#id').val();
        $.ajax({
            url: serviceUrl + '/student/ ' + studentId,
            method: 'GET',
            success: function (data) {
                DisplayResult2("Student by id:", data);
            }
        });
    });

    $('#getStudentByLastname').on('click', function () {
        var studentLastname = $('#lastname').val();
        $.ajax({
            url: serviceUrl + '/student/?lastname=' + studentLastname,
            method: 'GET',
            success: function (data) {
                DisplayResult2("Student by lastname:", data);
            }
        });
    });


    $('#addNewStudent').on('click', function () {
        var inputData = $('input').serialize();
        $.ajax({
            url: serviceUrl + '/student/',
            method: 'POST',
            data: inputData,
            success: function (data) {
                DisplayResult2("Add Student", data);
            }
        });
    });

    $('#removeStudentById').on('click', function () {
        var studentId = $('#id').val();
        $.ajax({
            url: serviceUrl + '/student/ ' + studentId,
            method: 'DELETE',
            success: function (data) {
                DisplayResult1("Updated list", data);
            }
        });
    });


    $('#updateStudentById').on('click', function () {
        var inputData = $('input').serialize();
        var studentId = $('#id').val();
        $.ajax({
            url: serviceUrl + '/student/' + studentId,
            method: 'PUT',
            data: inputData,
            success: function (data) {
                DisplayResult1("Updated list:", data);
            }
        });
    });

    $('#getStudentByFnAndNoc').on('click', function () {
        var studentFirstname = $('#firstname').val();
        var noc = $('#numOfCourses').val();
        $.ajax({
            url: serviceUrl + '/student/?firstname='+studentFirstname+'&numOfCourses=' + noc,
            method: 'GET',
            success: function (data) {
                DisplayResult2("Student by Firstname and Number of courses:", data);
            }
        });
    });

});