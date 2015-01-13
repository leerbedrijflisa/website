//Mobile Menu.

$(document).ready(javascript_enabled);
$(window).resize(javascript_enabled);
$("#menubutton a").click(hide_menu);
$("#responsiveButton").click(show_menu);

function show_menu()
{
    $(".responsive-menu").css("display", "inline");
}

function hide_menu()
{
    $(".responsive-menu").css("display", "none");
}

function javascript_enabled()
{
    if ($(window).width() < 801)
    {
        $(".menu").css("display", "none");
        $("#responsiveButton").css("display", "inline");
    }
    else
    {
        $("#responsiveButton").css("display", "none");
        $(".menu").css("display", "inline");
    }
}

//-------------------------------------------------------------------------
//Page Jump.

