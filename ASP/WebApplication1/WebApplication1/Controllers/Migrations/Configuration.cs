namespace Lisa.Website.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Lisa.Website.WebsiteContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(Lisa.Website.WebsiteContext context)
        {   
            var Stoeptegels = new Podcast
            {
                Title = "De wonderbaarlijke wereld van stoeptegels",
                File = "Lisa Developers Podcast 2014-08-10.mp3",
                Image = "Penguin.png",
                Date = DateTime.Now,
                Content = "Stoeptegels (ook wel trottoirtegels genoemd) zijn in Nederland het meest voorkomende plaveisel op het trottoir en worden soms ook toegepast als bestrating van terrassen bij woningen. Een standaard stoeptegel is 30 x 30 x 4,5 cm groot en is vervaardigd van grijs beton. Het gewicht van één tegel is 9,5 kilogram. Bij zwaar belaste trottoirs en fietspaden worden tegels van 6 cm dik gebruikt (12,5 kilogram/stuk). Trottoirtegels worden meestal in dezelfde richting als de trottoirband gelegd in een ruitpatroon of per rij versprongen (halfsteensverband). Voor het vergemakkelijken van het leggen van een versprongen patroon worden halve tegels vervaardigd. De vijfkantige stenen die worden gebruikt bij het leggen van trottoirtegels onder een hoek van 45 graden ten opzichte van de trottoirband worden bisschopsmutsen genoemd.",
                Author = "Joost Ronkes Agerbeek, Wilco van Duinkerken",
                References = "hier komt een linkje",
            };

            var Regendruppels = new Podcast
            {
                Title = "Alles wat je wilt weten over regendruppels",
                File = "Lisa Developers Podcast 2014-08-31.mp3",
                Image = "Raven.png",
                Date = DateTime.Now,
                Content = "Voor de vorming van neerslag zijn in de eerste plaats wolken nodig, die bestaan uit al dan niet onderkoelde druppeltjes of ijskristallen die ontstaan zijn door condensatie of sublimatie. Deze elementen worden wolkenelementen genoemd en hebben een doorsnede van enkele μm (1 μm = 0,001 mm). Om daadwerkelijk tot neerslag te komen moeten de afmetingen van de onderkoelde druppeltjes in een wolk toenemen, zodat deze overgaan in neerslagelementen welke een doorsnede hebben van ten minste 100 à 200 μm. Het ontstaan van wolken gaat gepaard met verticale bewegingen die in snelheid kunnen variëren van enkele cm/sec tot meerdere meters/sec. Aangezien wolkenelementen valsnelheden hebben van slechts ongeveer 1 cm/sec, is het noodzakelijk dat deze aanzienlijk aangroeien zodat zij door een wolk kunnen vallen, verdamping in de niet-gecondenseerde lucht beneden de wolkenbasis kunnen overleven en de grond als motregen, regen, enzovoorts kunnen bereiken. De vorming van relatief kleine neerslagdruppels uit enorme hoeveelheden uiterst kleine wolkendruppeltjes wordt door een tweetal processen gerealiseerd: het coalescentie-proces en het Wegener-Bergeron-Findeisen-proces.",
                Author = "Joost Ronkes Agerbeek, Wilco van Duinkerken",
                References = "hier komt een linkje"
            };

            var Dropfabriek = new Podcast
            {
                Title = "De grote geheimen van de dropfabriek",
                File = "Lisa Developers Podcast 2014-09-28.mp3",
                Image = "Raven.png",
                Date = DateTime.Now,
                Content = "Drop is een snoepgoed dat wordt gemaakt van het wortelsap van de zoethoutplant Glycyrrhiza glabra (vlinderbloemfamilie). De zuivere vorm heet blokdrop. De blokdrop wordt dan gebruikt als ingrediënt voor de snoepjes. Voor de zoetheid wordt suiker (in percentages variërend tussen 30 en 60%) of een andere zoetstof toegevoegd. Vroeger bond men de drop met Arabische gom, tegenwoordig doet men dit meestal met zetmeel of gelatine. Toch wordt Arabische gom soms nog steeds gebruikt. Andere bestanddelen zijn salmiak (ammoniumchloride), soms zout, evenals geur- en smaakstoffen, al dan niet synthetisch (eucalyptus, honing, anijs). Van nature bruinige en ietwat doorzichtige dropsoorten worden met koolstof of karamel donkerder gekleurd.[1] Vooral in Nederland is drop populair, maar daarnaast ook in de Scandinavische landen en Noord-Duitsland. De industriële verwerking van de zoethoutwortel tot drop werd mogelijk toen de Italiaan Giorgio Amarelli er in 1731 in slaagde om het sap uit de zoethoutwortel (Glycyrrhiza glabra), tot drop te verwerken.[2]",
                Author = "Joost Ronkes Agerbeek, Wilco van Duinkerken",
                References = "hier komt een linkje"
            };

            var AlanTuring = new Article
            {
                Title = "Alan Turing",
                Image = "Raven.png",
                Date = DateTime.Now,
                Content = "Tijdens zijn jeugd had Alan Turing een goede vriend genaamd Christopher Morcom. Ze zaten samen op Sherborne School en waren beiden zeer geïnteresseerd in de natuurwetenschappen. Vanaf zijn jeugd stotterde hij al. Als adolescent werd hij zich bewust van zijn homoseksualiteit. Na hun middelbare school zijn ze allebei gaan studeren in Cambridge. Christopher, op wie hij verliefd was geworden, stierf twee jaar nadat ze elkaar ontmoet hadden, in 1930. Dit was voor hem dan ook een enorme klap. [1] Na een periode van verdriet begon Turing zich te focussen op zijn studie. Hij studeerde kwantummechanica aan de Universiteit van Cambridge. Daar maakte hij kennis met het zogeheten Entscheidungsproblem, en publiceerde hij zijn artikel genaamd On Computable Numbers, with an Application to the Entscheidungsproblem. Dit beslissingsprobleem laat zich als volgt omschrijven: bestaat er een algoritme om te beslissen of een wiskundige formule een bewijs heeft of niet? Met dit artikel als basis introduceerde Turing de Logical Computing Machine. Dit gedachte-experiment werd later de Turingmachine genoemd. Na Cambridge ging Turing naar Princeton in de Verenigde Staten, en daarna terug naar Cambridge. De Tweede Wereldoorlog[bewerken] In de jaren van de Tweede Wereldoorlog werkte Turing in het geheim bij de Government Code and Cypher School, gehuisvest op het landgoed Bletchley Park. Dit was de Britse crypto-analytische dienst, die als doel had onderschepte gecodeerde berichten van de Duitsers te ontcijferen, zodat de geallieerden de vijand een stap voor konden zijn. Turing maakte deel uit van een team dat succesvol voortbouwde op het werk van de Poolse wiskundigen Marian Rejewski, Henryk Zygalski en Jerzy Różycki, die een decoderingsapparaat hadden uitgevonden dat de codes kon ontcijferen die door het Enigma-apparaat, een Duits coderingssysteem, waren gegenereerd, wat hen niet meer lukte nadat de Duitsers de Enigma compliceerden. De ontcijfering van de Enigma wordt vaak aangehaald als een van de grootste prestaties in de Tweede Wereldoorlog die de alliantie de uiteindelijke overwinning zouden hebben gebracht. Na de Tweede Wereldoorlog[bewerken]Na de oorlog werkte Turing aan de universiteit van Manchester, waar hij de Deputy Director of the Computing Laboratory werd. Hij bouwde de Automatic Computing Engine (ACE). In 1950 publiceerde Turing in het tijdschrift MIND een artikel genaamd Computing Machinery and Intelligence. Hierin beschreef hij zijn turingtest.Hij bleef ook in het geheim werken voor GCHQ, tot hij daar in 1948 wegens zijn homoseksualiteit geweerd werd, omdat hij daardoor door de geheime dienst als een veiligheidsrisico werd beschouwd.Turing werd voor zijn vitale bijdragen aan de oorlogsinspanning in 1945 geëerd met de Order of the British Empire (OBE), en in 1951 werd hij voor zijn belangrijke bijdragen aan de wiskunde gekozen tot lid (Fellow) van de Royal Society. De A.M. Turing Award wordt algemeen gezien als de hoogste onderscheiding in de informatica. Vervolging en overlijden[bewerken] In 1952 werd Turing gearresteerd wegens homoseksuele handelingen (die tot 1967 in Engeland voor mannen strafbaar waren) en veroordeeld, waarbij hij kon kiezen tussen een experimentele chemische castratie gedurende een jaar, en een gevangenisstraf. Turing koos het eerste. De hormonen die hij verplicht werd te laten injecteren, leidden onder meer tot borstvorming. Op 7 juni 1954 werd hij dood aangetroffen met een appel, die - naar beweerd werd - met cyanide vergiftigd was. Er wordt over zijn dood veel gespeculeerd. De officiële doodsoorzaak is zelfmoord, maar er wordt beweerd dat hij door de Engelse geheime dienst is vermoord, omdat hij te veel zou weten over geheime codes en daardoor een te groot veiligheidsrisico werd.[2] In juni 2012 liet de Turingexpert Jack Copeland op een congres weten dat Turings dood een ongeluk kan zijn geweest. De appel zou, volgens deze bron, nooit op cyanide zijn onderzocht. Bovendien waren er in Turings gedrag kort voor zijn dood geen aanwijzingen dat het niet goed met hem ging. Ook is bekend dat Turing thuisexperimenten met cyanide uitvoerde, waarbij hij slordig met dit materiaal zou zijn omgegaan. In ieder geval bleek een blootstelling aan cyanide bij de autopsie de doodsoorzaak.[3] In zijn verfilmde Turing-biografie brengt wiskundige en schrijver Andrew Hodges de mogelijkheid naar voren dat inderdaad Turing zelfmoord heeft gepleegd, maar zijn 'experimenten' gebruikte om voor zijn moeder de gedachte open te laten dat zijn dood een ongeval was.[4] Postuum eerherstel[bewerken] Anno 2009 gingen er stemmen op in het Verenigd Koninkrijk die pleitten voor een postuum eerherstel.[5] In september dat jaar heeft premier Gordon Brown namens de regering postuum excuses aangeboden aan Alan Turing.[6][7] Op 24 december 2013 verleende koningin Elizabeth II Alan Turing gratie en werd zijn veroordeling wegens homoseksualiteit uit de boeken geschrapt.[8]"
            };
       
            var FreddieMercury = new Article
            {
                Title = "FreddieMercury",
                Image = "Raven.png",
                Date = DateTime.Now,
                Content = "Freddie Mercury, geboren als Farrokh Bulsara (Gujarati: ફારોખ બલ્સારા‌) (Stone Town (Zanzibar), 5 september 1946 - Londen, 24 november 1991), was een Britse rockmusicus. Hij werd bekend als de zanger en 'frontman' van de groep Queen en groeide uit tot een van de beste en populairste rockartiesten en popzangers aller tijden.[1] Hij stond bekend om zijn extraverte podiumpersoonlijkheid en zijn explosieve optredens. Hij staat ook in de boeken als de man met een stembereik van vier octaven, wat buitengewoon is voor een mannelijke zangstem."
            };  

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Podcasts.AddOrUpdate(Stoeptegels);
            context.Podcasts.AddOrUpdate(Regendruppels);
            context.Podcasts.AddOrUpdate(Dropfabriek);
            context.Articles.AddOrUpdate(AlanTuring);
            context.Articles.AddOrUpdate(FreddieMercury);
            context.SaveChanges();
        }
    }
}
