/*
 Készítsen egy C# nyelvű konzol alkalmazást, amely egy hatoldalú dobókockával történő dobásokat szimulál, és az eredmények alapján statisztikai elemzést végez. A program kérje be a felhasználótól, hogy hány dobást szeretne végrehajtani (2 és 100 közötti érték), majd generáljon ennyi véletlenszerű dobást. Minden dobás után írja ki a dobott számot, annak megfelelő enum értékét, valamint azt, hogy az érték páros vagy páratlan. A dobások értékeit tárolja egy tömbben, és számolja meg, hogy az egyes értékek hányszor fordultak elő.
 A program végén számítsa ki a dobások átlagát és szórását, majd jelenítse meg ezeket az értékeket a képernyőn. Emellett írja ki az egyes dobásértékek gyakoriságát is, az enum típusnak megfelelően. 
 A feladatot Visual Studio 2022 Community Edition fejlesztőkörnyezetben kell elkészíteni, C# Console Application projektként, .NET 8 keretrendszerre. A programban alkalmazzon felső szintű utasításokat (top-level statement), azaz ne használjon külön Main() metódust, hanem közvetlenül a fájl tetején kezdje az utasítások írását.
 */

Console.WriteLine("Kockadobások szimulálása");

// A dobókocka oldalainak száma 
int OldalakSzáma = 6;

// Enum típus példányosítása (később használjuk a kiírásnál)
//Dobás d;

// Véletlenszám-generátor példányosítása
Random r = new Random();

// Átlag kiszámításához használt változó
double Átlag = 0;

// A dobások számát tároló változó
int N;

// A felhasználótól bekérjük, hogy hány dobást szeretne végrehajtani (2 és 100 között)
do
{
	Console.Write("Dobások száma (2..100): ");
	string? Input = Console.ReadLine();

	// Megpróbáljuk egész számmá konvertálni a bemenetet
	if (!int.TryParse(Input, out N))
	{
		// Ha nem sikerül, akkor alapértelmezésként 100-at veszünk
		N = 100;
	}
} while (N < 2 || N > 100); // Addig ismételjük, amíg nem megfelelő a szám

Console.WriteLine($"Dobások száma: {N}");

// A dobott értékeket tároló tömb
int[] Tmb = new int[N];

// A dobott értékek gyakoriságát tároló tömb (index: 0 → 1-es dobás, ..., 5 → 6-os dobás)
int[] Gyakoriság = new int[6];

// A dobások szimulálása
for (int i = 0; i < N; i++)
{
	// Véletlenszerű szám generálása 1 és 6 között
	Tmb[i] = r.Next(1, 7);

	// Hozzáadjuk az értéket az átlaghoz
	Átlag += Tmb[i];

	// Növeljük a megfelelő érték gyakoriságát
	Gyakoriság[Tmb[i] - 1]++;

	// Eldöntjük, hogy páros vagy páratlan-e a dobott szám
	string s = Tmb[i] % 2 == 0 ? " páros" : " páratlan";

	// Kiírjuk a dobás sorszámát, értékét és páros/páratlan jellegét. A sorszám három mezőn jobbra igazítottsan jelenik meg.
	Console.WriteLine($"{(i + 1),3}. dobás: {Tmb[i]} - {s}");
}

// Szórás kiszámítása
double Szórás = 0;

// Átlag kiszámítása
Átlag /= N;

// Korrigált tapasztalati szórás
for (int i = 0; i < N; i++)
{
	Szórás += (Tmb[i] - Átlag) * (Tmb[i] - Átlag);
}
Szórás = Math.Sqrt(Szórás / (N - 1));

// Átlag és szórás kiírása
Console.WriteLine($"Átlag: {Átlag:0.00}");
Console.WriteLine($"Szórás: {Szórás:0.00}");

// Gyakoriságok kiírása az enum típusnak megfelelően. Az oldalnevek hat mezőn balra igazítottan jelennek meg.
for (int i = 0; i < OldalakSzáma; i++)
{
	Console.WriteLine($"{(Dobás)(i + 1),-6} gyakorisága: {Gyakoriság[i]}");
}

// Enum típus, amely a dobókocka oldalait reprezentálja
enum Dobás
{
	Egyes = 1,
	Kettes,
	Hármas,
	Négyes,
	Ötös,
	Hatos
}