
# Autószerelő műhely

📝 Projekt célja

Az AutoSzereloMuhely egy ASP.NET Core WebAPI + Blazor WebAssembly alapú alkalmazás, amely lehetőséget biztosít egy autószerelő műhely számára az ügyfelek és javítási munkák adminisztrációjára. A cél egy jól kezelhető, modern felhasználói felület és egy REST-alapú háttérrendszer kialakítása.

## ⚙️ Fő funkciók

    👤 Ügyfélkezelés

        Új ügyfél rögzítése validációval (név, e-mail, lakcím)

        Ügyfél módosítása

        Ügyfél törlése

        Teljes ügyféllista megtekintése

    🧾 Munkalapkezelés

        Javítási munka rögzítése ügyfélhez kötve

        Munka adatai: rendszám, gyártási év, kategória, leírás, súlyosság, állapot

        Munka módosítása, törlése, listázása

        Munkaóra-becslés: kategória × kor × hiba súlyosság (tooltipként jelenik meg)

    🧪 Unit tesztek

        Kontroller szintű egységtesztek FakeItEasy segítségével

        Pozitív és negatív tesztelési forgatókönyvek

        CI-barát struktúra


## 🛠 Tech Stack
    Frontend (Client):

        - Blazor WebAssembly (.NET 9)

        - Bootstrap 5

        - CSS

    Backend (API):

        - ASP.NET Core Web API (.NET 9)

        - Entity Framework Core – Code First adatbázis-kezelés

        - RESTful végpontok ügyfelek és munkák kezelésére

    Adatbázis:

        - SQL 

    Unit Tesztelés:

        - xUnit

        - FakeItEasy

        - FluentAssertions


