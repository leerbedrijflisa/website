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
    if ($(document).width() < 801)
    {
        $("#responsiveButton").css("display", "inline");
        $(".menu").css("display", "none");
    }
    else
    {
        $("#responsiveButton").css("display", "none");
        $(".menu").css("display", "inline");
    }
}

//-------------------------------------------------------------------------
//Page Jump.

