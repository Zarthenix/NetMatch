$.ajax({
    type: 'post',
    url: 'test2.php',
    dataType: 'json',
    data: {
        txt: txtbox,
        hidden: hiddenTxt
    },
    cache: false,
    success: function (returndata) {
        if (returndata[4] === 1) {

            $("#bsModal3").modal('show');

        } else {
            // other code
        }
    },
    error: function () {
        console.error('Failed to process ajax !');
    }
});