
if(screen.width > 650)
{
	$( "#js-hover1,#js-hover2,#js-hover3,#js-hover4,#js-hover5,#js-hover6,#js-hover7,#js-hover8,#js-hover9" ).hover( hover_in, hover_out);

	function hover_in()
	{
		//$(this).find('h2').css( "top", "0px" );
		$(this).find('.articleContent').stop().animate({marginTop: "0px"}, 400);
		$(this).find('p').stop().animate({height: "210px"}, 400);
	}

	function hover_out()
	{
		$(this).find('.articleContent').stop().animate({marginTop: "210"}, 400);
		$(this).find('p').stop().animate({height: "0"}, 400);
	}
}