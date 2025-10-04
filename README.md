# Dobókocka

Készítsen egy C# nyelvû konzol alkalmazást, amely egy hatoldalú dobókockával  történõ dobásokat szimulál, és az eredmények alapján statisztikai elemzést végez. A program kérje be a felhasználótól, hogy hány dobást szeretne végrehajtani (2 és 100 közötti érték), majd generáljon ennyi véletlenszerû dobást. Minden dobás után írja ki a dobott számot, annak megfelelõ *enum* értékét, valamint azt, hogy az érték páros vagy páratlan. A dobások értékeit tárolja egy tömbben, és számolja meg, hogy az egyes értékek hányszor fordultak elõ.

A program végén számítsa ki a dobások átlagát és szórását, majd jelenítse meg ezeket az értékeket a képernyõn. Emellett írja ki az egyes dobásértékek gyakoriságát is, az *enum* típusnak megfelelõen. 

 A feladatot Visual Studio 2022 Community Edition fejlesztõkörnyezetben kell elkészíteni, C# Console Application projektként, .NET 8 keretrendszerre. A programban alkalmazzon *felsõ szintû utasításokat* (top-level statement), azaz ne használjon külön Main() metódust, hanem közvetlenül a fájl tetején kezdje az utasítások írását.
