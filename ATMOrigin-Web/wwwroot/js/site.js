function HadlerError(e)
{
    console.log(e);
}


$("#ValidateCard").click(() => {

    $.ajax({
        url: "Login/ValidateCard",
        method: "post",
        data: {
            numberCard: $("#numberCard").val()
        },
        error: (e) => { HadlerError(e) },
        success: (r) =>
        {
            $("#divContent").html(r);
        }
    });
});

$(".numberCard").keypress((e) => {
    var length = $(".numberCard").val().length;
    if (length == 19)
    {
        e.preventDefault();
    }
    if (length === 4 || length === 9 || length === 14)
    {
        $(".numberCard").val($(".numberCard").val() + " ");
    }

});

$(".numberPin").keypress((e) => {
    var length = $(".numberPin").val().length;
    if (length == 4) {
        e.preventDefault();
    }

});

$(".number").keypress( (event) => {
    var keycode = event.keyCode;
    if (keycode > 47 && keycode < 58) {

    } else
    {
        event.preventDefault();
    }
})

$(".setNumber").click(function ()
{
    var val = $(this).text();
    var target = $(this).parent().attr("data-target");
    var content = $(target).val();
    if (target == ".numberCard") {
        if (content.length == 19) return;
        if (content.length === 4 || content.length === 9 || content.length === 14)
            content += " "
        else
            content += "";
    } else
    {
        if (content.length == 4) return
    }


    $(target).val(content + val);
})
