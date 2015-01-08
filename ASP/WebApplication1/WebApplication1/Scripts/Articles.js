if (screen.width > 650)
{
    var numberOfString = $('.articlesContent').find('li').last().attr('id');
    var numberOf = numberOfString.replace("articleButton", "");
    
    for (i = 1; i <= numberOf; i++)
    {
        $('#articleButton' + i).hover(hover_in, hover_out);
    }

    function hover_in()
    {
        $(this).find('h2').stop().animate({ marginTop: "0px" }, 400);
        $(this).find('p').stop().animate({ height: "210px" }, 400);
    }

    function hover_out()
    {
        $(this).find('h2').stop().animate({ marginTop: "210" }, 400);
        $(this).find('p').stop().animate({ height: "0" }, 400);
    }
}