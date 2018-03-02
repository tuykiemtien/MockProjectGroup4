$(document).ready(function () {
    $('#login').click(function (e) {
        e.preventDefault();
        let account = {};
        account.Username = $('#username').val();
        account.Password = $('#password').val();
        let check = true;
        if (account.Username == '') {
            check = false;
            $('#user-valid').text('You must input username');
        }
        else {
            $('#user-valid').text('');
        }
        if (account.Password == '') {
            check = false;
            $('#pass-valid').text('You must input password');
        }
        else {
            $('#pass-valid').text('');
        }

        if (check) {
            $.ajax({
                type: 'POST',
                url: '/Home/Index',
                dataType: 'json',
                data: '{account : ' + JSON.stringify(account) + '}',
                contentType: 'application/json; charset = utf-8',
                success: function (data) {
                    if (data.Ok) {
                        window.location ="/Customer/Index";
                    }
                    else {
                        $('#login-valid').text('Invalid username or password');
                    }
                }
            });
        };
    });
})