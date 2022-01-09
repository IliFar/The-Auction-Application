**STRUKTUR**
Jag har valt designm�nstret MVC vilket �r ganska uppenbart, men med detta designm�nster kunde jag strukturera min kod p� ett s�tt s� att applikationens olika del �r l�st kopplad, och jag f�ljde ocks� repository pattern f�r att anv�nda interfacet implementerat av modellkategori i controllen ist�llet f�r att anv�nda databaskontexten direkt i controllen. Men jag har inte anv�nt n�gra vymodeller f�r mina modeller eftersom jag inte har sett n�gon anv�ndning av det i min applikation men jag har l�st att det �r en d�lig vana att anv�nda modellen direkt i vyerna. Eftersom jag anv�nder repository pattern s� skapade jag ocks� mock repositories i syfte att testa. Anledningen till att jag valde den h�r strukturen �r f�r att det blir enklare �n att uppdatera applikationen sen eller forts�tta att utveckla den.

**S�KERHET**
f�r att s�kra de k�nsliga delarna av kundens f�retag i applikationen har jag anv�nt authorization middleware i Configure metoden, och ist�llet f�r att anv�nda attributet authorize i kontrollerna eller modellerna har jag ist�llet anv�nt global auktorisering i Startup-filen med AuthorizationPolicyBuilder och MVC-filters och sedan lade jag till attributet allow anonymous till hemkontrollern eftersom den inte inneh�ller n�gra k�nsliga delar av applikationen.

**ANV�NDARE**
i applikationen finns det 2 anv�ndare och 2 roller hittills.
Den f�rsta anv�ndaren har :
(1) Role = [Admin], e-post = [admin@admin.com], Password = [Admin22!]
(2) Role = [User], e-post = [user@user.com], Password = [User22!]
Anv�ndarna och rollerna �r h�rdkodade i appDbContext-filen, men naturligtvis kan applikationen l�gga till nya anv�ndare och nya roller, och en roll kan ha flera anv�ndare. Endast Admin kan hantera rollerna och anv�ndarna, kan markera en produkt som s�ld och kan ge ett slutpris p� produkten.

