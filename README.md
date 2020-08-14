
# BedrijfswagenBeheer | PostB
>Een applicatie om het wagenpark van een bedrijf te beheren. 

## Project Info
Een postbedrijf genaamd PostB heeft meerdere filialen in België. Het is moeilijk om per filiaal een overzicht te houden over de wagens waarover leveranciers beschikken. We maken aa WPF Applicatie waar we per filiaal de wagens kunnen beheren.

Een wagen heeft een merk, een type en een bestuurder.

Wagen voorbeeld:
``
{id} - {merk} {type} - {bestuurder met id}
``
``
48 - Citroën Bestelwagen - Jan Janssens (5)
``

### Extra's
* Wagen voorbeeld:
	* Kenteken letters worden random gemaakt. Getallen achteraan is ID van de wagen.

	* ``
{kenteken} - {merk} {type} - {bestuurder met id}
``
``
1-ABC-148 - Citroën Bestelwagen - Jan Janssens (5)
``

* Binnenin een filiaal 2 dropdown lijsten
	* Beschikbare wagens (#aantal)
	* Bezette wagens (#aantal)
<voorbeeldfoto invoegen>

## Vereiste
* WPF
* Entity Framework
* MVVM
* CRUD van alle gegevens
* Databank wordt automatisch gemaakt bij de (eerste) opstart van het project.
## Used Software

* [Visual Studio 2019](https://visualstudio.microsoft.com/vs/) - IDE
* [Microsoft SQL Management Studio](https://visualstudio.microsoft.com/vs/) - Database


## Authors

* **Elliot Borryn** - [GitHub Link](https://github.com/elliotborryn)
