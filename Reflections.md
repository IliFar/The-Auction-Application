**STRUKTUR**
Jag har valt designmönstret MVC vilket är ganska uppenbart, men med detta designmönster kunde jag strukturera min kod på ett sätt så att applikationens olika del är löst kopplad, och jag följde också repository pattern för att använda interfacet implementerat av modellkategori i controllen istället för att använda databaskontexten direkt i controllen. Men jag har inte använt några vymodeller för mina modeller eftersom jag inte har sett någon användning av det i min applikation men jag har läst att det är en dålig vana att använda modellen direkt i vyerna. Eftersom jag använder repository pattern så skapade jag också mock repositories i syfte att testa. Anledningen till att jag valde den här strukturen är för att det blir enklare än att uppdatera applikationen sen eller fortsätta att utveckla den.

**SÄKERHET**
för att säkra de känsliga delarna av kundens företag i applikationen har jag använt authorization middleware i Configure metoden, och istället för att använda attributet authorize i kontrollerna eller modellerna har jag istället använt global auktorisering i Startup-filen med AuthorizationPolicyBuilder och MVC-filters och sedan lade jag till attributet allow anonymous till hemkontrollern eftersom den inte innehåller några känsliga delar av applikationen.

**ANVÄNDARE**
i applikationen finns det 2 användare och 2 roller hittills.
Den första användaren har :
(1) Role = [Admin], e-post = [admin@admin.com], Password = [Admin22!]
(2) Role = [User], e-post = [user@user.com], Password = [User22!]
Användarna och rollerna är hårdkodade i appDbContext-filen, men naturligtvis kan applikationen lägga till nya användare och nya roller, och en roll kan ha flera användare. Endast Admin kan hantera rollerna och användarna, kan markera en produkt som såld och kan ge ett slutpris på produkten.

