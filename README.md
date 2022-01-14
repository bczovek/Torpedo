# Torpedo

## Játékmenet

### Főmenü
#### A játékot elindítva a főmenübe lépünk, ahol 3 opció közül választhatunk:
- Play: új játék indítása
- Scoreboard: eddigi játékok eredményeinek megtekintése
- Exit: kilépés a játékból

### Play
#### Új játék indítása esetén meg kell adni a játékos neveit. Alapértelmezetten egyszemélyes játék van beállítva, ahhoz, hogy két személyes játékot tudjunk játszani be kell pipálni a Two Player Game dobozt, ekkor meg tudjuk adni a második játékos nevét is és indítani tudjuk a játékot. A start gombra kattintva a játék elindul.

### Hajók elhelyezése
#### Következő képernyőn a hajók elhelyezése következik. Alapértelmezetten függőlegesen lefele helyezi el a hajót, attól a kockától kezdve, ahova kattintottunk. Ahhoz, hogy víszintesen, jobbra fele pakolja le a hajót be kell pipálnunk a Horizontal Ship dobozt. A Reset gombra kattintva újra pakolhatjuk a hajóinkat, ha pedig leraktuk mind az 5 hajót, akkor a Done gombra kattintva elindul a játék.

### Játék ablak
#### A játékba lépve két négyzetrácsot fogunk látni, a bal oldali a saját hajóink elhelyezkedése, ahol láthatjuk, hogy hova raktuk a hajóinkat és az ellenfél hova lőtt. Jobb oldalt az ellenfél tábláját láthatjuk, azt hogy mi hova lőttünk és hogy ahova lőttünk, az talált-e hajót vagy nem. Az eltalált hajók piros színnel jelennek meg, az elvétett lövések szürkével, a saját hajóink pedig fehér színnel. Minden lövés után eltűnnek a táblák, hogy egy átmenet legyen a két kör között és ne lehessen látni az ellenfél tábláit. Amennyiben valamelyik játékosnak az összes hajója elsüllyedt a játék véget ér és visszaléphetünk a főképernyőre. Amint a játék véget ért, az eredményt eltároljuk egy lokális adatbázisban és a Scoreboard menüpont alatt visszanézhető az eredmény.
