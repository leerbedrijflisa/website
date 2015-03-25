//If checks also if value is a Number to prevent problems.

function hover_in()
{
    if ($('body').width() > 800 && $.isNumeric($('body').width()))
    {
        $(this).find('h2').stop().animate({ marginTop: "0px" }, 400);
        $(this).find('p').stop().animate({ height: "210px" }, 400);
    }
}

function hover_out()
{
    if ($('body').width() > 800 && $.isNumeric($('body').width()))
    {
        $(this).find('h2').stop().animate({ marginTop: "210px" }, 400);
        $(this).find('p').stop().animate({ height: "0px" }, 400);
    }
}

function article_hover()
{
    if ($('body').width() > 800 && $.isNumeric($('body').width()))
    {
        $(".articlesContent h2").css({ marginTop: "210px" });
        $(".articlesContent p").css({ height: "0px" });
        var numberOf = $('.articlesContent').find('a').last().attr('id');
        $(".articlesContent a").hover(hover_in, hover_out).on;
    }
    else
    {
        $(".articlesContent h2").css({ marginTop: "0px"  }).stop();
        $(".articlesContent p").css({ height: "auto" });
    }
}

$(document).ready(article_hover);
$( window ).resize(article_hover);