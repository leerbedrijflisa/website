if (screen.width > 650)
{
    $("#articleButton").hover(hover_in, hover_out);

    function hover_in()
    {
        $(this).find('.articleInside').stop().animate({ marginTop: "0px" }, 400);
        $(this).find('p').stop().animate({ height: "210px" }, 400);
    }

    function hover_out()
    {
        $(this).find('.articleInside').stop().animate({ marginTop: "210" }, 400);
        $(this).find('p').stop().animate({ height: "0" }, 400);
    }
}