//If checks also if value is a Number to prevent problems.

if ($(window).width() > 800 && $.isNumeric($(window).width()))
{
    function hover_in()
    {
        $(this).find('h2').stop().animate({ marginTop: "0px" }, 400);
        $(this).find('p').stop().animate({ height: "210px" }, 400);
    }

    function hover_out()
    {
        $(this).find('h2').stop().animate({ marginTop: "210px" }, 400);
        $(this).find('p').stop().animate({ height: "0px" }, 400);
    }

    var numberOf = $('.articlesContent').find('a').last().attr('id');

    $(".articlesContent a").hover(hover_in, hover_out);

    /*
    for (i = 1; i <= numberOf; i++)
    {
        $(i).mouseenter(hover_in());
        $(i).mouseleave(hover_out());
    }
    */
}