# Mixed Reality Eigenstudium 


## 1. Projektbeschreibung 
XXXX

## 2. Aufsetzen des Projekts

Ich habe ein AR Mobile Projekt in Unity (Version 6.6) erstellt und ein gratis Asset für einen Fuchs hinzugefügt (https://assetstore.unity.com/packages/3d/characters/animals/toon-fox-183005).

In Window/Package Manager habe ich im Unity Registry kontrolliert ob ich AR Foundation (Version 6.6.2) und Apple ARKit XR Plugin (Version 6.6.2) um für den Build für iOS installiert habe. Da ich nur ein iPhone besitze aber auf einem Windows PC hauptsächlich programmiere, werde ich mein Macbook zu einem späteren Zeitpunkt mit Github benutzen, da ein Build für iOS nur auf einem Mac möglich ist.

Danach habe ich unter File/Build Profiles die Plattform von Windows auf iOS gewechselt. Außerdem habe ich den Developement Build aktiviert, um Testing zu vereinfachen. Würde ich die App veröffentlichen würde ich diese Option natürlich deaktivieren. In dem Window "Player Settings", welches sich in Edit/Project Settings befindet, habe ich für iOS kontrolliert, welche iOS Version mindestens notwendig ist (15.0), ob ARKit Support required ist, und dass der Bundle identifier vorausgefüllt com.unity.template.armobile ist. 

Dann habe ich noch unter XR Plug-in Management kontrolliert, ob Apple ARKit als Plugin Provider ausgewählt ist und das es in den Einstellungen von Apple ARKit auch "Required" ausgewählt hat.


XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
AR Mobile Project DONE → iOS als Plattform DONE → AR Foundation prüfen DONE → ARKit XR Plugin installieren/aktivieren DONE → 
Image Tracking einrichten → Modell + Plane auf Marker → erster Test auf dem iPhone → danach die eigentlichen Skripte.
XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

## 3. Image Tracking

Um die Konfiguration von AR Foundation und dem Switch zum MAcbook zu testen, habe ich als erstes das Image Tracking (mit Hilfe der Dokumentation https://docs.unity3d.com/Packages/com.unity.xr.arfoundation@6.6/manual/features/image-tracking.html) eingerichtet. 

Unter Assets im Project Window in Unity ist schon ein XR Ordner angelegt. In diesem konnte ich dann die Option "Reference Image Library" auswählen. Im XR Folder habe ich außerdem einen neuen Ordner "Images" erstellt und dort ein quadratisches jpg-Bild vom Unity Logo gespeichert. Dann habe ich der Reference Image Library dieses Bild übergeben. Die "Specifiy size" in Meter habe ich auf 0.11 gestellt, weil ich das Bild dann in eine Word-Datei eingefügt und auf 11 cm Größe eingestellt habe.

Zum XR Origin Objekt in dem Hierarchy Window habe ich die "AR Tracked Image Manager" Konponente hinzugefügt. Unter "Serialized Library" habe ich dann die Reference Image Library eingefügt, die ich davor erstellt habe und mit dem Bild befüllt habe. Dann habe ich in der Hierarchy ein neues Objekt "MarkerContent" genannt, da unter "Tracked Image Prefab" noch kein Game Object hinterlegt ist. Ich habe dem MarkerContent das 3D-Objekt Plane hinzugefügt. 

XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX
Da diese im der XZ-Ebene liegen soll, habe ich ihr die Koordinaten (0.011,1,0.011) für Scale gegeben, um 1 Einheit hoch und gleich breit wie das Bild zu sein. 
XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX

Dann habe ich das prefab-File vom Fuchs ebenfalls in das MarkerContent Objekt gezogen und so das Objekt in einen neu angelegten Ordner "Prefab" abgelegt. Dies erstellt eine neue prefab-Datei, die ich dann in der Reference image Library hinzugefügt habe. Danach habe ich dann das Objekt in der Hierarcy gelöscht, damit es nicht von anfang an sichtbar ist und erst durch das Image, das getrackt wird, sichtbar wird.

## 4. Testen des Image Tracking auf iPhone mit Build für iOS
Dannach habe ich einen Build für iOS in Unity auf meinem Windows Laptop erstellt und in einem neuen Ordner im Projekt gespeichert. Dann habe ich den Ordner gezippt und durch Google Drive auf mein Macbook transferiert. In dem entzippten Ordner habe ich dann das XCode Projekt geöffnet, um so für mein iPhone kompilieren zu können. 

## 5. Bewegung des Assets



## 5. Interaktion mit dem Fuchs