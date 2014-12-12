//Mobile Menu.

$(document).ready(javascript_enabled);
$(window).resize(javascript_enabled);
$( "#menubutton a" ).click(hide_menu);
$( "#responsive-button" ).click(show_menu);

function show_menu()
{
	$(".responsive-menu").css( "display", "inline" );
}

function hide_menu()
{
	$(".responsive-menu").css( "display", "none" );
}

function javascript_enabled()
{
	if($(document).width() < 801)
	{
		$("#responsive-button").css( "display", "inline" );
		$(".menu").css( "display", "none" );
	}
	else
	{
		$("#responsive-button").css( "display", "none" );
		$(".menu").css( "display", "inline" );
	}
}

//-------------------------------------------------------------------------
//Page Jump.

