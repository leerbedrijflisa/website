$( "#responsive-close a" ).click(hide_menu);
$( "#responsive-menu" ).click(show_menu);

function show_menu()
{
	$(".menu").css( "display", "inline" );
}

function hide_menu()
{
	$(".menu").css( "display", "none" );
}